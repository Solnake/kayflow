using System.Collections.Generic;

public enum eCrumbType
{
    Link,
    Text,
    Hidden
}

public class Crumb
{
    public string View { get; set; }

    public string ParentView { get; set; }

    public string Title { get; set; }

    public eCrumbType Type { get; set; }

    public Crumb()
    {
        Type = eCrumbType.Link;
    }
}