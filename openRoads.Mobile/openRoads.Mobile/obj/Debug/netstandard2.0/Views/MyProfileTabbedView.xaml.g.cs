//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("openRoads.Mobile.Views.MyProfileTabbedView.xaml", "Views/MyProfileTabbedView.xaml", typeof(global::openRoads.Mobile.Views.MyProfileTabbedView))]

namespace openRoads.Mobile.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\MyProfileTabbedView.xaml")]
    public partial class MyProfileTabbedView : global::Xamarin.Forms.TabbedPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TabbedPage TabbedPage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::openRoads.Mobile.Views.MyProfileView MyProfile;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::openRoads.Mobile.Views.MyReservationsView MyReservations;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MyProfileTabbedView));
            TabbedPage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TabbedPage>(this, "TabbedPage");
            MyProfile = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::openRoads.Mobile.Views.MyProfileView>(this, "MyProfile");
            MyReservations = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::openRoads.Mobile.Views.MyReservationsView>(this, "MyReservations");
        }
    }
}
