using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;
using Padding = DevExpress.XtraLayout.Utils.Padding;

namespace Kayflow.Acts
{
    public partial class frmStepsEdit : BaseEditForm
    {
        public frmStepsEdit()
        {
            InitializeComponent();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            base.BaseEditForm_Shown(sender, e);
            new CustomFocusHelper(layoutMain).FocusFirstEditableControl();
        }

        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            ddlState.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && (ddlState.EditValue != null);
        }

        protected override void LoadData()
        {
            base.LoadData();
            ddlState.Properties.DataSource = CreateManager<StateManager>().GetByOffice(CurrentInfo.OfficeID);
            var status = CreateManager<StateHistoryManager>().GetCurrent(DocID);
            if (status != null)
                ddlState.EditValue = status.StateID;
            var steps = Factory.Manager<StepManager>().GetForAct(DocID);
            FillSteps(steps);
        }

        private void FillSteps(IEnumerable<Step> steps)
        {
            layoutMain.BeginUpdate();
            try
            {
                
                var list = steps as List<Step> ?? steps.ToList();
                var groups = new List<BaseLayoutItem>
                                 {
                                     layoutStateDescription
                                 };
                foreach (var step in list.OrderBy(g => g.OrdNum))
                {
                    var baseItem = groups.Last();
                    var insertType = InsertType.Bottom;
                    if (list.Count>6)
                    {
                        if (((list.IndexOf(step) + 1) % 2) == 0)
                        {
                            insertType = InsertType.Right;
                        }
                        else if (baseItem != groups.First())
                        {
                            baseItem = groups[groups.IndexOf(baseItem) - 1];
                        }
                    }
                    var group = layoutMain.Root.AddGroup(step.ActionName, baseItem, insertType);
                    if (insertType == InsertType.Bottom)
                        group.Width = layoutStateDescription.Width;
                    group.Tag = step;
                    group.Padding = new Padding {All = 5};
                    var itemDelivered = group.AddItem("Передали");
                    itemDelivered.TextLocation = Locations.Top;
                    itemDelivered.Tag = "Delivered";
                    var txtDelivered = new DateEdit();
                    txtDelivered.Properties.AllowNullInput = DefaultBoolean.True;
                    itemDelivered.Control = txtDelivered;
                    txtDelivered.EditValue = step.Delivered;

                    var itemReceived = new LayoutControlItem
                                           {
                                               Text = Resources.received,
                                               TextLocation = Locations.Top,
                                               Tag = "Received"
                                           };
                    group.AddItem(itemReceived, itemDelivered, InsertType.Right);
                    var txtReceived = new DateEdit();
                    txtReceived.Properties.AllowNullInput = DefaultBoolean.True;
                    itemReceived.Control = txtReceived;
                    txtReceived.EditValue = step.Received;
                   groups.Add(group);
                }
                layoutMain.BestFit();
                int heigh = layoutMain.Root.MinSize.Height < 640 ? layoutMain.Root.MinSize.Height + 140 : 640;
                ClientSize = new Size(ClientSize.Width, heigh);
            }
            finally
            {
                layoutMain.EndUpdate();
                new CustomFocusHelper(layoutMain).FocusFirstEditableControl();
                StartPosition = FormStartPosition.Manual;
                Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
                Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
            }
        }

        protected override BaseModel DoSave()
        {
            var list = new List<Step>();
            foreach (var group in layoutMain.Root.Items.OfType<LayoutControlGroup>().ToList())
            {
                if (!(@group.Tag is Step)) continue;
                var itemDelivered =
                    @group.Items.Cast<LayoutControlItem>().ToList().Find(i => i.Tag.ToString() == "Delivered");
                var txtDelivered = itemDelivered.Control as DateEdit;
                var itemReceived =
                    @group.Items.Cast<LayoutControlItem>().ToList().Find(i => i.Tag.ToString() == "Received");
                var txtReceived = itemReceived.Control as DateEdit;
                var step = @group.Tag as Step;
                step.Delivered = GetValue<DateTime?>(txtDelivered);
                step.Received = GetValue<DateTime?>(txtReceived);
                list.Add(step);
            }
            CreateManager<StepManager>().SaveAll(list,
                                                 new StateHistory
                                                     {
                                                         ActID = DocID,
                                                         EmployeeID = CurrentInfo.EmployeeID,
                                                         StateID = GetValue<Guid>(ddlState),
                                                         StateName = ddlState.Text,
                                                         Description = txtStateDescription.Text,
                                                         OnDate = DateTime.Now
                                                     },
                                                 new Note
                                                     {
                                                         ActID = DocID,
                                                         EmployeeID = CurrentInfo.EmployeeID,
                                                         Description = txtDescription.Text,
                                                         OnDate = DateTime.Now
                                                     });
            return null;
        }
    }
}
