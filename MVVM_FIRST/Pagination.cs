using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST
{
    public class Pagination<T> where T : class
    {


        public Pagination(ObservableCollection<T> listOfAll, int numberOfItemsPerPage, int currentPage)
        {
            ListOfAll = listOfAll;
            NumberOfItemsPerPage = numberOfItemsPerPage;
            CurrentPage = currentPage;
            CreatePages();
        }

        private void CreatePages()
        {
            NumberOfPages = ListOfAll.Count / NumberOfItemsPerPage;
            if (ListOfAll.Count % _NumberOfItemsPerPage > 0)
            {
                NumberOfPages++;
            }

            for (int i = 0; i < NumberOfPages; i++)
            {
                Page<T> P = new Page<T>();

                for (int j = 0; i < NumberOfItemsPerPage; j++)
                {   if(i * NumberOfItemsPerPage + j < ListOfAll.Count)
                         P.MyPage.Add(ListOfAll[i * NumberOfItemsPerPage + j]);
                }
                Pages.Add(P);
            }

        }
        public Page<T> GetFirstPage() => Pages[0];
        public Page<T> GetLastPage() => Pages[NumberOfPages-1];
        public Page<T> GetCurrentPage() => Pages[CurrentPage];
        public Page<T> GetNextPage()
        {
            if (CurrentPage < NumberOfPages - 1)
            {
                CurrentPage++;
                return Pages[CurrentPage];
            }
            return null;
        }

        public Page<T> GetPreviousPage()
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                return Pages[CurrentPage];
            }
            return null;
        }

        private int _NumberOfPages;

        public int NumberOfPages
        {
            get { return _NumberOfPages; }
            set { _NumberOfPages = value; }
        }

        private ObservableCollection<T> _ListOfAll;

        public ObservableCollection<T> ListOfAll
        {
            get { return _ListOfAll; }
            set { _ListOfAll = value; }
        }


        private int _NumberOfItemsPerPage;

        public int NumberOfItemsPerPage
        {
            get { return _NumberOfItemsPerPage; }
            set { _NumberOfItemsPerPage = value; }
        }

        private int _CurrentPage;

        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }


        private ObservableCollection<Page<T>> _Pages;

        public ObservableCollection<Page<T>> Pages
        {
            get { return _Pages; }
            set { _Pages = value; }
        }



    }

    public class Page<T> where T : class
    {
        private ObservableCollection<T> _Page;

        public ObservableCollection<T> MyPage
        {
            get { return _Page; }
            set { _Page = value; }
        }

    }
}
