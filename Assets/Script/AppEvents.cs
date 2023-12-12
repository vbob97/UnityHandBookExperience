using System.Collections;
using System.Collections.Generic;
using System;

public static class AppEvents 
{
    public static EventHandler CloseBook;
    public static EventHandler OpenBook;
    public static void CloseBookFunction(){
        if(CloseBook != null){
            CloseBook(new object(), new EventArgs());
        }
    }

    public static void OpenBookFunction(){
        if(OpenBook != null){
            OpenBook(new object(), new EventArgs());
        }
    }
}
