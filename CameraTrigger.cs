	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.VR;

	public class CameraTrigger : MonoBehaviour
	{
		//camera rotation
		private Quaternion rotation;
		bool IsInBambooM;

		public GameObject TargetB;
		public GameObject TargetC;
		//name of the audio source: storyTrigger
		public int _StoryIsTelling;
		//lights
		Light[] lightsB;
		Light[] lightsC;

		//rendering
		Renderer[] rendB;
		Renderer[] rendC;

		//for SoundEffects
		public GameObject SfxB;
		public GameObject SfxC;
		AudioSource[] SoundsB;
		AudioSource[] SoundsC;

		//for Stories
		public GameObject InteractableB;
		public GameObject InteractableC;
		AudioSource[] StoriesB;
		AudioSource[] StoriesC;

		public bool BPlayed = false;
		public bool CPlayed = false;

		private bool AlreadyRenderedB = false;
		private bool AlreadyRenderedC = false;

		void Start ()
		{

			_StoryIsTelling = 0;

			rendB = TargetB.GetComponentsInChildren<Renderer> (true);
			rendC = TargetC.GetComponentsInChildren<Renderer> (true);
			lightsB = TargetB.GetComponentsInChildren<Light> (true);
			lightsC = TargetC.GetComponentsInChildren<Light> (true);
			SoundsB = SfxB.GetComponentsInChildren<AudioSource> (true);
			SoundsC = SfxC.GetComponentsInChildren<AudioSource> (true);

			StoriesB = InteractableB.GetComponentsInChildren<AudioSource> (true);
			StoriesC = InteractableC.GetComponentsInChildren<AudioSource> (true);
		}


		void Update ()
		{
			this.rotation = InputTracking.GetLocalRotation (VRNode.CenterEye);
			print ("x:" + rotation.eulerAngles.x + " y: " + rotation.eulerAngles.y + " z: " + rotation.eulerAngles.z);

			setMode ();
		}

		public void StoryIsTellingAdd ()
		{
			_StoryIsTelling++;
		}

		public void StoryIsTellingMinus ()
		{
			_StoryIsTelling--;
		}

		void setMode ()
		{
			//see if cameara is in Bamboo side or concrete side
			if (_StoryIsTelling == 0) {
				if (rotation.eulerAngles.y >= 90 && rotation.eulerAngles.y <= 270) {
					//print ("if camera in concrete mode");

					if (AlreadyRenderedB == false) {
						RenderSettings.ambientSkyColor = new Color (0.594615f, 0.65122f, 0.6911765f, 1.0f);
						RenderSettings.fogColor = new Color (0.4941177f, 0.5607843f, 0.654902f, 1.0f);
						RenderSettings.fogDensity = 0.1f;
						RenderSettings.ambientSkyColor = new Color (0.8941177f, 0.9411765f, 0.9333333f, 1.0f);
						//RenderSettings.fogColor = new Color32( 186, 186, 186, 255 );
						RenderSettings.fogColor = new Color32 (172, 153, 189, 255);
						RenderSettings.fogMode = FogMode.Linear;
						RenderSettings.fogStartDistance = -10;
						RenderSettings.fogEndDistance = 500;

						AlreadyRenderedB == true;
					}

					SetLightC ();
					RenderC ();
					PlaySoundsC ();
					EnableStoryC ();

					/*
	              	iTween.FadeTo(TargetC, 1, 0.5f);
	        		Invoke("SetTargetCOpaque", 0.5f);

	              	SetTargetBTransparent();
	              	iTween.FadeTo(TargetB, 0, 0.5f);  
	             	*/

					/*
					if (!IsInBambooM)
					{
						ConcreteM();
					}
					*/
				} else {
					//print ("if camera in bamboo mode");
					if (AlreadyRenderedC == false) {
						RenderSettings.ambientSkyColor = new Color (0.8941177f, 0.9411765f, 0.9333333f, 1.0f);
						//RenderSettings.fogColor = new Color32( 186, 186, 186, 255 );
						RenderSettings.fogColor = new Color32 (172, 153, 189, 255);
						RenderSettings.fogMode = FogMode.Linear;
						RenderSettings.fogStartDistance = -10;
						RenderSettings.fogEndDistance = 500;

						AlreadyRenderedC = true;
					}

					SetLightB ();
					RenderB ();
					PlaySoundsB ();
					EnableStoryB ();

					/*
	              	iTween.FadeTo(TargetB, 1, 0.5f);
	        		Invoke("SetTargetBOpaque", 0.5f);

	              	SetTargetCTransparent();
	              	iTween.FadeTo(TargetC, 0, 0.5f);
	              	*/

					/*
					if (IsInBambooM)
					{
						BambooM();
					}
					*/
				}
			}
		}

		//set light for each mode
		void SetLightB ()
		{
			foreach (Light lightB in lightsB)
				lightB.enabled = true;
			foreach (Light lightC in lightsC)
				lightC.enabled = false;
		}

		void SetLightC ()
		{
			foreach (Light lightB in lightsB)
				lightB.enabled = false;
			foreach (Light lightC in lightsC)
				lightC.enabled = true;
		}

		//rendering for each mode
		void RenderB ()
		{
			//print("render Bamboo");
			foreach (Renderer rb in rendB)
				rb.enabled = true;
			foreach (Renderer rc in rendC)
				rc.enabled = false;
		}

		void RenderC ()
		{
			//print("render concrete");
			foreach (Renderer rb in rendB)
				rb.enabled = false;
			foreach (Renderer rc in rendC)
				rc.enabled = true;
		}

		//Enable sound effects for each mode
		void PlaySoundsB ()
		{
			foreach (AudioSource SoundB in SoundsB)
				SoundB.Play ();
			foreach (AudioSource SoundC in SoundsC)
				SoundC.Pause ();
		}

		void PlaySoundsC ()
		{
			foreach (AudioSource SoundB in SoundsB)
				SoundB.Pause ();
			foreach (AudioSource SoundC in SoundsC)
				SoundC.Play ();
		}

		//enable story
		void EnableStoryB ()
		{
			if (_StoryIsTelling == 0) {
				foreach (AudioSource StoryB in StoriesB) {
					StoryB.enabled = true;
				}
				foreach (AudioSource StoryC in StoriesC) {
					StoryC.enabled = false;
				}
			}
		}

		void EnableStoryC ()
		{
			if (_StoryIsTelling == 0) {
				foreach (AudioSource StoryB in StoriesB) {
					StoryB.enabled = false;
				}
				foreach (AudioSource StoryC in StoriesC) {
					StoryC.enabled = true;
				}
			}
		}


		private void SetTargetBTransparent ()
		{
			foreach (Renderer rb in rendB) {
				foreach (Material m in rb.materials) {
					if (m.HasProperty ("_Color")) {
						m.SetFloat ("_Mode", 2);
						m.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
						m.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
						m.SetInt ("_ZWrite", 0);
						m.DisableKeyword ("_ALPHATEST_ON");
						m.EnableKeyword ("_ALPHABLEND_ON");
						m.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
						m.renderQueue = 3000;
					}
				}
			}
			IsInBambooM = false;
		}

		private void SetTargetCTransparent ()
		{
			foreach (Renderer rc in rendC) {
				foreach (Material m in rc.materials) {
					if (m.HasProperty ("_Color")) {
						m.SetFloat ("_Mode", 2);
						m.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
						m.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
						m.SetInt ("_ZWrite", 0);
						m.DisableKeyword ("_ALPHATEST_ON");
						m.EnableKeyword ("_ALPHABLEND_ON");
						m.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
						m.renderQueue = 3000;
					}
				}
			}
			IsInBambooM = true;
		}

		private void SetTargetBOpaque ()
		{
			foreach (Renderer rb in rendB) {
				foreach (Material m in rb.materials) {
					if (m.HasProperty ("_Color")) {
						m.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
						m.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
						m.SetInt ("_ZWrite", 1);
						m.DisableKeyword ("_ALPHATEST_ON");
						m.DisableKeyword ("_ALPHABLEND_ON");
						m.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
						m.renderQueue = -1;
					}
				}
			}
		}

		private void SetTargetCOpaque ()
		{
			foreach (Renderer rc in rendC) {
				foreach (Material m in rc.materials) {
					if (m.HasProperty ("_Color")) {
						m.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
						m.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
						m.SetInt ("_ZWrite", 1);
						m.DisableKeyword ("_ALPHATEST_ON");
						m.DisableKeyword ("_ALPHABLEND_ON");
						m.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
						m.renderQueue = -1;
					}
				}
			}
		}
	}