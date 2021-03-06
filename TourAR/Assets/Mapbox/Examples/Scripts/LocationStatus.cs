﻿namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Utils;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class LocationStatus : MonoBehaviour
	{

		[SerializeField]
		Text _statusText;
		[SerializeField] Animator fadeIn;
		[SerializeField] GameObject fadePanel;
		private bool hasFade=false;
		[SerializeField] Animator textFade;


		private AbstractLocationProvider _locationProvider = null;
		void Start()
		{
			if (null == _locationProvider)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
			}
		}


		void Update()
		{
			Location currLoc = _locationProvider.CurrentLocation;

			if (currLoc.IsLocationServiceInitializing)
			{
				_statusText.text = "location services are initializing";
			}
			else
			{
				if (!currLoc.IsLocationServiceEnabled)
				{
					_statusText.text = "location services not enabled";
				}
				else
				{
					if (currLoc.LatitudeLongitude.Equals(Vector2d.zero))
					{
						_statusText.text = "Waiting for location ....";
					}
					else
					{
						_statusText.text = string.Format("{0}", currLoc.LatitudeLongitude);
						//trigger anim
						if (!hasFade) {
							textFade.SetBool("Fade", true);
							fadeIn.SetBool("Fade", true);
							fadePanel.SetActive(false);
							Debug.Log("Panel is set to " + fadeIn.GetBool("Fade"));
							Debug.Log("Text is set to " + textFade.GetBool("Fade"));
							hasFade=true;
						}
					}
				}
			}

		}
	}
}
