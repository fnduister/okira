using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace okiraPrism.Views.Catalog
{
    /// <summary>
    /// Page to display articles as a card type.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleCardPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleCardPage" /> class.
        /// </summary>
        public ArticleCardPage()
        {
            InitializeComponent();


            NavigationPage.SetHasBackButton(this, false);


        }
    }
}

