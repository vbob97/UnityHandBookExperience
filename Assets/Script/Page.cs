using System.Collections;
using System.Collections.Generic;

public class Page 
{
    public string Title {get; set;}
    public string Text {get; set;}
    public List<string> Pages {get; set;}
    private  static List<Page> _pageList = null;
    
    public static Page RandomPage;

    public static int CurrentPage1 = 0;
    public static int CurrentPage2 = 1;


    public static Page GetRandomPage()
    {
         List<Page> pageList = Page.PageList;

        int num = UnityEngine.Random.Range(0, pageList.Count);
        Page pge = pageList[num];
        pge.Pages = new List<string>();

        string[] words = pge.Text.Split(' ');
        // 6 parole per pagina
        string page = "";
        int wordCnt = 0;

        foreach (string word in words)
        {
            wordCnt++;
            if (wordCnt > 6)
            {
                pge.Pages.Add(page);
                page = "";
                wordCnt = 0;
            }
            page += string.Format("{0} ", word); 
        }
        pge.Pages.Add(page);

        RandomPage = pge;

        return pge;
    }
 
    public static List<Page> PageList
    {
        get
        {
            if(_pageList == null)  
            {
                _pageList = new List<Page>();

                _pageList.Add(new Page
                    {
                        //1
                        Title = "Acts 17:11",
                        Text = "these were more noble than those in Thessalonica, in that they received the word with all readiness of mind, and searched the scriptures daily, whether those things were so."
                    }
                );

                _pageList.Add(new Page
                    {
                        //2
                        Title = "Jeremiah 17:9",
                        Text = "the heart is deceitful above all things, and desperately wicked: who can know it?"
                    }
                );
             
                _pageList.Add(new Page
                    {
                        //3
                        Title = "Romans 3:23",
                        Text = "for all have sinned, and come short of the glory of God;"
                    }
                );
                _pageList.Add(new Page
                    {
                        //4
                        Title = "Romans 6:23",
                        Text = "for the wages of sin is death; but the gift of God is eternal life through Jesus Christ our Lord."
                    }
                );
                _pageList.Add(new Page
                    {
                        //5
                        Title = "Romans 5:8",
                        Text = "but God commendeth his love toward us, in that, while we were yet sinners, Christ died for us."
                    }
                );

                _pageList.Add(new Page
                    {
                        //6
                        Title = "Romans 9:9",
                        Text = "that if thou shalt confess with thy mouth the Lord Jesus, and shalt believe in thine heart that God hath raised him from the dead, thou shalt be saved."
                    }
                );

                _pageList.Add(new Page
                    {
                        //7
                        Title = "Romans 10:13",
                        Text = "for whosoever shall call upon the name of the Lord shall be saved."
                    }
                );

                _pageList.Add(new Page
                    {
                        //8
                        Title = "Romans 10:9",
                        Text = "that if thou shalt confess with thy mouth the Lord Jesus, and shalt believe in thine heart that God hath raised him from the dead, thou shalt be saved."
                    }
                );

                _pageList.Add(new Page
                    {
                        //9
                        Title = "Acts 16:31",
                        Text = "and they said, believe on the Lord Jesus Christ, and thou shalt be saved, and thy house."
                    }
                );

                

            }  
            return _pageList;
        }
    }
}
