namespace FactoryMethod;

#region Pages (Products)
public abstract class Page { }

public class SkillsPage : Page { }

public class EducationPage : Page { }

public class ExperiencePage : Page { }

public class IntroductionPage : Page { }

public class ResultsPage : Page { }

public class ConclusionPage : Page { }

public class SummaryPage : Page { }

public class BibliographyPage : Page { }
#endregion

#region Creators
public abstract class Document
{
    public abstract Page[] CreatePages();
}

public class Resume : Document
{
    public override Page[] CreatePages()
    {
        var pages = new Page[]
        {
            new SkillsPage(),
            new EducationPage(),
            new ExperiencePage()
        };

        return pages;
    }
}

public class Report : Document
{
    public override Page[] CreatePages()
    {
        var pages = new Page[]
        {
            new IntroductionPage(),
            new ResultsPage(),
            new ConclusionPage(),
            new SummaryPage(),
            new BibliographyPage()
        };

        return pages;
    }
}
#endregion