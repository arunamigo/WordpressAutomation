﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class ListPostsPage
    {
        public static void GoTo(PostType postType) 
        {
            switch(postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

            }
        }

        public static void Selectpost()
        {
            
        }

        public enum PostType 
        {
            Page
        }
    }
}
