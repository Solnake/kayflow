﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyActList.ascx.cs" Inherits="Controls_Acts_MyActList" %>
<%@ Register Src="~/Controls/Acts/ActList.ascx" TagPrefix="uc1" TagName="ActList" %>
<uc1:ActList runat="server" ID="ActList" OnGetDataSource="ActList_OnGetDataSource" />
