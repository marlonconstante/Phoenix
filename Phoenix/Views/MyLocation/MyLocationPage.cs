﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;

namespace Phoenix.Views.MyLocation
{
	public class MyLocationPage : ContentPage
	{
		public MyLocationPage()
		{
			BackgroundColor = Color.FromHex("15496f");

			var label = new Label();

			if (Device.OS == TargetPlatform.iOS)
			{
				label.YAlign = TextAlignment.Center;
				label.XAlign = TextAlignment.Center;
				label.Font = Font.OfSize("Source Sans Pro", NamedSize.Medium);
				label.TextColor = Color.White;

			}
			else
			{
				label = new ExtendedLabel
				{
					YAlign = TextAlignment.Center,
					XAlign = TextAlignment.Center,
					FontName = "Source Sans Pro",
					FontSize = 17,
					TextColor = Color.White
				};
			}

			label.Text = "\n\nDigite o código mais próximo\nda região que você se encontra\n\n";
			label.TextColor = Color.FromHex("e8edf1");

			var input = new QrCodeEntry();
			input.OnCodeComplete = () =>
			{
				//TODO: Chamar a mapa com os parametros.
				DisplayAlert("Feito", "Preeencher os numeros e chamar o mapa.", "Ok");
			};

			var imgButtonSize = Device.OnPlatform(60, 130, 130);
			var buttonSize = Device.OnPlatform(50, 80, 60);
			var cameraButton = new ImageButton()
			{
				Source = ImageSource.FromFile("cameraButton.png"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				ImageHeightRequest = imgButtonSize,
				ImageWidthRequest = imgButtonSize,
				BackgroundColor = Color.Transparent,
				HeightRequest = buttonSize,
				WidthRequest = buttonSize,
			};

			var photoLabel = new Label();


			if (Device.OS == TargetPlatform.iOS)
			{
				photoLabel.YAlign = TextAlignment.Center;
				photoLabel.XAlign = TextAlignment.Center;
				photoLabel.Font = Font.OfSize("Source Sans Pro", NamedSize.Small);
				photoLabel.TextColor = Color.White;

			}
			else
			{
				photoLabel = new ExtendedLabel
				{
					YAlign = TextAlignment.Center,
					XAlign = TextAlignment.Center,
					FontName = "Source Sans Pro",
					FontSize = 14,
					TextColor = Color.White
				};
			}

			photoLabel.Text = "\nOu fotografe o código presente na placa";
			photoLabel.TextColor = Color.FromHex("fcfbf9");


			var layout = new StackLayout();

			layout.Children.Add(label);
			layout.Children.Add(input);
//			layout.Children.Add(emptyLineLabel);
			layout.Children.Add(cameraButton);
			layout.Children.Add(photoLabel);
			layout.VerticalOptions = LayoutOptions.Start;
			layout.HorizontalOptions = LayoutOptions.Center;
			Content = layout;

		}
	}
}
