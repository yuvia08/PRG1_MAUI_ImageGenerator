using System.Diagnostics;

namespace ImageGenerator {
	public class Picture {
		public required string name { get; set; }
		public required string description { get; set; }
		public bool favorite { get; set; }
	}
	public partial class MainPage : ContentPage {
		private static List<Picture> ImageList = new List<Picture>() {
			new Picture() {
				name = "image1",
				description = "Man",
				favorite = false
			},
			new Picture() {
				name = "image2",
				description = "Bird",
				favorite = false
			},
			new Picture() {
				name = "image3",
				description = "Big cat",
				favorite = false
			},
			new Picture() {
				name = "image4",
				description = "Autumn road",
				favorite = false
			},
			new Picture() {
				name = "image5",
				description = "Flowergirl",
				favorite = false
			},
		};
		private Random random = new();
		private Picture p;
		public MainPage()
		{
			InitializeComponent();
		}
		private void ImageOnClicked(object? sender, EventArgs e)
		{
			ShowImageAndText();
		}
		private void setfavorite()
		{
			if (p.favorite) {
				FavoriteButton.Source = new FontImageSource {
					Glyph = "\ue87d",
					FontFamily = "MaterialIcons",
					Size = 32,
					Color = Colors.Red
				};
			} else {
				FavoriteButton.Source = new FontImageSource {
					Glyph = "\ue87e",
					FontFamily = "MaterialIcons",
					Size = 32,
					Color = Colors.Gray
				};
			}
		}
		private void ShowImageAndText()
		{
			string showKey;

			p = ImageList[random.Next(ImageList.Count)];

			showKey = GetImageFileEnding(p.name);

			ShowGallery.Source = showKey;

			ImageText.Text = p.description;
			setfavorite();
		}

		private static string GetImageFileEnding(string imageKey)
		{
#if WINDOWS
			return imageKey + ".jpg";
#else
			return imageKey;
#endif
		}

		private void OnFavoriteClicked(object sender, EventArgs e)
		{
			if(p != null) {
				p.favorite = !p.favorite;
				setfavorite();
			}
		}
	}
}
