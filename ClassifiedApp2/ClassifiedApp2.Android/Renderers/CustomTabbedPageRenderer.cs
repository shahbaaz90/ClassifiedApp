using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Views.InputMethods;
using ClassifiedApp2.Droid.Renderers;
using ClassifiedApp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Support.V7.Widget.SearchView;

//[assembly: ExportRenderer(typeof(RootTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace ClassifiedApp2.Droid.Renderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        private SearchView searchView;

        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }
            
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            AddSearchToToolBar();
        }

        private void AddSearchToToolBar()
        {
            MainActivity.ToolBar.Title = Element.Title;

            MainActivity.ToolBar.InflateMenu(Resource.Menu.mainmenu);

            searchView = MainActivity.ToolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            searchView.QueryTextChange += searchView_QueryTextChange;
            searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            searchView.QueryHint = (Element as RootTabbedPage)?.SearchPlaceHolderText;
            searchView.ImeOptions = (int)ImeAction.Search;
            searchView.InputType = (int)InputTypes.TextVariationNormal;
            searchView.MaxWidth = int.MaxValue;
        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            var searchPage = Element as RootTabbedPage;
            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as RootTabbedPage;
            searchPage.SearchText = e?.NewText;
        }

        protected override void Dispose(bool disposing)
        {
            if (searchView != null)
            {
                searchView.QueryTextChange -= searchView_QueryTextChange;
                searchView.QueryTextSubmit -= searchView_QueryTextSubmit;
            }
            MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            base.Dispose(disposing);
        }
    }
}
