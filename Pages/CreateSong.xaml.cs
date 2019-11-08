using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1808AHelloUWP.Entity;
using T1808AHelloUWP.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1808AHelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateSong : Page
    {
        private ISongService _songService;
        
        Song song;
        public CreateSong()
        {
            this.InitializeComponent();
            this._songService = new SongService();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             song = new Song
            {
                name = this.Name.Text,
                singer = this.Singer.Text,
                author = this.Author.Text,
                description = this.Description.Text,
                thumbnail=this.Thumbnail.Text,
                link=this.Link.Text
            };
             this._songService.CreateSong(ProjectConfiguration.CurrentMemberCredential , song);
        }
    }
}
