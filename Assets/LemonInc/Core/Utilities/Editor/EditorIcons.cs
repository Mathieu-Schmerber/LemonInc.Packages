using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor 
{
	public static class EditorIcons
	{
		private static GUIContent _help;
		/// <summary>
		/// _Help
		/// </summary>
		public static GUIContent Help => _help ??= EditorGUIUtility.IconContent("_Help");

		private static GUIContent _help2X;
		/// <summary>
		/// _Help@2x
		/// </summary>
		public static GUIContent Help2X => _help2X ??= EditorGUIUtility.IconContent("_Help@2x");

		private static GUIContent _menu;
		/// <summary>
		/// _Menu
		/// </summary>
		public static GUIContent Menu => _menu ??= EditorGUIUtility.IconContent("_Menu");

		private static GUIContent _menu2X;
		/// <summary>
		/// _Menu@2x
		/// </summary>
		public static GUIContent Menu2X => _menu2X ??= EditorGUIUtility.IconContent("_Menu@2x");

		private static GUIContent _popup;
		/// <summary>
		/// _Popup
		/// </summary>
		public static GUIContent Popup => _popup ??= EditorGUIUtility.IconContent("_Popup");

		private static GUIContent _popup2X;
		/// <summary>
		/// _Popup@2x
		/// </summary>
		public static GUIContent Popup2X => _popup2X ??= EditorGUIUtility.IconContent("_Popup@2x");

		private static GUIContent _aboutwindowmainheader;
		/// <summary>
		/// aboutwindow.mainheader
		/// </summary>
		public static GUIContent AboutwindowMainheader => _aboutwindowmainheader ??= EditorGUIUtility.IconContent("aboutwindow.mainheader");

		private static GUIContent _ageialogo;
		/// <summary>
		/// ageialogo
		/// </summary>
		public static GUIContent Ageialogo => _ageialogo ??= EditorGUIUtility.IconContent("ageialogo");

		private static GUIContent _alphabeticalsorting;
		/// <summary>
		/// AlphabeticalSorting
		/// </summary>
		public static GUIContent Alphabeticalsorting => _alphabeticalsorting ??= EditorGUIUtility.IconContent("AlphabeticalSorting");

		private static GUIContent _alphabeticalsorting2X;
		/// <summary>
		/// AlphabeticalSorting@2x
		/// </summary>
		public static GUIContent Alphabeticalsorting2X => _alphabeticalsorting2X ??= EditorGUIUtility.IconContent("AlphabeticalSorting@2x");

		private static GUIContent _animationaddevent;
		/// <summary>
		/// Animation.AddEvent
		/// </summary>
		public static GUIContent AnimationAddevent => _animationaddevent ??= EditorGUIUtility.IconContent("Animation.AddEvent");

		private static GUIContent _animationaddkeyframe;
		/// <summary>
		/// Animation.AddKeyframe
		/// </summary>
		public static GUIContent AnimationAddkeyframe => _animationaddkeyframe ??= EditorGUIUtility.IconContent("Animation.AddKeyframe");

		private static GUIContent _animationeventmarker;
		/// <summary>
		/// Animation.EventMarker
		/// </summary>
		public static GUIContent AnimationEventmarker => _animationeventmarker ??= EditorGUIUtility.IconContent("Animation.EventMarker");

		private static GUIContent _animationfilterbyselection;
		/// <summary>
		/// Animation.FilterBySelection
		/// </summary>
		public static GUIContent AnimationFilterbyselection => _animationfilterbyselection ??= EditorGUIUtility.IconContent("Animation.FilterBySelection");

		private static GUIContent _animationfirstkey;
		/// <summary>
		/// Animation.FirstKey
		/// </summary>
		public static GUIContent AnimationFirstkey => _animationfirstkey ??= EditorGUIUtility.IconContent("Animation.FirstKey");

		private static GUIContent _animationlastkey;
		/// <summary>
		/// Animation.LastKey
		/// </summary>
		public static GUIContent AnimationLastkey => _animationlastkey ??= EditorGUIUtility.IconContent("Animation.LastKey");

		private static GUIContent _animationnextkey;
		/// <summary>
		/// Animation.NextKey
		/// </summary>
		public static GUIContent AnimationNextkey => _animationnextkey ??= EditorGUIUtility.IconContent("Animation.NextKey");

		private static GUIContent _animationplay;
		/// <summary>
		/// Animation.Play
		/// </summary>
		public static GUIContent AnimationPlay => _animationplay ??= EditorGUIUtility.IconContent("Animation.Play");

		private static GUIContent _animationprevkey;
		/// <summary>
		/// Animation.PrevKey
		/// </summary>
		public static GUIContent AnimationPrevkey => _animationprevkey ??= EditorGUIUtility.IconContent("Animation.PrevKey");

		private static GUIContent _animationrecord;
		/// <summary>
		/// Animation.Record
		/// </summary>
		public static GUIContent AnimationRecord => _animationrecord ??= EditorGUIUtility.IconContent("Animation.Record");

		private static GUIContent _animationrecord2X;
		/// <summary>
		/// Animation.Record@2x
		/// </summary>
		public static GUIContent AnimationRecord2X => _animationrecord2X ??= EditorGUIUtility.IconContent("Animation.Record@2x");

		private static GUIContent _animationsequencerlink;
		/// <summary>
		/// Animation.SequencerLink
		/// </summary>
		public static GUIContent AnimationSequencerlink => _animationsequencerlink ??= EditorGUIUtility.IconContent("Animation.SequencerLink");

		private static GUIContent _animationanimated;
		/// <summary>
		/// animationanimated
		/// </summary>
		public static GUIContent Animationanimated => _animationanimated ??= EditorGUIUtility.IconContent("animationanimated");

		private static GUIContent _animationdopesheetkeyframe;
		/// <summary>
		/// animationdopesheetkeyframe
		/// </summary>
		public static GUIContent Animationdopesheetkeyframe => _animationdopesheetkeyframe ??= EditorGUIUtility.IconContent("animationdopesheetkeyframe");

		private static GUIContent _animationkeyframe;
		/// <summary>
		/// animationkeyframe
		/// </summary>
		public static GUIContent Animationkeyframe => _animationkeyframe ??= EditorGUIUtility.IconContent("animationkeyframe");

		private static GUIContent _animationnocurve;
		/// <summary>
		/// animationnocurve
		/// </summary>
		public static GUIContent Animationnocurve => _animationnocurve ??= EditorGUIUtility.IconContent("animationnocurve");

		private static GUIContent _animationvisibilitytoggleoff;
		/// <summary>
		/// animationvisibilitytoggleoff
		/// </summary>
		public static GUIContent Animationvisibilitytoggleoff => _animationvisibilitytoggleoff ??= EditorGUIUtility.IconContent("animationvisibilitytoggleoff");

		private static GUIContent _animationvisibilitytoggleoff2X;
		/// <summary>
		/// animationvisibilitytoggleoff@2x
		/// </summary>
		public static GUIContent Animationvisibilitytoggleoff2X => _animationvisibilitytoggleoff2X ??= EditorGUIUtility.IconContent("animationvisibilitytoggleoff@2x");

		private static GUIContent _animationvisibilitytoggleon;
		/// <summary>
		/// animationvisibilitytoggleon
		/// </summary>
		public static GUIContent Animationvisibilitytoggleon => _animationvisibilitytoggleon ??= EditorGUIUtility.IconContent("animationvisibilitytoggleon");

		private static GUIContent _animationvisibilitytoggleon2X;
		/// <summary>
		/// animationvisibilitytoggleon@2x
		/// </summary>
		public static GUIContent Animationvisibilitytoggleon2X => _animationvisibilitytoggleon2X ??= EditorGUIUtility.IconContent("animationvisibilitytoggleon@2x");

		private static GUIContent _animationwrapmodemenu;
		/// <summary>
		/// AnimationWrapModeMenu
		/// </summary>
		public static GUIContent Animationwrapmodemenu => _animationwrapmodemenu ??= EditorGUIUtility.IconContent("AnimationWrapModeMenu");

		private static GUIContent _assemblylock;
		/// <summary>
		/// AssemblyLock
		/// </summary>
		public static GUIContent Assemblylock => _assemblylock ??= EditorGUIUtility.IconContent("AssemblyLock");

		private static GUIContent _assetstore;
		/// <summary>
		/// Asset Store
		/// </summary>
		public static GUIContent AssetStore => _assetstore ??= EditorGUIUtility.IconContent("Asset Store");

		private static GUIContent _assetstore2X;
		/// <summary>
		/// Asset Store@2x
		/// </summary>
		public static GUIContent AssetStore2X => _assetstore2X ??= EditorGUIUtility.IconContent("Asset Store@2x");

		private static GUIContent _unityassetstoreoriginalslogowhite;
		/// <summary>
		/// Unity-AssetStore-Originals-Logo-White
		/// </summary>
		public static GUIContent UnityAssetstoreOriginalsLogoWhite => _unityassetstoreoriginalslogowhite ??= EditorGUIUtility.IconContent("Unity-AssetStore-Originals-Logo-White");

		private static GUIContent _unityassetstoreoriginalslogowhite2X;
		/// <summary>
		/// Unity-AssetStore-Originals-Logo-White@2x
		/// </summary>
		public static GUIContent UnityAssetstoreOriginalsLogoWhite2X => _unityassetstoreoriginalslogowhite2X ??= EditorGUIUtility.IconContent("Unity-AssetStore-Originals-Logo-White@2x");

		private static GUIContent _audiomixer;
		/// <summary>
		/// Audio Mixer
		/// </summary>
		public static GUIContent AudioMixer => _audiomixer ??= EditorGUIUtility.IconContent("Audio Mixer");

		private static GUIContent _audiomixer2X;
		/// <summary>
		/// Audio Mixer@2x
		/// </summary>
		public static GUIContent AudioMixer2X => _audiomixer2X ??= EditorGUIUtility.IconContent("Audio Mixer@2x");

		private static GUIContent _autolightbakingoff;
		/// <summary>
		/// AutoLightbakingOff
		/// </summary>
		public static GUIContent Autolightbakingoff => _autolightbakingoff ??= EditorGUIUtility.IconContent("AutoLightbakingOff");

		private static GUIContent _autolightbakingoff2X;
		/// <summary>
		/// AutoLightbakingOff@2x
		/// </summary>
		public static GUIContent Autolightbakingoff2X => _autolightbakingoff2X ??= EditorGUIUtility.IconContent("AutoLightbakingOff@2x");

		private static GUIContent _autolightbakingon;
		/// <summary>
		/// AutoLightbakingOn
		/// </summary>
		public static GUIContent Autolightbakingon => _autolightbakingon ??= EditorGUIUtility.IconContent("AutoLightbakingOn");

		private static GUIContent _autolightbakingon2X;
		/// <summary>
		/// AutoLightbakingOn@2x
		/// </summary>
		public static GUIContent Autolightbakingon2X => _autolightbakingon2X ??= EditorGUIUtility.IconContent("AutoLightbakingOn@2x");

		private static GUIContent _avatarcompass;
		/// <summary>
		/// AvatarCompass
		/// </summary>
		public static GUIContent Avatarcompass => _avatarcompass ??= EditorGUIUtility.IconContent("AvatarCompass");

		private static GUIContent _avatarcontrollerlayer;
		/// <summary>
		/// AvatarController.Layer
		/// </summary>
		public static GUIContent AvatarcontrollerLayer => _avatarcontrollerlayer ??= EditorGUIUtility.IconContent("AvatarController.Layer");

		private static GUIContent _avatarcontrollerlayerhover;
		/// <summary>
		/// AvatarController.LayerHover
		/// </summary>
		public static GUIContent AvatarcontrollerLayerhover => _avatarcontrollerlayerhover ??= EditorGUIUtility.IconContent("AvatarController.LayerHover");

		private static GUIContent _avatarcontrollerlayerselected;
		/// <summary>
		/// AvatarController.LayerSelected
		/// </summary>
		public static GUIContent AvatarcontrollerLayerselected => _avatarcontrollerlayerselected ??= EditorGUIUtility.IconContent("AvatarController.LayerSelected");

		private static GUIContent _bodypartpicker;
		/// <summary>
		/// BodyPartPicker
		/// </summary>
		public static GUIContent Bodypartpicker => _bodypartpicker ??= EditorGUIUtility.IconContent("BodyPartPicker");

		private static GUIContent _bodysilhouette;
		/// <summary>
		/// BodySilhouette
		/// </summary>
		public static GUIContent Bodysilhouette => _bodysilhouette ??= EditorGUIUtility.IconContent("BodySilhouette");

		private static GUIContent _dotfill;
		/// <summary>
		/// DotFill
		/// </summary>
		public static GUIContent Dotfill => _dotfill ??= EditorGUIUtility.IconContent("DotFill");

		private static GUIContent _dotframe;
		/// <summary>
		/// DotFrame
		/// </summary>
		public static GUIContent Dotframe => _dotframe ??= EditorGUIUtility.IconContent("DotFrame");

		private static GUIContent _dotframedotted;
		/// <summary>
		/// DotFrameDotted
		/// </summary>
		public static GUIContent Dotframedotted => _dotframedotted ??= EditorGUIUtility.IconContent("DotFrameDotted");

		private static GUIContent _dotselection;
		/// <summary>
		/// DotSelection
		/// </summary>
		public static GUIContent Dotselection => _dotselection ??= EditorGUIUtility.IconContent("DotSelection");

		private static GUIContent _head;
		/// <summary>
		/// Head
		/// </summary>
		public static GUIContent Head => _head ??= EditorGUIUtility.IconContent("Head");

		private static GUIContent _headik;
		/// <summary>
		/// HeadIk
		/// </summary>
		public static GUIContent Headik => _headik ??= EditorGUIUtility.IconContent("HeadIk");

		private static GUIContent _headzoom;
		/// <summary>
		/// HeadZoom
		/// </summary>
		public static GUIContent Headzoom => _headzoom ??= EditorGUIUtility.IconContent("HeadZoom");

		private static GUIContent _headzoomsilhouette;
		/// <summary>
		/// HeadZoomSilhouette
		/// </summary>
		public static GUIContent Headzoomsilhouette => _headzoomsilhouette ??= EditorGUIUtility.IconContent("HeadZoomSilhouette");

		private static GUIContent _leftarm;
		/// <summary>
		/// LeftArm
		/// </summary>
		public static GUIContent Leftarm => _leftarm ??= EditorGUIUtility.IconContent("LeftArm");

		private static GUIContent _leftfeetik;
		/// <summary>
		/// LeftFeetIk
		/// </summary>
		public static GUIContent Leftfeetik => _leftfeetik ??= EditorGUIUtility.IconContent("LeftFeetIk");

		private static GUIContent _leftfingers;
		/// <summary>
		/// LeftFingers
		/// </summary>
		public static GUIContent Leftfingers => _leftfingers ??= EditorGUIUtility.IconContent("LeftFingers");

		private static GUIContent _leftfingersik;
		/// <summary>
		/// LeftFingersIk
		/// </summary>
		public static GUIContent Leftfingersik => _leftfingersik ??= EditorGUIUtility.IconContent("LeftFingersIk");

		private static GUIContent _lefthandzoom;
		/// <summary>
		/// LeftHandZoom
		/// </summary>
		public static GUIContent Lefthandzoom => _lefthandzoom ??= EditorGUIUtility.IconContent("LeftHandZoom");

		private static GUIContent _lefthandzoomsilhouette;
		/// <summary>
		/// LeftHandZoomSilhouette
		/// </summary>
		public static GUIContent Lefthandzoomsilhouette => _lefthandzoomsilhouette ??= EditorGUIUtility.IconContent("LeftHandZoomSilhouette");

		private static GUIContent _leftleg;
		/// <summary>
		/// LeftLeg
		/// </summary>
		public static GUIContent Leftleg => _leftleg ??= EditorGUIUtility.IconContent("LeftLeg");

		private static GUIContent _maskeditorroot;
		/// <summary>
		/// MaskEditor_Root
		/// </summary>
		public static GUIContent MaskeditorRoot => _maskeditorroot ??= EditorGUIUtility.IconContent("MaskEditor_Root");

		private static GUIContent _rightarm;
		/// <summary>
		/// RightArm
		/// </summary>
		public static GUIContent Rightarm => _rightarm ??= EditorGUIUtility.IconContent("RightArm");

		private static GUIContent _rightfeetik;
		/// <summary>
		/// RightFeetIk
		/// </summary>
		public static GUIContent Rightfeetik => _rightfeetik ??= EditorGUIUtility.IconContent("RightFeetIk");

		private static GUIContent _rightfingers;
		/// <summary>
		/// RightFingers
		/// </summary>
		public static GUIContent Rightfingers => _rightfingers ??= EditorGUIUtility.IconContent("RightFingers");

		private static GUIContent _rightfingersik;
		/// <summary>
		/// RightFingersIk
		/// </summary>
		public static GUIContent Rightfingersik => _rightfingersik ??= EditorGUIUtility.IconContent("RightFingersIk");

		private static GUIContent _righthandzoom;
		/// <summary>
		/// RightHandZoom
		/// </summary>
		public static GUIContent Righthandzoom => _righthandzoom ??= EditorGUIUtility.IconContent("RightHandZoom");

		private static GUIContent _righthandzoomsilhouette;
		/// <summary>
		/// RightHandZoomSilhouette
		/// </summary>
		public static GUIContent Righthandzoomsilhouette => _righthandzoomsilhouette ??= EditorGUIUtility.IconContent("RightHandZoomSilhouette");

		private static GUIContent _rightleg;
		/// <summary>
		/// RightLeg
		/// </summary>
		public static GUIContent Rightleg => _rightleg ??= EditorGUIUtility.IconContent("RightLeg");

		private static GUIContent _torso;
		/// <summary>
		/// Torso
		/// </summary>
		public static GUIContent Torso => _torso ??= EditorGUIUtility.IconContent("Torso");

		private static GUIContent _avatarpivot;
		/// <summary>
		/// AvatarPivot
		/// </summary>
		public static GUIContent Avatarpivot => _avatarpivot ??= EditorGUIUtility.IconContent("AvatarPivot");

		private static GUIContent _avatarpivot2X;
		/// <summary>
		/// AvatarPivot@2x
		/// </summary>
		public static GUIContent Avatarpivot2X => _avatarpivot2X ??= EditorGUIUtility.IconContent("AvatarPivot@2x");

		private static GUIContent _avatarselector;
		/// <summary>
		/// AvatarSelector
		/// </summary>
		public static GUIContent Avatarselector => _avatarselector ??= EditorGUIUtility.IconContent("AvatarSelector");

		private static GUIContent _avatarselector2X;
		/// <summary>
		/// AvatarSelector@2x
		/// </summary>
		public static GUIContent Avatarselector2X => _avatarselector2X ??= EditorGUIUtility.IconContent("AvatarSelector@2x");

		private static GUIContent _back;
		/// <summary>
		/// back
		/// </summary>
		public static GUIContent Back => _back ??= EditorGUIUtility.IconContent("back");

		private static GUIContent _back2X;
		/// <summary>
		/// back@2x
		/// </summary>
		public static GUIContent Back2X => _back2X ??= EditorGUIUtility.IconContent("back@2x");

		private static GUIContent _beginbuttonon;
		/// <summary>
		/// beginButton-On
		/// </summary>
		public static GUIContent BeginbuttonOn => _beginbuttonon ??= EditorGUIUtility.IconContent("beginButton-On");

		private static GUIContent _beginbutton;
		/// <summary>
		/// beginButton
		/// </summary>
		public static GUIContent Beginbutton => _beginbutton ??= EditorGUIUtility.IconContent("beginButton");

		private static GUIContent _blendkey;
		/// <summary>
		/// blendKey
		/// </summary>
		public static GUIContent Blendkey => _blendkey ??= EditorGUIUtility.IconContent("blendKey");

		private static GUIContent _blendkeyoverlay;
		/// <summary>
		/// blendKeyOverlay
		/// </summary>
		public static GUIContent Blendkeyoverlay => _blendkeyoverlay ??= EditorGUIUtility.IconContent("blendKeyOverlay");

		private static GUIContent _blendkeyselected;
		/// <summary>
		/// blendKeySelected
		/// </summary>
		public static GUIContent Blendkeyselected => _blendkeyselected ??= EditorGUIUtility.IconContent("blendKeySelected");

		private static GUIContent _blendsampler;
		/// <summary>
		/// blendSampler
		/// </summary>
		public static GUIContent Blendsampler => _blendsampler ??= EditorGUIUtility.IconContent("blendSampler");

		private static GUIContent _bluegroove;
		/// <summary>
		/// blueGroove
		/// </summary>
		public static GUIContent Bluegroove => _bluegroove ??= EditorGUIUtility.IconContent("blueGroove");

		private static GUIContent _buildsettingsandroidon;
		/// <summary>
		/// BuildSettings.Android On
		/// </summary>
		public static GUIContent BuildsettingsAndroidOn => _buildsettingsandroidon ??= EditorGUIUtility.IconContent("BuildSettings.Android On");

		private static GUIContent _buildsettingsandroidon2X;
		/// <summary>
		/// BuildSettings.Android On@2x
		/// </summary>
		public static GUIContent BuildsettingsAndroidOn2X => _buildsettingsandroidon2X ??= EditorGUIUtility.IconContent("BuildSettings.Android On@2x");

		private static GUIContent _buildsettingsandroid;
		/// <summary>
		/// BuildSettings.Android
		/// </summary>
		public static GUIContent BuildsettingsAndroid => _buildsettingsandroid ??= EditorGUIUtility.IconContent("BuildSettings.Android");

		private static GUIContent _buildsettingsandroidsmall;
		/// <summary>
		/// BuildSettings.Android.Small
		/// </summary>
		public static GUIContent BuildsettingsAndroidSmall => _buildsettingsandroidsmall ??= EditorGUIUtility.IconContent("BuildSettings.Android.Small");

		private static GUIContent _buildsettingsandroidsmall2X;
		/// <summary>
		/// BuildSettings.Android.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsAndroidSmall2X => _buildsettingsandroidsmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Android.Small@2x");

		private static GUIContent _buildsettingsandroid2X;
		/// <summary>
		/// BuildSettings.Android@2x
		/// </summary>
		public static GUIContent BuildsettingsAndroid2X => _buildsettingsandroid2X ??= EditorGUIUtility.IconContent("BuildSettings.Android@2x");

		private static GUIContent _buildsettingsbroadcom;
		/// <summary>
		/// BuildSettings.Broadcom
		/// </summary>
		public static GUIContent BuildsettingsBroadcom => _buildsettingsbroadcom ??= EditorGUIUtility.IconContent("BuildSettings.Broadcom");

		private static GUIContent _buildsettingseditor;
		/// <summary>
		/// BuildSettings.Editor
		/// </summary>
		public static GUIContent BuildsettingsEditor => _buildsettingseditor ??= EditorGUIUtility.IconContent("BuildSettings.Editor");

		private static GUIContent _buildsettingseditorsmall;
		/// <summary>
		/// BuildSettings.Editor.Small
		/// </summary>
		public static GUIContent BuildsettingsEditorSmall => _buildsettingseditorsmall ??= EditorGUIUtility.IconContent("BuildSettings.Editor.Small");

		private static GUIContent _buildsettingsfacebookon;
		/// <summary>
		/// BuildSettings.Facebook On
		/// </summary>
		public static GUIContent BuildsettingsFacebookOn => _buildsettingsfacebookon ??= EditorGUIUtility.IconContent("BuildSettings.Facebook On");

		private static GUIContent _buildsettingsfacebookon2X;
		/// <summary>
		/// BuildSettings.Facebook On@2x
		/// </summary>
		public static GUIContent BuildsettingsFacebookOn2X => _buildsettingsfacebookon2X ??= EditorGUIUtility.IconContent("BuildSettings.Facebook On@2x");

		private static GUIContent _buildsettingsfacebook;
		/// <summary>
		/// BuildSettings.Facebook
		/// </summary>
		public static GUIContent BuildsettingsFacebook => _buildsettingsfacebook ??= EditorGUIUtility.IconContent("BuildSettings.Facebook");

		private static GUIContent _buildsettingsfacebooksmall;
		/// <summary>
		/// BuildSettings.Facebook.Small
		/// </summary>
		public static GUIContent BuildsettingsFacebookSmall => _buildsettingsfacebooksmall ??= EditorGUIUtility.IconContent("BuildSettings.Facebook.Small");

		private static GUIContent _buildsettingsfacebooksmall2X;
		/// <summary>
		/// BuildSettings.Facebook.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsFacebookSmall2X => _buildsettingsfacebooksmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Facebook.Small@2x");

		private static GUIContent _buildsettingsfacebook2X;
		/// <summary>
		/// BuildSettings.Facebook@2x
		/// </summary>
		public static GUIContent BuildsettingsFacebook2X => _buildsettingsfacebook2X ??= EditorGUIUtility.IconContent("BuildSettings.Facebook@2x");

		private static GUIContent _buildsettingsflashplayer;
		/// <summary>
		/// BuildSettings.FlashPlayer
		/// </summary>
		public static GUIContent BuildsettingsFlashplayer => _buildsettingsflashplayer ??= EditorGUIUtility.IconContent("BuildSettings.FlashPlayer");

		private static GUIContent _buildsettingsflashplayersmall;
		/// <summary>
		/// BuildSettings.FlashPlayer.Small
		/// </summary>
		public static GUIContent BuildsettingsFlashplayerSmall => _buildsettingsflashplayersmall ??= EditorGUIUtility.IconContent("BuildSettings.FlashPlayer.Small");

		private static GUIContent _buildsettingsiphoneon;
		/// <summary>
		/// BuildSettings.iPhone On
		/// </summary>
		public static GUIContent BuildsettingsIphoneOn => _buildsettingsiphoneon ??= EditorGUIUtility.IconContent("BuildSettings.iPhone On");

		private static GUIContent _buildsettingsiphoneon2X;
		/// <summary>
		/// BuildSettings.iPhone On@2x
		/// </summary>
		public static GUIContent BuildsettingsIphoneOn2X => _buildsettingsiphoneon2X ??= EditorGUIUtility.IconContent("BuildSettings.iPhone On@2x");

		private static GUIContent _buildsettingsiphone;
		/// <summary>
		/// BuildSettings.iPhone
		/// </summary>
		public static GUIContent BuildsettingsIphone => _buildsettingsiphone ??= EditorGUIUtility.IconContent("BuildSettings.iPhone");

		private static GUIContent _buildsettingsiphonesmall;
		/// <summary>
		/// BuildSettings.iPhone.Small
		/// </summary>
		public static GUIContent BuildsettingsIphoneSmall => _buildsettingsiphonesmall ??= EditorGUIUtility.IconContent("BuildSettings.iPhone.Small");

		private static GUIContent _buildsettingsiphonesmall2X;
		/// <summary>
		/// BuildSettings.iPhone.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsIphoneSmall2X => _buildsettingsiphonesmall2X ??= EditorGUIUtility.IconContent("BuildSettings.iPhone.Small@2x");

		private static GUIContent _buildsettingsiphone2X;
		/// <summary>
		/// BuildSettings.iPhone@2x
		/// </summary>
		public static GUIContent BuildsettingsIphone2X => _buildsettingsiphone2X ??= EditorGUIUtility.IconContent("BuildSettings.iPhone@2x");

		private static GUIContent _buildsettingsluminon;
		/// <summary>
		/// BuildSettings.Lumin On
		/// </summary>
		public static GUIContent BuildsettingsLuminOn => _buildsettingsluminon ??= EditorGUIUtility.IconContent("BuildSettings.Lumin On");

		private static GUIContent _buildsettingsluminon2X;
		/// <summary>
		/// BuildSettings.Lumin On@2x
		/// </summary>
		public static GUIContent BuildsettingsLuminOn2X => _buildsettingsluminon2X ??= EditorGUIUtility.IconContent("BuildSettings.Lumin On@2x");

		private static GUIContent _buildsettingslumin;
		/// <summary>
		/// BuildSettings.Lumin
		/// </summary>
		public static GUIContent BuildsettingsLumin => _buildsettingslumin ??= EditorGUIUtility.IconContent("BuildSettings.Lumin");

		private static GUIContent _buildsettingsluminsmall;
		/// <summary>
		/// BuildSettings.Lumin.small
		/// </summary>
		public static GUIContent BuildsettingsLuminSmall => _buildsettingsluminsmall ??= EditorGUIUtility.IconContent("BuildSettings.Lumin.small");

		private static GUIContent _buildsettingsluminsmall2X;
		/// <summary>
		/// BuildSettings.Lumin.small@2x
		/// </summary>
		public static GUIContent BuildsettingsLuminSmall2X => _buildsettingsluminsmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Lumin.small@2x");

		private static GUIContent _buildsettingslumin2X;
		/// <summary>
		/// BuildSettings.Lumin@2x
		/// </summary>
		public static GUIContent BuildsettingsLumin2X => _buildsettingslumin2X ??= EditorGUIUtility.IconContent("BuildSettings.Lumin@2x");

		private static GUIContent _buildsettingsmetroon;
		/// <summary>
		/// BuildSettings.Metro On
		/// </summary>
		public static GUIContent BuildsettingsMetroOn => _buildsettingsmetroon ??= EditorGUIUtility.IconContent("BuildSettings.Metro On");

		private static GUIContent _buildsettingsmetroon2X;
		/// <summary>
		/// BuildSettings.Metro On@2x
		/// </summary>
		public static GUIContent BuildsettingsMetroOn2X => _buildsettingsmetroon2X ??= EditorGUIUtility.IconContent("BuildSettings.Metro On@2x");

		private static GUIContent _buildsettingsmetro;
		/// <summary>
		/// BuildSettings.Metro
		/// </summary>
		public static GUIContent BuildsettingsMetro => _buildsettingsmetro ??= EditorGUIUtility.IconContent("BuildSettings.Metro");

		private static GUIContent _buildsettingsmetrosmall;
		/// <summary>
		/// BuildSettings.Metro.Small
		/// </summary>
		public static GUIContent BuildsettingsMetroSmall => _buildsettingsmetrosmall ??= EditorGUIUtility.IconContent("BuildSettings.Metro.Small");

		private static GUIContent _buildsettingsmetrosmall2X;
		/// <summary>
		/// BuildSettings.Metro.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsMetroSmall2X => _buildsettingsmetrosmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Metro.Small@2x");

		private static GUIContent _buildsettingsmetro2X;
		/// <summary>
		/// BuildSettings.Metro@2x
		/// </summary>
		public static GUIContent BuildsettingsMetro2X => _buildsettingsmetro2X ??= EditorGUIUtility.IconContent("BuildSettings.Metro@2x");

		private static GUIContent _buildsettingsn3dson;
		/// <summary>
		/// BuildSettings.N3DS On
		/// </summary>
		public static GUIContent BuildsettingsN3dsOn => _buildsettingsn3dson ??= EditorGUIUtility.IconContent("BuildSettings.N3DS On");

		private static GUIContent _buildsettingsn3dson2X;
		/// <summary>
		/// BuildSettings.N3DS On@2x
		/// </summary>
		public static GUIContent BuildsettingsN3dsOn2X => _buildsettingsn3dson2X ??= EditorGUIUtility.IconContent("BuildSettings.N3DS On@2x");

		private static GUIContent _buildsettingsn3ds;
		/// <summary>
		/// BuildSettings.N3DS
		/// </summary>
		public static GUIContent BuildsettingsN3ds => _buildsettingsn3ds ??= EditorGUIUtility.IconContent("BuildSettings.N3DS");

		private static GUIContent _buildsettingsn3dssmall;
		/// <summary>
		/// BuildSettings.N3DS.Small
		/// </summary>
		public static GUIContent BuildsettingsN3dsSmall => _buildsettingsn3dssmall ??= EditorGUIUtility.IconContent("BuildSettings.N3DS.Small");

		private static GUIContent _buildsettingsn3dssmall2X;
		/// <summary>
		/// BuildSettings.N3DS.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsN3dsSmall2X => _buildsettingsn3dssmall2X ??= EditorGUIUtility.IconContent("BuildSettings.N3DS.Small@2x");

		private static GUIContent _buildsettingsn3ds2X;
		/// <summary>
		/// BuildSettings.N3DS@2x
		/// </summary>
		public static GUIContent BuildsettingsN3ds2X => _buildsettingsn3ds2X ??= EditorGUIUtility.IconContent("BuildSettings.N3DS@2x");

		private static GUIContent _buildsettingsps4On;
		/// <summary>
		/// BuildSettings.PS4 On
		/// </summary>
		public static GUIContent BuildsettingsPs4On => _buildsettingsps4On ??= EditorGUIUtility.IconContent("BuildSettings.PS4 On");

		private static GUIContent _buildsettingsps4On2X;
		/// <summary>
		/// BuildSettings.PS4 On@2x
		/// </summary>
		public static GUIContent BuildsettingsPs4On2X => _buildsettingsps4On2X ??= EditorGUIUtility.IconContent("BuildSettings.PS4 On@2x");

		private static GUIContent _buildsettingsps4;
		/// <summary>
		/// BuildSettings.PS4
		/// </summary>
		public static GUIContent BuildsettingsPs4 => _buildsettingsps4 ??= EditorGUIUtility.IconContent("BuildSettings.PS4");

		private static GUIContent _buildsettingsps4Small;
		/// <summary>
		/// BuildSettings.PS4.Small
		/// </summary>
		public static GUIContent BuildsettingsPs4Small => _buildsettingsps4Small ??= EditorGUIUtility.IconContent("BuildSettings.PS4.Small");

		private static GUIContent _buildsettingsps4Small2X;
		/// <summary>
		/// BuildSettings.PS4.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsPs4Small2X => _buildsettingsps4Small2X ??= EditorGUIUtility.IconContent("BuildSettings.PS4.Small@2x");

		private static GUIContent _buildsettingsps42X;
		/// <summary>
		/// BuildSettings.PS4@2x
		/// </summary>
		public static GUIContent BuildsettingsPs42X => _buildsettingsps42X ??= EditorGUIUtility.IconContent("BuildSettings.PS4@2x");

		private static GUIContent _buildsettingspsm;
		/// <summary>
		/// BuildSettings.PSM
		/// </summary>
		public static GUIContent BuildsettingsPsm => _buildsettingspsm ??= EditorGUIUtility.IconContent("BuildSettings.PSM");

		private static GUIContent _buildsettingspsmsmall;
		/// <summary>
		/// BuildSettings.PSM.Small
		/// </summary>
		public static GUIContent BuildsettingsPsmSmall => _buildsettingspsmsmall ??= EditorGUIUtility.IconContent("BuildSettings.PSM.Small");

		private static GUIContent _buildsettingspsp2;
		/// <summary>
		/// BuildSettings.PSP2
		/// </summary>
		public static GUIContent BuildsettingsPsp2 => _buildsettingspsp2 ??= EditorGUIUtility.IconContent("BuildSettings.PSP2");

		private static GUIContent _buildsettingspsp2Small;
		/// <summary>
		/// BuildSettings.PSP2.Small
		/// </summary>
		public static GUIContent BuildsettingsPsp2Small => _buildsettingspsp2Small ??= EditorGUIUtility.IconContent("BuildSettings.PSP2.Small");

		private static GUIContent _buildsettingsselectedicon;
		/// <summary>
		/// BuildSettings.SelectedIcon
		/// </summary>
		public static GUIContent BuildsettingsSelectedicon => _buildsettingsselectedicon ??= EditorGUIUtility.IconContent("BuildSettings.SelectedIcon");

		private static GUIContent _buildsettingsstadiaon;
		/// <summary>
		/// BuildSettings.Stadia On
		/// </summary>
		public static GUIContent BuildsettingsStadiaOn => _buildsettingsstadiaon ??= EditorGUIUtility.IconContent("BuildSettings.Stadia On");

		private static GUIContent _buildsettingsstadiaon2X;
		/// <summary>
		/// BuildSettings.Stadia On@2x
		/// </summary>
		public static GUIContent BuildsettingsStadiaOn2X => _buildsettingsstadiaon2X ??= EditorGUIUtility.IconContent("BuildSettings.Stadia On@2x");

		private static GUIContent _buildsettingsstadia;
		/// <summary>
		/// BuildSettings.Stadia
		/// </summary>
		public static GUIContent BuildsettingsStadia => _buildsettingsstadia ??= EditorGUIUtility.IconContent("BuildSettings.Stadia");

		private static GUIContent _buildsettingsstadiasmall;
		/// <summary>
		/// BuildSettings.Stadia.small
		/// </summary>
		public static GUIContent BuildsettingsStadiaSmall => _buildsettingsstadiasmall ??= EditorGUIUtility.IconContent("BuildSettings.Stadia.small");

		private static GUIContent _buildsettingsstadiasmall2X;
		/// <summary>
		/// BuildSettings.Stadia.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsStadiaSmall2X => _buildsettingsstadiasmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Stadia.Small@2x");

		private static GUIContent _buildsettingsstadia2X;
		/// <summary>
		/// BuildSettings.Stadia@2x
		/// </summary>
		public static GUIContent BuildsettingsStadia2X => _buildsettingsstadia2X ??= EditorGUIUtility.IconContent("BuildSettings.Stadia@2x");

		private static GUIContent _buildsettingsstandaloneon;
		/// <summary>
		/// BuildSettings.Standalone On
		/// </summary>
		public static GUIContent BuildsettingsStandaloneOn => _buildsettingsstandaloneon ??= EditorGUIUtility.IconContent("BuildSettings.Standalone On");

		private static GUIContent _buildsettingsstandaloneon2X;
		/// <summary>
		/// BuildSettings.Standalone On@2x
		/// </summary>
		public static GUIContent BuildsettingsStandaloneOn2X => _buildsettingsstandaloneon2X ??= EditorGUIUtility.IconContent("BuildSettings.Standalone On@2x");

		private static GUIContent _buildsettingsstandalone;
		/// <summary>
		/// BuildSettings.Standalone
		/// </summary>
		public static GUIContent BuildsettingsStandalone => _buildsettingsstandalone ??= EditorGUIUtility.IconContent("BuildSettings.Standalone");

		private static GUIContent _buildsettingsstandalonesmall;
		/// <summary>
		/// BuildSettings.Standalone.Small
		/// </summary>
		public static GUIContent BuildsettingsStandaloneSmall => _buildsettingsstandalonesmall ??= EditorGUIUtility.IconContent("BuildSettings.Standalone.Small");

		private static GUIContent _buildsettingsstandalonesmall2X;
		/// <summary>
		/// BuildSettings.Standalone.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsStandaloneSmall2X => _buildsettingsstandalonesmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Standalone.Small@2x");

		private static GUIContent _buildsettingsstandalone2X;
		/// <summary>
		/// BuildSettings.Standalone@2x
		/// </summary>
		public static GUIContent BuildsettingsStandalone2X => _buildsettingsstandalone2X ??= EditorGUIUtility.IconContent("BuildSettings.Standalone@2x");

		private static GUIContent _buildsettingsstandalonebroadcomsmall;
		/// <summary>
		/// BuildSettings.StandaloneBroadcom.Small
		/// </summary>
		public static GUIContent BuildsettingsStandalonebroadcomSmall => _buildsettingsstandalonebroadcomsmall ??= EditorGUIUtility.IconContent("BuildSettings.StandaloneBroadcom.Small");

		private static GUIContent _buildsettingsstandalonegles20Emusmall;
		/// <summary>
		/// BuildSettings.StandaloneGLES20Emu.Small
		/// </summary>
		public static GUIContent BuildsettingsStandalonegles20EmuSmall => _buildsettingsstandalonegles20Emusmall ??= EditorGUIUtility.IconContent("BuildSettings.StandaloneGLES20Emu.Small");

		private static GUIContent _buildsettingsstandaloneglesemu;
		/// <summary>
		/// BuildSettings.StandaloneGLESEmu
		/// </summary>
		public static GUIContent BuildsettingsStandaloneglesemu => _buildsettingsstandaloneglesemu ??= EditorGUIUtility.IconContent("BuildSettings.StandaloneGLESEmu");

		private static GUIContent _buildsettingsstandaloneglesemusmall;
		/// <summary>
		/// BuildSettings.StandaloneGLESEmu.Small
		/// </summary>
		public static GUIContent BuildsettingsStandaloneglesemuSmall => _buildsettingsstandaloneglesemusmall ??= EditorGUIUtility.IconContent("BuildSettings.StandaloneGLESEmu.Small");

		private static GUIContent _buildsettingsswitchon;
		/// <summary>
		/// BuildSettings.Switch On
		/// </summary>
		public static GUIContent BuildsettingsSwitchOn => _buildsettingsswitchon ??= EditorGUIUtility.IconContent("BuildSettings.Switch On");

		private static GUIContent _buildsettingsswitchon2X;
		/// <summary>
		/// BuildSettings.Switch On@2x
		/// </summary>
		public static GUIContent BuildsettingsSwitchOn2X => _buildsettingsswitchon2X ??= EditorGUIUtility.IconContent("BuildSettings.Switch On@2x");

		private static GUIContent _buildsettingsswitch;
		/// <summary>
		/// BuildSettings.Switch
		/// </summary>
		public static GUIContent BuildsettingsSwitch => _buildsettingsswitch ??= EditorGUIUtility.IconContent("BuildSettings.Switch");

		private static GUIContent _buildsettingsswitchsmall;
		/// <summary>
		/// BuildSettings.Switch.Small
		/// </summary>
		public static GUIContent BuildsettingsSwitchSmall => _buildsettingsswitchsmall ??= EditorGUIUtility.IconContent("BuildSettings.Switch.Small");

		private static GUIContent _buildsettingsswitchsmall2X;
		/// <summary>
		/// BuildSettings.Switch.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsSwitchSmall2X => _buildsettingsswitchsmall2X ??= EditorGUIUtility.IconContent("BuildSettings.Switch.Small@2x");

		private static GUIContent _buildsettingsswitch2X;
		/// <summary>
		/// BuildSettings.Switch@2x
		/// </summary>
		public static GUIContent BuildsettingsSwitch2X => _buildsettingsswitch2X ??= EditorGUIUtility.IconContent("BuildSettings.Switch@2x");

		private static GUIContent _buildsettingstvoson;
		/// <summary>
		/// BuildSettings.tvOS On
		/// </summary>
		public static GUIContent BuildsettingsTvosOn => _buildsettingstvoson ??= EditorGUIUtility.IconContent("BuildSettings.tvOS On");

		private static GUIContent _buildsettingstvoson2X;
		/// <summary>
		/// BuildSettings.tvOS On@2x
		/// </summary>
		public static GUIContent BuildsettingsTvosOn2X => _buildsettingstvoson2X ??= EditorGUIUtility.IconContent("BuildSettings.tvOS On@2x");

		private static GUIContent _buildsettingstvos;
		/// <summary>
		/// BuildSettings.tvOS
		/// </summary>
		public static GUIContent BuildsettingsTvos => _buildsettingstvos ??= EditorGUIUtility.IconContent("BuildSettings.tvOS");

		private static GUIContent _buildsettingstvossmall;
		/// <summary>
		/// BuildSettings.tvOS.Small
		/// </summary>
		public static GUIContent BuildsettingsTvosSmall => _buildsettingstvossmall ??= EditorGUIUtility.IconContent("BuildSettings.tvOS.Small");

		private static GUIContent _buildsettingstvossmall2X;
		/// <summary>
		/// BuildSettings.tvOS.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsTvosSmall2X => _buildsettingstvossmall2X ??= EditorGUIUtility.IconContent("BuildSettings.tvOS.Small@2x");

		private static GUIContent _buildsettingstvos2X;
		/// <summary>
		/// BuildSettings.tvOS@2x
		/// </summary>
		public static GUIContent BuildsettingsTvos2X => _buildsettingstvos2X ??= EditorGUIUtility.IconContent("BuildSettings.tvOS@2x");

		private static GUIContent _buildsettingsweb;
		/// <summary>
		/// BuildSettings.Web
		/// </summary>
		public static GUIContent BuildsettingsWeb => _buildsettingsweb ??= EditorGUIUtility.IconContent("BuildSettings.Web");

		private static GUIContent _buildsettingswebsmall;
		/// <summary>
		/// BuildSettings.Web.Small
		/// </summary>
		public static GUIContent BuildsettingsWebSmall => _buildsettingswebsmall ??= EditorGUIUtility.IconContent("BuildSettings.Web.Small");

		private static GUIContent _buildsettingswebglon;
		/// <summary>
		/// BuildSettings.WebGL On
		/// </summary>
		public static GUIContent BuildsettingsWebglOn => _buildsettingswebglon ??= EditorGUIUtility.IconContent("BuildSettings.WebGL On");

		private static GUIContent _buildsettingswebglon2X;
		/// <summary>
		/// BuildSettings.WebGL On@2x
		/// </summary>
		public static GUIContent BuildsettingsWebglOn2X => _buildsettingswebglon2X ??= EditorGUIUtility.IconContent("BuildSettings.WebGL On@2x");

		private static GUIContent _buildsettingswebgl;
		/// <summary>
		/// BuildSettings.WebGL
		/// </summary>
		public static GUIContent BuildsettingsWebgl => _buildsettingswebgl ??= EditorGUIUtility.IconContent("BuildSettings.WebGL");

		private static GUIContent _buildsettingswebglsmall;
		/// <summary>
		/// BuildSettings.WebGL.Small
		/// </summary>
		public static GUIContent BuildsettingsWebglSmall => _buildsettingswebglsmall ??= EditorGUIUtility.IconContent("BuildSettings.WebGL.Small");

		private static GUIContent _buildsettingswebglsmall2X;
		/// <summary>
		/// BuildSettings.WebGL.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsWebglSmall2X => _buildsettingswebglsmall2X ??= EditorGUIUtility.IconContent("BuildSettings.WebGL.Small@2x");

		private static GUIContent _buildsettingswebgl2X;
		/// <summary>
		/// BuildSettings.WebGL@2x
		/// </summary>
		public static GUIContent BuildsettingsWebgl2X => _buildsettingswebgl2X ??= EditorGUIUtility.IconContent("BuildSettings.WebGL@2x");

		private static GUIContent _buildsettingswp8;
		/// <summary>
		/// BuildSettings.WP8
		/// </summary>
		public static GUIContent BuildsettingsWp8 => _buildsettingswp8 ??= EditorGUIUtility.IconContent("BuildSettings.WP8");

		private static GUIContent _buildsettingswp8Small;
		/// <summary>
		/// BuildSettings.WP8.Small
		/// </summary>
		public static GUIContent BuildsettingsWp8Small => _buildsettingswp8Small ??= EditorGUIUtility.IconContent("BuildSettings.WP8.Small");

		private static GUIContent _buildsettingsxbox360;
		/// <summary>
		/// BuildSettings.Xbox360
		/// </summary>
		public static GUIContent BuildsettingsXbox360 => _buildsettingsxbox360 ??= EditorGUIUtility.IconContent("BuildSettings.Xbox360");

		private static GUIContent _buildsettingsxbox360Small;
		/// <summary>
		/// BuildSettings.Xbox360.Small
		/// </summary>
		public static GUIContent BuildsettingsXbox360Small => _buildsettingsxbox360Small ??= EditorGUIUtility.IconContent("BuildSettings.Xbox360.Small");

		private static GUIContent _buildsettingsxboxoneon;
		/// <summary>
		/// BuildSettings.XboxOne On
		/// </summary>
		public static GUIContent BuildsettingsXboxoneOn => _buildsettingsxboxoneon ??= EditorGUIUtility.IconContent("BuildSettings.XboxOne On");

		private static GUIContent _buildsettingsxboxoneon2X;
		/// <summary>
		/// BuildSettings.XboxOne On@2x
		/// </summary>
		public static GUIContent BuildsettingsXboxoneOn2X => _buildsettingsxboxoneon2X ??= EditorGUIUtility.IconContent("BuildSettings.XboxOne On@2x");

		private static GUIContent _buildsettingsxboxone;
		/// <summary>
		/// BuildSettings.XboxOne
		/// </summary>
		public static GUIContent BuildsettingsXboxone => _buildsettingsxboxone ??= EditorGUIUtility.IconContent("BuildSettings.XboxOne");

		private static GUIContent _buildsettingsxboxonesmall;
		/// <summary>
		/// BuildSettings.XboxOne.Small
		/// </summary>
		public static GUIContent BuildsettingsXboxoneSmall => _buildsettingsxboxonesmall ??= EditorGUIUtility.IconContent("BuildSettings.XboxOne.Small");

		private static GUIContent _buildsettingsxboxonesmall2X;
		/// <summary>
		/// BuildSettings.XboxOne.Small@2x
		/// </summary>
		public static GUIContent BuildsettingsXboxoneSmall2X => _buildsettingsxboxonesmall2X ??= EditorGUIUtility.IconContent("BuildSettings.XboxOne.Small@2x");

		private static GUIContent _buildsettingsxboxone2X;
		/// <summary>
		/// BuildSettings.XboxOne@2x
		/// </summary>
		public static GUIContent BuildsettingsXboxone2X => _buildsettingsxboxone2X ??= EditorGUIUtility.IconContent("BuildSettings.XboxOne@2x");

		private static GUIContent _cacheserverconnected;
		/// <summary>
		/// CacheServerConnected
		/// </summary>
		public static GUIContent Cacheserverconnected => _cacheserverconnected ??= EditorGUIUtility.IconContent("CacheServerConnected");

		private static GUIContent _cacheserverconnected2X;
		/// <summary>
		/// CacheServerConnected@2x
		/// </summary>
		public static GUIContent Cacheserverconnected2X => _cacheserverconnected2X ??= EditorGUIUtility.IconContent("CacheServerConnected@2x");

		private static GUIContent _cacheserverdisabled;
		/// <summary>
		/// CacheServerDisabled
		/// </summary>
		public static GUIContent Cacheserverdisabled => _cacheserverdisabled ??= EditorGUIUtility.IconContent("CacheServerDisabled");

		private static GUIContent _cacheserverdisabled2X;
		/// <summary>
		/// CacheServerDisabled@2x
		/// </summary>
		public static GUIContent Cacheserverdisabled2X => _cacheserverdisabled2X ??= EditorGUIUtility.IconContent("CacheServerDisabled@2x");

		private static GUIContent _cacheserverdisconnected;
		/// <summary>
		/// CacheServerDisconnected
		/// </summary>
		public static GUIContent Cacheserverdisconnected => _cacheserverdisconnected ??= EditorGUIUtility.IconContent("CacheServerDisconnected");

		private static GUIContent _cacheserverdisconnected2X;
		/// <summary>
		/// CacheServerDisconnected@2x
		/// </summary>
		public static GUIContent Cacheserverdisconnected2X => _cacheserverdisconnected2X ??= EditorGUIUtility.IconContent("CacheServerDisconnected@2x");

		private static GUIContent _checkerfloor;
		/// <summary>
		/// CheckerFloor
		/// </summary>
		public static GUIContent Checkerfloor => _checkerfloor ??= EditorGUIUtility.IconContent("CheckerFloor");

		private static GUIContent _clipboard;
		/// <summary>
		/// Clipboard
		/// </summary>
		public static GUIContent Clipboard => _clipboard ??= EditorGUIUtility.IconContent("Clipboard");

		private static GUIContent _clothinspectorpainttool;
		/// <summary>
		/// ClothInspector.PaintTool
		/// </summary>
		public static GUIContent ClothinspectorPainttool => _clothinspectorpainttool ??= EditorGUIUtility.IconContent("ClothInspector.PaintTool");

		private static GUIContent _clothinspectorpaintvalue;
		/// <summary>
		/// ClothInspector.PaintValue
		/// </summary>
		public static GUIContent ClothinspectorPaintvalue => _clothinspectorpaintvalue ??= EditorGUIUtility.IconContent("ClothInspector.PaintValue");

		private static GUIContent _clothinspectorselecttool;
		/// <summary>
		/// ClothInspector.SelectTool
		/// </summary>
		public static GUIContent ClothinspectorSelecttool => _clothinspectorselecttool ??= EditorGUIUtility.IconContent("ClothInspector.SelectTool");

		private static GUIContent _clothinspectorsettingstool;
		/// <summary>
		/// ClothInspector.SettingsTool
		/// </summary>
		public static GUIContent ClothinspectorSettingstool => _clothinspectorsettingstool ??= EditorGUIUtility.IconContent("ClothInspector.SettingsTool");

		private static GUIContent _clothinspectorviewvalue;
		/// <summary>
		/// ClothInspector.ViewValue
		/// </summary>
		public static GUIContent ClothinspectorViewvalue => _clothinspectorviewvalue ??= EditorGUIUtility.IconContent("ClothInspector.ViewValue");

		private static GUIContent _cloudconnect;
		/// <summary>
		/// CloudConnect
		/// </summary>
		public static GUIContent Cloudconnect => _cloudconnect ??= EditorGUIUtility.IconContent("CloudConnect");

		private static GUIContent _cloudconnect2X;
		/// <summary>
		/// CloudConnect@2x
		/// </summary>
		public static GUIContent Cloudconnect2X => _cloudconnect2X ??= EditorGUIUtility.IconContent("CloudConnect@2x");

		private static GUIContent _collabbuild;
		/// <summary>
		/// Collab.Build
		/// </summary>
		public static GUIContent CollabBuild => _collabbuild ??= EditorGUIUtility.IconContent("Collab.Build");

		private static GUIContent _collabbuildfailed;
		/// <summary>
		/// Collab.BuildFailed
		/// </summary>
		public static GUIContent CollabBuildfailed => _collabbuildfailed ??= EditorGUIUtility.IconContent("Collab.BuildFailed");

		private static GUIContent _collabbuildsucceeded;
		/// <summary>
		/// Collab.BuildSucceeded
		/// </summary>
		public static GUIContent CollabBuildsucceeded => _collabbuildsucceeded ??= EditorGUIUtility.IconContent("Collab.BuildSucceeded");

		private static GUIContent _collabfileadded;
		/// <summary>
		/// Collab.FileAdded
		/// </summary>
		public static GUIContent CollabFileadded => _collabfileadded ??= EditorGUIUtility.IconContent("Collab.FileAdded");

		private static GUIContent _collabfileconflict;
		/// <summary>
		/// Collab.FileConflict
		/// </summary>
		public static GUIContent CollabFileconflict => _collabfileconflict ??= EditorGUIUtility.IconContent("Collab.FileConflict");

		private static GUIContent _collabfiledeleted;
		/// <summary>
		/// Collab.FileDeleted
		/// </summary>
		public static GUIContent CollabFiledeleted => _collabfiledeleted ??= EditorGUIUtility.IconContent("Collab.FileDeleted");

		private static GUIContent _collabfileignored;
		/// <summary>
		/// Collab.FileIgnored
		/// </summary>
		public static GUIContent CollabFileignored => _collabfileignored ??= EditorGUIUtility.IconContent("Collab.FileIgnored");

		private static GUIContent _collabfilemoved;
		/// <summary>
		/// Collab.FileMoved
		/// </summary>
		public static GUIContent CollabFilemoved => _collabfilemoved ??= EditorGUIUtility.IconContent("Collab.FileMoved");

		private static GUIContent _collabfileupdated;
		/// <summary>
		/// Collab.FileUpdated
		/// </summary>
		public static GUIContent CollabFileupdated => _collabfileupdated ??= EditorGUIUtility.IconContent("Collab.FileUpdated");

		private static GUIContent _collabfolderadded;
		/// <summary>
		/// Collab.FolderAdded
		/// </summary>
		public static GUIContent CollabFolderadded => _collabfolderadded ??= EditorGUIUtility.IconContent("Collab.FolderAdded");

		private static GUIContent _collabfolderconflict;
		/// <summary>
		/// Collab.FolderConflict
		/// </summary>
		public static GUIContent CollabFolderconflict => _collabfolderconflict ??= EditorGUIUtility.IconContent("Collab.FolderConflict");

		private static GUIContent _collabfolderdeleted;
		/// <summary>
		/// Collab.FolderDeleted
		/// </summary>
		public static GUIContent CollabFolderdeleted => _collabfolderdeleted ??= EditorGUIUtility.IconContent("Collab.FolderDeleted");

		private static GUIContent _collabfolderignored;
		/// <summary>
		/// Collab.FolderIgnored
		/// </summary>
		public static GUIContent CollabFolderignored => _collabfolderignored ??= EditorGUIUtility.IconContent("Collab.FolderIgnored");

		private static GUIContent _collabfoldermoved;
		/// <summary>
		/// Collab.FolderMoved
		/// </summary>
		public static GUIContent CollabFoldermoved => _collabfoldermoved ??= EditorGUIUtility.IconContent("Collab.FolderMoved");

		private static GUIContent _collabfolderupdated;
		/// <summary>
		/// Collab.FolderUpdated
		/// </summary>
		public static GUIContent CollabFolderupdated => _collabfolderupdated ??= EditorGUIUtility.IconContent("Collab.FolderUpdated");

		private static GUIContent _collabnointernet;
		/// <summary>
		/// Collab.NoInternet
		/// </summary>
		public static GUIContent CollabNointernet => _collabnointernet ??= EditorGUIUtility.IconContent("Collab.NoInternet");

		private static GUIContent _collab;
		/// <summary>
		/// Collab
		/// </summary>
		public static GUIContent Collab => _collab ??= EditorGUIUtility.IconContent("Collab");

		private static GUIContent _collabwarning;
		/// <summary>
		/// Collab.Warning
		/// </summary>
		public static GUIContent CollabWarning => _collabwarning ??= EditorGUIUtility.IconContent("Collab.Warning");

		private static GUIContent _collab2X;
		/// <summary>
		/// Collab@2x
		/// </summary>
		public static GUIContent Collab2X => _collab2X ??= EditorGUIUtility.IconContent("Collab@2x");

		private static GUIContent _collabconflict;
		/// <summary>
		/// CollabConflict
		/// </summary>
		public static GUIContent Collabconflict => _collabconflict ??= EditorGUIUtility.IconContent("CollabConflict");

		private static GUIContent _collaberror;
		/// <summary>
		/// CollabError
		/// </summary>
		public static GUIContent Collaberror => _collaberror ??= EditorGUIUtility.IconContent("CollabError");

		private static GUIContent _collabnew;
		/// <summary>
		/// CollabNew
		/// </summary>
		public static GUIContent Collabnew => _collabnew ??= EditorGUIUtility.IconContent("CollabNew");

		private static GUIContent _collaboffline;
		/// <summary>
		/// CollabOffline
		/// </summary>
		public static GUIContent Collaboffline => _collaboffline ??= EditorGUIUtility.IconContent("CollabOffline");

		private static GUIContent _collabprogress;
		/// <summary>
		/// CollabProgress
		/// </summary>
		public static GUIContent Collabprogress => _collabprogress ??= EditorGUIUtility.IconContent("CollabProgress");

		private static GUIContent _collabpull;
		/// <summary>
		/// CollabPull
		/// </summary>
		public static GUIContent Collabpull => _collabpull ??= EditorGUIUtility.IconContent("CollabPull");

		private static GUIContent _collabpush;
		/// <summary>
		/// CollabPush
		/// </summary>
		public static GUIContent Collabpush => _collabpush ??= EditorGUIUtility.IconContent("CollabPush");

		private static GUIContent _colorpickercolorcycle;
		/// <summary>
		/// ColorPicker.ColorCycle
		/// </summary>
		public static GUIContent ColorpickerColorcycle => _colorpickercolorcycle ??= EditorGUIUtility.IconContent("ColorPicker.ColorCycle");

		private static GUIContent _colorpickercyclecolor;
		/// <summary>
		/// ColorPicker.CycleColor
		/// </summary>
		public static GUIContent ColorpickerCyclecolor => _colorpickercyclecolor ??= EditorGUIUtility.IconContent("ColorPicker.CycleColor");

		private static GUIContent _colorpickercycleslider;
		/// <summary>
		/// ColorPicker.CycleSlider
		/// </summary>
		public static GUIContent ColorpickerCycleslider => _colorpickercycleslider ??= EditorGUIUtility.IconContent("ColorPicker.CycleSlider");

		private static GUIContent _colorpickerslidercycle;
		/// <summary>
		/// ColorPicker.SliderCycle
		/// </summary>
		public static GUIContent ColorpickerSlidercycle => _colorpickerslidercycle ??= EditorGUIUtility.IconContent("ColorPicker.SliderCycle");

		private static GUIContent _consoleerroriconinactivesml;
		/// <summary>
		/// console.erroricon.inactive.sml
		/// </summary>
		public static GUIContent ConsoleErroriconInactiveSml => _consoleerroriconinactivesml ??= EditorGUIUtility.IconContent("console.erroricon.inactive.sml");

		private static GUIContent _consoleerroriconinactivesml2X;
		/// <summary>
		/// console.erroricon.inactive.sml@2x
		/// </summary>
		public static GUIContent ConsoleErroriconInactiveSml2X => _consoleerroriconinactivesml2X ??= EditorGUIUtility.IconContent("console.erroricon.inactive.sml@2x");

		private static GUIContent _consoleerroricon;
		/// <summary>
		/// console.erroricon
		/// </summary>
		public static GUIContent ConsoleErroricon => _consoleerroricon ??= EditorGUIUtility.IconContent("console.erroricon");

		private static GUIContent _consoleerroriconsml;
		/// <summary>
		/// console.erroricon.sml
		/// </summary>
		public static GUIContent ConsoleErroriconSml => _consoleerroriconsml ??= EditorGUIUtility.IconContent("console.erroricon.sml");

		private static GUIContent _consoleerroriconsml2X;
		/// <summary>
		/// console.erroricon.sml@2x
		/// </summary>
		public static GUIContent ConsoleErroriconSml2X => _consoleerroriconsml2X ??= EditorGUIUtility.IconContent("console.erroricon.sml@2x");

		private static GUIContent _consoleerroricon2X;
		/// <summary>
		/// console.erroricon@2x
		/// </summary>
		public static GUIContent ConsoleErroricon2X => _consoleerroricon2X ??= EditorGUIUtility.IconContent("console.erroricon@2x");

		private static GUIContent _consoleinfoiconinactivesml;
		/// <summary>
		/// console.infoicon.inactive.sml
		/// </summary>
		public static GUIContent ConsoleInfoiconInactiveSml => _consoleinfoiconinactivesml ??= EditorGUIUtility.IconContent("console.infoicon.inactive.sml");

		private static GUIContent _consoleinfoiconinactivesml2X;
		/// <summary>
		/// console.infoicon.inactive.sml@2x
		/// </summary>
		public static GUIContent ConsoleInfoiconInactiveSml2X => _consoleinfoiconinactivesml2X ??= EditorGUIUtility.IconContent("console.infoicon.inactive.sml@2x");

		private static GUIContent _consoleinfoicon;
		/// <summary>
		/// console.infoicon
		/// </summary>
		public static GUIContent ConsoleInfoicon => _consoleinfoicon ??= EditorGUIUtility.IconContent("console.infoicon");

		private static GUIContent _consoleinfoiconsml;
		/// <summary>
		/// console.infoicon.sml
		/// </summary>
		public static GUIContent ConsoleInfoiconSml => _consoleinfoiconsml ??= EditorGUIUtility.IconContent("console.infoicon.sml");

		private static GUIContent _consoleinfoiconsml2X;
		/// <summary>
		/// console.infoicon.sml@2x
		/// </summary>
		public static GUIContent ConsoleInfoiconSml2X => _consoleinfoiconsml2X ??= EditorGUIUtility.IconContent("console.infoicon.sml@2x");

		private static GUIContent _consoleinfoicon2X;
		/// <summary>
		/// console.infoicon@2x
		/// </summary>
		public static GUIContent ConsoleInfoicon2X => _consoleinfoicon2X ??= EditorGUIUtility.IconContent("console.infoicon@2x");

		private static GUIContent _consolewarniconinactivesml;
		/// <summary>
		/// console.warnicon.inactive.sml
		/// </summary>
		public static GUIContent ConsoleWarniconInactiveSml => _consolewarniconinactivesml ??= EditorGUIUtility.IconContent("console.warnicon.inactive.sml");

		private static GUIContent _consolewarniconinactivesml2X;
		/// <summary>
		/// console.warnicon.inactive.sml@2x
		/// </summary>
		public static GUIContent ConsoleWarniconInactiveSml2X => _consolewarniconinactivesml2X ??= EditorGUIUtility.IconContent("console.warnicon.inactive.sml@2x");

		private static GUIContent _consolewarnicon;
		/// <summary>
		/// console.warnicon
		/// </summary>
		public static GUIContent ConsoleWarnicon => _consolewarnicon ??= EditorGUIUtility.IconContent("console.warnicon");

		private static GUIContent _consolewarniconsml;
		/// <summary>
		/// console.warnicon.sml
		/// </summary>
		public static GUIContent ConsoleWarniconSml => _consolewarniconsml ??= EditorGUIUtility.IconContent("console.warnicon.sml");

		private static GUIContent _consolewarniconsml2X;
		/// <summary>
		/// console.warnicon.sml@2x
		/// </summary>
		public static GUIContent ConsoleWarniconSml2X => _consolewarniconsml2X ??= EditorGUIUtility.IconContent("console.warnicon.sml@2x");

		private static GUIContent _consolewarnicon2X;
		/// <summary>
		/// console.warnicon@2x
		/// </summary>
		public static GUIContent ConsoleWarnicon2X => _consolewarnicon2X ??= EditorGUIUtility.IconContent("console.warnicon@2x");

		private static GUIContent _createaddnew;
		/// <summary>
		/// CreateAddNew
		/// </summary>
		public static GUIContent Createaddnew => _createaddnew ??= EditorGUIUtility.IconContent("CreateAddNew");

		private static GUIContent _createaddnew2X;
		/// <summary>
		/// CreateAddNew@2x
		/// </summary>
		public static GUIContent Createaddnew2X => _createaddnew2X ??= EditorGUIUtility.IconContent("CreateAddNew@2x");

		private static GUIContent _crossicon;
		/// <summary>
		/// CrossIcon
		/// </summary>
		public static GUIContent Crossicon => _crossicon ??= EditorGUIUtility.IconContent("CrossIcon");

		private static GUIContent _curvekeyframe;
		/// <summary>
		/// curvekeyframe
		/// </summary>
		public static GUIContent Curvekeyframe => _curvekeyframe ??= EditorGUIUtility.IconContent("curvekeyframe");

		private static GUIContent _curvekeyframeselected;
		/// <summary>
		/// curvekeyframeselected
		/// </summary>
		public static GUIContent Curvekeyframeselected => _curvekeyframeselected ??= EditorGUIUtility.IconContent("curvekeyframeselected");

		private static GUIContent _curvekeyframeselectedoverlay;
		/// <summary>
		/// curvekeyframeselectedoverlay
		/// </summary>
		public static GUIContent Curvekeyframeselectedoverlay => _curvekeyframeselectedoverlay ??= EditorGUIUtility.IconContent("curvekeyframeselectedoverlay");

		private static GUIContent _curvekeyframesemiselectedoverlay;
		/// <summary>
		/// curvekeyframesemiselectedoverlay
		/// </summary>
		public static GUIContent Curvekeyframesemiselectedoverlay => _curvekeyframesemiselectedoverlay ??= EditorGUIUtility.IconContent("curvekeyframesemiselectedoverlay");

		private static GUIContent _curvekeyframeweighted;
		/// <summary>
		/// curvekeyframeweighted
		/// </summary>
		public static GUIContent Curvekeyframeweighted => _curvekeyframeweighted ??= EditorGUIUtility.IconContent("curvekeyframeweighted");

		private static GUIContent _customsorting;
		/// <summary>
		/// CustomSorting
		/// </summary>
		public static GUIContent Customsorting => _customsorting ??= EditorGUIUtility.IconContent("CustomSorting");

		private static GUIContent _customtool;
		/// <summary>
		/// CustomTool
		/// </summary>
		public static GUIContent Customtool => _customtool ??= EditorGUIUtility.IconContent("CustomTool");

		private static GUIContent _customtool2X;
		/// <summary>
		/// CustomTool@2x
		/// </summary>
		public static GUIContent Customtool2X => _customtool2X ??= EditorGUIUtility.IconContent("CustomTool@2x");

		private static GUIContent _dhelp;
		/// <summary>
		/// d__Help
		/// </summary>
		public static GUIContent DHelp => _dhelp ??= EditorGUIUtility.IconContent("d__Help");

		private static GUIContent _dhelp2X;
		/// <summary>
		/// d__Help@2x
		/// </summary>
		public static GUIContent DHelp2X => _dhelp2X ??= EditorGUIUtility.IconContent("d__Help@2x");

		private static GUIContent _dmenu;
		/// <summary>
		/// d__Menu
		/// </summary>
		public static GUIContent DMenu => _dmenu ??= EditorGUIUtility.IconContent("d__Menu");

		private static GUIContent _dmenu2X;
		/// <summary>
		/// d__Menu@2x
		/// </summary>
		public static GUIContent DMenu2X => _dmenu2X ??= EditorGUIUtility.IconContent("d__Menu@2x");

		private static GUIContent _dpopup;
		/// <summary>
		/// d__Popup
		/// </summary>
		public static GUIContent DPopup => _dpopup ??= EditorGUIUtility.IconContent("d__Popup");

		private static GUIContent _dpopup2X;
		/// <summary>
		/// d__Popup@2x
		/// </summary>
		public static GUIContent DPopup2X => _dpopup2X ??= EditorGUIUtility.IconContent("d__Popup@2x");

		private static GUIContent _daboutwindowmainheader;
		/// <summary>
		/// d_aboutwindow.mainheader
		/// </summary>
		public static GUIContent DAboutwindowMainheader => _daboutwindowmainheader ??= EditorGUIUtility.IconContent("d_aboutwindow.mainheader");

		private static GUIContent _dageialogo;
		/// <summary>
		/// d_ageialogo
		/// </summary>
		public static GUIContent DAgeialogo => _dageialogo ??= EditorGUIUtility.IconContent("d_ageialogo");

		private static GUIContent _dalphabeticalsorting;
		/// <summary>
		/// d_AlphabeticalSorting
		/// </summary>
		public static GUIContent DAlphabeticalsorting => _dalphabeticalsorting ??= EditorGUIUtility.IconContent("d_AlphabeticalSorting");

		private static GUIContent _dalphabeticalsorting2X;
		/// <summary>
		/// d_AlphabeticalSorting@2x
		/// </summary>
		public static GUIContent DAlphabeticalsorting2X => _dalphabeticalsorting2X ??= EditorGUIUtility.IconContent("d_AlphabeticalSorting@2x");

		private static GUIContent _danimationaddevent;
		/// <summary>
		/// d_Animation.AddEvent
		/// </summary>
		public static GUIContent DAnimationAddevent => _danimationaddevent ??= EditorGUIUtility.IconContent("d_Animation.AddEvent");

		private static GUIContent _danimationaddkeyframe;
		/// <summary>
		/// d_Animation.AddKeyframe
		/// </summary>
		public static GUIContent DAnimationAddkeyframe => _danimationaddkeyframe ??= EditorGUIUtility.IconContent("d_Animation.AddKeyframe");

		private static GUIContent _danimationeventmarker;
		/// <summary>
		/// d_Animation.EventMarker
		/// </summary>
		public static GUIContent DAnimationEventmarker => _danimationeventmarker ??= EditorGUIUtility.IconContent("d_Animation.EventMarker");

		private static GUIContent _danimationfilterbyselection;
		/// <summary>
		/// d_Animation.FilterBySelection
		/// </summary>
		public static GUIContent DAnimationFilterbyselection => _danimationfilterbyselection ??= EditorGUIUtility.IconContent("d_Animation.FilterBySelection");

		private static GUIContent _danimationfirstkey;
		/// <summary>
		/// d_Animation.FirstKey
		/// </summary>
		public static GUIContent DAnimationFirstkey => _danimationfirstkey ??= EditorGUIUtility.IconContent("d_Animation.FirstKey");

		private static GUIContent _danimationlastkey;
		/// <summary>
		/// d_Animation.LastKey
		/// </summary>
		public static GUIContent DAnimationLastkey => _danimationlastkey ??= EditorGUIUtility.IconContent("d_Animation.LastKey");

		private static GUIContent _danimationnextkey;
		/// <summary>
		/// d_Animation.NextKey
		/// </summary>
		public static GUIContent DAnimationNextkey => _danimationnextkey ??= EditorGUIUtility.IconContent("d_Animation.NextKey");

		private static GUIContent _danimationplay;
		/// <summary>
		/// d_Animation.Play
		/// </summary>
		public static GUIContent DAnimationPlay => _danimationplay ??= EditorGUIUtility.IconContent("d_Animation.Play");

		private static GUIContent _danimationprevkey;
		/// <summary>
		/// d_Animation.PrevKey
		/// </summary>
		public static GUIContent DAnimationPrevkey => _danimationprevkey ??= EditorGUIUtility.IconContent("d_Animation.PrevKey");

		private static GUIContent _danimationrecord;
		/// <summary>
		/// d_Animation.Record
		/// </summary>
		public static GUIContent DAnimationRecord => _danimationrecord ??= EditorGUIUtility.IconContent("d_Animation.Record");

		private static GUIContent _danimationrecord2X;
		/// <summary>
		/// d_Animation.Record@2x
		/// </summary>
		public static GUIContent DAnimationRecord2X => _danimationrecord2X ??= EditorGUIUtility.IconContent("d_Animation.Record@2x");

		private static GUIContent _danimationsequencerlink;
		/// <summary>
		/// d_Animation.SequencerLink
		/// </summary>
		public static GUIContent DAnimationSequencerlink => _danimationsequencerlink ??= EditorGUIUtility.IconContent("d_Animation.SequencerLink");

		private static GUIContent _danimationanimated;
		/// <summary>
		/// d_animationanimated
		/// </summary>
		public static GUIContent DAnimationanimated => _danimationanimated ??= EditorGUIUtility.IconContent("d_animationanimated");

		private static GUIContent _danimationkeyframe;
		/// <summary>
		/// d_animationkeyframe
		/// </summary>
		public static GUIContent DAnimationkeyframe => _danimationkeyframe ??= EditorGUIUtility.IconContent("d_animationkeyframe");

		private static GUIContent _danimationnocurve;
		/// <summary>
		/// d_animationnocurve
		/// </summary>
		public static GUIContent DAnimationnocurve => _danimationnocurve ??= EditorGUIUtility.IconContent("d_animationnocurve");

		private static GUIContent _danimationvisibilitytoggleoff;
		/// <summary>
		/// d_animationvisibilitytoggleoff
		/// </summary>
		public static GUIContent DAnimationvisibilitytoggleoff => _danimationvisibilitytoggleoff ??= EditorGUIUtility.IconContent("d_animationvisibilitytoggleoff");

		private static GUIContent _danimationvisibilitytoggleoff2X;
		/// <summary>
		/// d_animationvisibilitytoggleoff@2x
		/// </summary>
		public static GUIContent DAnimationvisibilitytoggleoff2X => _danimationvisibilitytoggleoff2X ??= EditorGUIUtility.IconContent("d_animationvisibilitytoggleoff@2x");

		private static GUIContent _danimationvisibilitytoggleon;
		/// <summary>
		/// d_animationvisibilitytoggleon
		/// </summary>
		public static GUIContent DAnimationvisibilitytoggleon => _danimationvisibilitytoggleon ??= EditorGUIUtility.IconContent("d_animationvisibilitytoggleon");

		private static GUIContent _danimationvisibilitytoggleon2X;
		/// <summary>
		/// d_animationvisibilitytoggleon@2x
		/// </summary>
		public static GUIContent DAnimationvisibilitytoggleon2X => _danimationvisibilitytoggleon2X ??= EditorGUIUtility.IconContent("d_animationvisibilitytoggleon@2x");

		private static GUIContent _danimationwrapmodemenu;
		/// <summary>
		/// d_AnimationWrapModeMenu
		/// </summary>
		public static GUIContent DAnimationwrapmodemenu => _danimationwrapmodemenu ??= EditorGUIUtility.IconContent("d_AnimationWrapModeMenu");

		private static GUIContent _dasbadgedelete;
		/// <summary>
		/// d_AS Badge Delete
		/// </summary>
		public static GUIContent DAsBadgeDelete => _dasbadgedelete ??= EditorGUIUtility.IconContent("d_AS Badge Delete");

		private static GUIContent _dasbadgenew;
		/// <summary>
		/// d_AS Badge New
		/// </summary>
		public static GUIContent DAsBadgeNew => _dasbadgenew ??= EditorGUIUtility.IconContent("d_AS Badge New");

		private static GUIContent _dassemblylock;
		/// <summary>
		/// d_AssemblyLock
		/// </summary>
		public static GUIContent DAssemblylock => _dassemblylock ??= EditorGUIUtility.IconContent("d_AssemblyLock");

		private static GUIContent _dassetstore;
		/// <summary>
		/// d_Asset Store
		/// </summary>
		public static GUIContent DAssetStore => _dassetstore ??= EditorGUIUtility.IconContent("d_Asset Store");

		private static GUIContent _dassetstore2X;
		/// <summary>
		/// d_Asset Store@2x
		/// </summary>
		public static GUIContent DAssetStore2X => _dassetstore2X ??= EditorGUIUtility.IconContent("d_Asset Store@2x");

		private static GUIContent _daudiomixer;
		/// <summary>
		/// d_Audio Mixer
		/// </summary>
		public static GUIContent DAudioMixer => _daudiomixer ??= EditorGUIUtility.IconContent("d_Audio Mixer");

		private static GUIContent _daudiomixer2X;
		/// <summary>
		/// d_Audio Mixer@2x
		/// </summary>
		public static GUIContent DAudioMixer2X => _daudiomixer2X ??= EditorGUIUtility.IconContent("d_Audio Mixer@2x");

		private static GUIContent _dautolightbakingoff;
		/// <summary>
		/// d_AutoLightbakingOff
		/// </summary>
		public static GUIContent DAutolightbakingoff => _dautolightbakingoff ??= EditorGUIUtility.IconContent("d_AutoLightbakingOff");

		private static GUIContent _dautolightbakingoff2X;
		/// <summary>
		/// d_AutoLightbakingOff@2x
		/// </summary>
		public static GUIContent DAutolightbakingoff2X => _dautolightbakingoff2X ??= EditorGUIUtility.IconContent("d_AutoLightbakingOff@2x");

		private static GUIContent _dautolightbakingon;
		/// <summary>
		/// d_AutoLightbakingOn
		/// </summary>
		public static GUIContent DAutolightbakingon => _dautolightbakingon ??= EditorGUIUtility.IconContent("d_AutoLightbakingOn");

		private static GUIContent _dautolightbakingon2X;
		/// <summary>
		/// d_AutoLightbakingOn@2x
		/// </summary>
		public static GUIContent DAutolightbakingon2X => _dautolightbakingon2X ??= EditorGUIUtility.IconContent("d_AutoLightbakingOn@2x");

		private static GUIContent _davatarblendbackground;
		/// <summary>
		/// d_AvatarBlendBackground
		/// </summary>
		public static GUIContent DAvatarblendbackground => _davatarblendbackground ??= EditorGUIUtility.IconContent("d_AvatarBlendBackground");

		private static GUIContent _davatarblendleft;
		/// <summary>
		/// d_AvatarBlendLeft
		/// </summary>
		public static GUIContent DAvatarblendleft => _davatarblendleft ??= EditorGUIUtility.IconContent("d_AvatarBlendLeft");

		private static GUIContent _davatarblendlefta;
		/// <summary>
		/// d_AvatarBlendLeftA
		/// </summary>
		public static GUIContent DAvatarblendlefta => _davatarblendlefta ??= EditorGUIUtility.IconContent("d_AvatarBlendLeftA");

		private static GUIContent _davatarblendright;
		/// <summary>
		/// d_AvatarBlendRight
		/// </summary>
		public static GUIContent DAvatarblendright => _davatarblendright ??= EditorGUIUtility.IconContent("d_AvatarBlendRight");

		private static GUIContent _davatarblendrighta;
		/// <summary>
		/// d_AvatarBlendRightA
		/// </summary>
		public static GUIContent DAvatarblendrighta => _davatarblendrighta ??= EditorGUIUtility.IconContent("d_AvatarBlendRightA");

		private static GUIContent _davatarcompass;
		/// <summary>
		/// d_AvatarCompass
		/// </summary>
		public static GUIContent DAvatarcompass => _davatarcompass ??= EditorGUIUtility.IconContent("d_AvatarCompass");

		private static GUIContent _davatarpivot;
		/// <summary>
		/// d_AvatarPivot
		/// </summary>
		public static GUIContent DAvatarpivot => _davatarpivot ??= EditorGUIUtility.IconContent("d_AvatarPivot");

		private static GUIContent _davatarpivot2X;
		/// <summary>
		/// d_AvatarPivot@2x
		/// </summary>
		public static GUIContent DAvatarpivot2X => _davatarpivot2X ??= EditorGUIUtility.IconContent("d_AvatarPivot@2x");

		private static GUIContent _davatarselector;
		/// <summary>
		/// d_AvatarSelector
		/// </summary>
		public static GUIContent DAvatarselector => _davatarselector ??= EditorGUIUtility.IconContent("d_AvatarSelector");

		private static GUIContent _davatarselector2X;
		/// <summary>
		/// d_AvatarSelector@2x
		/// </summary>
		public static GUIContent DAvatarselector2X => _davatarselector2X ??= EditorGUIUtility.IconContent("d_AvatarSelector@2x");

		private static GUIContent _dback;
		/// <summary>
		/// d_back
		/// </summary>
		public static GUIContent DBack => _dback ??= EditorGUIUtility.IconContent("d_back");

		private static GUIContent _dback2X;
		/// <summary>
		/// d_back@2x
		/// </summary>
		public static GUIContent DBack2X => _dback2X ??= EditorGUIUtility.IconContent("d_back@2x");

		private static GUIContent _dbeginbuttonon;
		/// <summary>
		/// d_beginButton-On
		/// </summary>
		public static GUIContent DBeginbuttonOn => _dbeginbuttonon ??= EditorGUIUtility.IconContent("d_beginButton-On");

		private static GUIContent _dbeginbutton;
		/// <summary>
		/// d_beginButton
		/// </summary>
		public static GUIContent DBeginbutton => _dbeginbutton ??= EditorGUIUtility.IconContent("d_beginButton");

		private static GUIContent _dbluegroove;
		/// <summary>
		/// d_blueGroove
		/// </summary>
		public static GUIContent DBluegroove => _dbluegroove ??= EditorGUIUtility.IconContent("d_blueGroove");

		private static GUIContent _dbuildsettingsandroid;
		/// <summary>
		/// d_BuildSettings.Android
		/// </summary>
		public static GUIContent DBuildsettingsAndroid => _dbuildsettingsandroid ??= EditorGUIUtility.IconContent("d_BuildSettings.Android");

		private static GUIContent _dbuildsettingsandroidsmall;
		/// <summary>
		/// d_BuildSettings.Android.Small
		/// </summary>
		public static GUIContent DBuildsettingsAndroidSmall => _dbuildsettingsandroidsmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Android.Small");

		private static GUIContent _dbuildsettingsandroidsmall2X;
		/// <summary>
		/// d_BuildSettings.Android.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsAndroidSmall2X => _dbuildsettingsandroidsmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Android.Small@2x");

		private static GUIContent _dbuildsettingsandroid2X;
		/// <summary>
		/// d_BuildSettings.Android@2x
		/// </summary>
		public static GUIContent DBuildsettingsAndroid2X => _dbuildsettingsandroid2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Android@2x");

		private static GUIContent _dbuildsettingsbroadcom;
		/// <summary>
		/// d_BuildSettings.Broadcom
		/// </summary>
		public static GUIContent DBuildsettingsBroadcom => _dbuildsettingsbroadcom ??= EditorGUIUtility.IconContent("d_BuildSettings.Broadcom");

		private static GUIContent _dbuildsettingsfacebook;
		/// <summary>
		/// d_BuildSettings.Facebook
		/// </summary>
		public static GUIContent DBuildsettingsFacebook => _dbuildsettingsfacebook ??= EditorGUIUtility.IconContent("d_BuildSettings.Facebook");

		private static GUIContent _dbuildsettingsfacebooksmall;
		/// <summary>
		/// d_BuildSettings.Facebook.Small
		/// </summary>
		public static GUIContent DBuildsettingsFacebookSmall => _dbuildsettingsfacebooksmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Facebook.Small");

		private static GUIContent _dbuildsettingsfacebooksmall2X;
		/// <summary>
		/// d_BuildSettings.Facebook.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsFacebookSmall2X => _dbuildsettingsfacebooksmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Facebook.Small@2x");

		private static GUIContent _dbuildsettingsfacebook2X;
		/// <summary>
		/// d_BuildSettings.Facebook@2x
		/// </summary>
		public static GUIContent DBuildsettingsFacebook2X => _dbuildsettingsfacebook2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Facebook@2x");

		private static GUIContent _dbuildsettingsflashplayer;
		/// <summary>
		/// d_BuildSettings.FlashPlayer
		/// </summary>
		public static GUIContent DBuildsettingsFlashplayer => _dbuildsettingsflashplayer ??= EditorGUIUtility.IconContent("d_BuildSettings.FlashPlayer");

		private static GUIContent _dbuildsettingsflashplayersmall;
		/// <summary>
		/// d_BuildSettings.FlashPlayer.Small
		/// </summary>
		public static GUIContent DBuildsettingsFlashplayerSmall => _dbuildsettingsflashplayersmall ??= EditorGUIUtility.IconContent("d_BuildSettings.FlashPlayer.Small");

		private static GUIContent _dbuildsettingsiphone;
		/// <summary>
		/// d_BuildSettings.iPhone
		/// </summary>
		public static GUIContent DBuildsettingsIphone => _dbuildsettingsiphone ??= EditorGUIUtility.IconContent("d_BuildSettings.iPhone");

		private static GUIContent _dbuildsettingsiphonesmall;
		/// <summary>
		/// d_BuildSettings.iPhone.Small
		/// </summary>
		public static GUIContent DBuildsettingsIphoneSmall => _dbuildsettingsiphonesmall ??= EditorGUIUtility.IconContent("d_BuildSettings.iPhone.Small");

		private static GUIContent _dbuildsettingsiphonesmall2X;
		/// <summary>
		/// d_BuildSettings.iPhone.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsIphoneSmall2X => _dbuildsettingsiphonesmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.iPhone.Small@2x");

		private static GUIContent _dbuildsettingsiphone2X;
		/// <summary>
		/// d_BuildSettings.iPhone@2x
		/// </summary>
		public static GUIContent DBuildsettingsIphone2X => _dbuildsettingsiphone2X ??= EditorGUIUtility.IconContent("d_BuildSettings.iPhone@2x");

		private static GUIContent _dbuildsettingslumin;
		/// <summary>
		/// d_BuildSettings.Lumin
		/// </summary>
		public static GUIContent DBuildsettingsLumin => _dbuildsettingslumin ??= EditorGUIUtility.IconContent("d_BuildSettings.Lumin");

		private static GUIContent _dbuildsettingsluminsmall;
		/// <summary>
		/// d_BuildSettings.Lumin.small
		/// </summary>
		public static GUIContent DBuildsettingsLuminSmall => _dbuildsettingsluminsmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Lumin.small");

		private static GUIContent _dbuildsettingsluminsmall2X;
		/// <summary>
		/// d_BuildSettings.Lumin.small@2x
		/// </summary>
		public static GUIContent DBuildsettingsLuminSmall2X => _dbuildsettingsluminsmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Lumin.small@2x");

		private static GUIContent _dbuildsettingslumin2X;
		/// <summary>
		/// d_BuildSettings.Lumin@2x
		/// </summary>
		public static GUIContent DBuildsettingsLumin2X => _dbuildsettingslumin2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Lumin@2x");

		private static GUIContent _dbuildsettingsmetro;
		/// <summary>
		/// d_BuildSettings.Metro
		/// </summary>
		public static GUIContent DBuildsettingsMetro => _dbuildsettingsmetro ??= EditorGUIUtility.IconContent("d_BuildSettings.Metro");

		private static GUIContent _dbuildsettingsmetrosmall;
		/// <summary>
		/// d_BuildSettings.Metro.Small
		/// </summary>
		public static GUIContent DBuildsettingsMetroSmall => _dbuildsettingsmetrosmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Metro.Small");

		private static GUIContent _dbuildsettingsmetrosmall2X;
		/// <summary>
		/// d_BuildSettings.Metro.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsMetroSmall2X => _dbuildsettingsmetrosmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Metro.Small@2x");

		private static GUIContent _dbuildsettingsmetro2X;
		/// <summary>
		/// d_BuildSettings.Metro@2x
		/// </summary>
		public static GUIContent DBuildsettingsMetro2X => _dbuildsettingsmetro2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Metro@2x");

		private static GUIContent _dbuildsettingsn3ds;
		/// <summary>
		/// d_BuildSettings.N3DS
		/// </summary>
		public static GUIContent DBuildsettingsN3ds => _dbuildsettingsn3ds ??= EditorGUIUtility.IconContent("d_BuildSettings.N3DS");

		private static GUIContent _dbuildsettingsn3dssmall;
		/// <summary>
		/// d_BuildSettings.N3DS.Small
		/// </summary>
		public static GUIContent DBuildsettingsN3dsSmall => _dbuildsettingsn3dssmall ??= EditorGUIUtility.IconContent("d_BuildSettings.N3DS.Small");

		private static GUIContent _dbuildsettingsn3dssmall2X;
		/// <summary>
		/// d_BuildSettings.N3DS.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsN3dsSmall2X => _dbuildsettingsn3dssmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.N3DS.Small@2x");

		private static GUIContent _dbuildsettingsn3ds2X;
		/// <summary>
		/// d_BuildSettings.N3DS@2x
		/// </summary>
		public static GUIContent DBuildsettingsN3ds2X => _dbuildsettingsn3ds2X ??= EditorGUIUtility.IconContent("d_BuildSettings.N3DS@2x");

		private static GUIContent _dbuildsettingsps4;
		/// <summary>
		/// d_BuildSettings.PS4
		/// </summary>
		public static GUIContent DBuildsettingsPs4 => _dbuildsettingsps4 ??= EditorGUIUtility.IconContent("d_BuildSettings.PS4");

		private static GUIContent _dbuildsettingsps4Small;
		/// <summary>
		/// d_BuildSettings.PS4.Small
		/// </summary>
		public static GUIContent DBuildsettingsPs4Small => _dbuildsettingsps4Small ??= EditorGUIUtility.IconContent("d_BuildSettings.PS4.Small");

		private static GUIContent _dbuildsettingsps4Small2X;
		/// <summary>
		/// d_BuildSettings.PS4.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsPs4Small2X => _dbuildsettingsps4Small2X ??= EditorGUIUtility.IconContent("d_BuildSettings.PS4.Small@2x");

		private static GUIContent _dbuildsettingsps42X;
		/// <summary>
		/// d_BuildSettings.PS4@2x
		/// </summary>
		public static GUIContent DBuildsettingsPs42X => _dbuildsettingsps42X ??= EditorGUIUtility.IconContent("d_BuildSettings.PS4@2x");

		private static GUIContent _dbuildsettingspsp2;
		/// <summary>
		/// d_BuildSettings.PSP2
		/// </summary>
		public static GUIContent DBuildsettingsPsp2 => _dbuildsettingspsp2 ??= EditorGUIUtility.IconContent("d_BuildSettings.PSP2");

		private static GUIContent _dbuildsettingspsp2Small;
		/// <summary>
		/// d_BuildSettings.PSP2.Small
		/// </summary>
		public static GUIContent DBuildsettingsPsp2Small => _dbuildsettingspsp2Small ??= EditorGUIUtility.IconContent("d_BuildSettings.PSP2.Small");

		private static GUIContent _dbuildsettingsselectedicon;
		/// <summary>
		/// d_BuildSettings.SelectedIcon
		/// </summary>
		public static GUIContent DBuildsettingsSelectedicon => _dbuildsettingsselectedicon ??= EditorGUIUtility.IconContent("d_BuildSettings.SelectedIcon");

		private static GUIContent _dbuildsettingsstadia;
		/// <summary>
		/// d_BuildSettings.Stadia
		/// </summary>
		public static GUIContent DBuildsettingsStadia => _dbuildsettingsstadia ??= EditorGUIUtility.IconContent("d_BuildSettings.Stadia");

		private static GUIContent _dbuildsettingsstadiasmall;
		/// <summary>
		/// d_BuildSettings.Stadia.Small
		/// </summary>
		public static GUIContent DBuildsettingsStadiaSmall => _dbuildsettingsstadiasmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Stadia.Small");

		private static GUIContent _dbuildsettingsstadiasmall2X;
		/// <summary>
		/// d_BuildSettings.Stadia.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsStadiaSmall2X => _dbuildsettingsstadiasmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Stadia.Small@2x");

		private static GUIContent _dbuildsettingsstadia2X;
		/// <summary>
		/// d_BuildSettings.Stadia@2x
		/// </summary>
		public static GUIContent DBuildsettingsStadia2X => _dbuildsettingsstadia2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Stadia@2x");

		private static GUIContent _dbuildsettingsstandalone;
		/// <summary>
		/// d_BuildSettings.Standalone
		/// </summary>
		public static GUIContent DBuildsettingsStandalone => _dbuildsettingsstandalone ??= EditorGUIUtility.IconContent("d_BuildSettings.Standalone");

		private static GUIContent _dbuildsettingsstandalonesmall;
		/// <summary>
		/// d_BuildSettings.Standalone.Small
		/// </summary>
		public static GUIContent DBuildsettingsStandaloneSmall => _dbuildsettingsstandalonesmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Standalone.Small");

		private static GUIContent _dbuildsettingsstandalonesmall2X;
		/// <summary>
		/// d_BuildSettings.Standalone.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsStandaloneSmall2X => _dbuildsettingsstandalonesmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Standalone.Small@2x");

		private static GUIContent _dbuildsettingsstandalone2X;
		/// <summary>
		/// d_BuildSettings.Standalone@2x
		/// </summary>
		public static GUIContent DBuildsettingsStandalone2X => _dbuildsettingsstandalone2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Standalone@2x");

		private static GUIContent _dbuildsettingsswitch;
		/// <summary>
		/// d_BuildSettings.Switch
		/// </summary>
		public static GUIContent DBuildsettingsSwitch => _dbuildsettingsswitch ??= EditorGUIUtility.IconContent("d_BuildSettings.Switch");

		private static GUIContent _dbuildsettingsswitchsmall;
		/// <summary>
		/// d_BuildSettings.Switch.Small
		/// </summary>
		public static GUIContent DBuildsettingsSwitchSmall => _dbuildsettingsswitchsmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Switch.Small");

		private static GUIContent _dbuildsettingsswitchsmall2X;
		/// <summary>
		/// d_BuildSettings.Switch.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsSwitchSmall2X => _dbuildsettingsswitchsmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Switch.Small@2x");

		private static GUIContent _dbuildsettingsswitch2X;
		/// <summary>
		/// d_BuildSettings.Switch@2x
		/// </summary>
		public static GUIContent DBuildsettingsSwitch2X => _dbuildsettingsswitch2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Switch@2x");

		private static GUIContent _dbuildsettingstvos;
		/// <summary>
		/// d_BuildSettings.tvOS
		/// </summary>
		public static GUIContent DBuildsettingsTvos => _dbuildsettingstvos ??= EditorGUIUtility.IconContent("d_BuildSettings.tvOS");

		private static GUIContent _dbuildsettingstvossmall;
		/// <summary>
		/// d_BuildSettings.tvOS.Small
		/// </summary>
		public static GUIContent DBuildsettingsTvosSmall => _dbuildsettingstvossmall ??= EditorGUIUtility.IconContent("d_BuildSettings.tvOS.Small");

		private static GUIContent _dbuildsettingstvossmall2X;
		/// <summary>
		/// d_BuildSettings.tvOS.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsTvosSmall2X => _dbuildsettingstvossmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.tvOS.Small@2x");

		private static GUIContent _dbuildsettingstvos2X;
		/// <summary>
		/// d_BuildSettings.tvOS@2x
		/// </summary>
		public static GUIContent DBuildsettingsTvos2X => _dbuildsettingstvos2X ??= EditorGUIUtility.IconContent("d_BuildSettings.tvOS@2x");

		private static GUIContent _dbuildsettingsweb;
		/// <summary>
		/// d_BuildSettings.Web
		/// </summary>
		public static GUIContent DBuildsettingsWeb => _dbuildsettingsweb ??= EditorGUIUtility.IconContent("d_BuildSettings.Web");

		private static GUIContent _dbuildsettingswebsmall;
		/// <summary>
		/// d_BuildSettings.Web.Small
		/// </summary>
		public static GUIContent DBuildsettingsWebSmall => _dbuildsettingswebsmall ??= EditorGUIUtility.IconContent("d_BuildSettings.Web.Small");

		private static GUIContent _dbuildsettingswebgl;
		/// <summary>
		/// d_BuildSettings.WebGL
		/// </summary>
		public static GUIContent DBuildsettingsWebgl => _dbuildsettingswebgl ??= EditorGUIUtility.IconContent("d_BuildSettings.WebGL");

		private static GUIContent _dbuildsettingswebglsmall;
		/// <summary>
		/// d_BuildSettings.WebGL.Small
		/// </summary>
		public static GUIContent DBuildsettingsWebglSmall => _dbuildsettingswebglsmall ??= EditorGUIUtility.IconContent("d_BuildSettings.WebGL.Small");

		private static GUIContent _dbuildsettingswebglsmall2X;
		/// <summary>
		/// d_BuildSettings.WebGL.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsWebglSmall2X => _dbuildsettingswebglsmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.WebGL.Small@2x");

		private static GUIContent _dbuildsettingswebgl2X;
		/// <summary>
		/// d_BuildSettings.WebGL@2x
		/// </summary>
		public static GUIContent DBuildsettingsWebgl2X => _dbuildsettingswebgl2X ??= EditorGUIUtility.IconContent("d_BuildSettings.WebGL@2x");

		private static GUIContent _dbuildsettingsxbox360;
		/// <summary>
		/// d_BuildSettings.Xbox360
		/// </summary>
		public static GUIContent DBuildsettingsXbox360 => _dbuildsettingsxbox360 ??= EditorGUIUtility.IconContent("d_BuildSettings.Xbox360");

		private static GUIContent _dbuildsettingsxbox360Small;
		/// <summary>
		/// d_BuildSettings.Xbox360.Small
		/// </summary>
		public static GUIContent DBuildsettingsXbox360Small => _dbuildsettingsxbox360Small ??= EditorGUIUtility.IconContent("d_BuildSettings.Xbox360.Small");

		private static GUIContent _dbuildsettingsxboxone;
		/// <summary>
		/// d_BuildSettings.XboxOne
		/// </summary>
		public static GUIContent DBuildsettingsXboxone => _dbuildsettingsxboxone ??= EditorGUIUtility.IconContent("d_BuildSettings.XboxOne");

		private static GUIContent _dbuildsettingsxboxonesmall;
		/// <summary>
		/// d_BuildSettings.XboxOne.Small
		/// </summary>
		public static GUIContent DBuildsettingsXboxoneSmall => _dbuildsettingsxboxonesmall ??= EditorGUIUtility.IconContent("d_BuildSettings.XboxOne.Small");

		private static GUIContent _dbuildsettingsxboxonesmall2X;
		/// <summary>
		/// d_BuildSettings.XboxOne.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsXboxoneSmall2X => _dbuildsettingsxboxonesmall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.XboxOne.Small@2x");

		private static GUIContent _dbuildsettingsxboxone2X;
		/// <summary>
		/// d_BuildSettings.XboxOne@2x
		/// </summary>
		public static GUIContent DBuildsettingsXboxone2X => _dbuildsettingsxboxone2X ??= EditorGUIUtility.IconContent("d_BuildSettings.XboxOne@2x");

		private static GUIContent _dbuildsettingsxiaomi;
		/// <summary>
		/// d_BuildSettings.Xiaomi
		/// </summary>
		public static GUIContent DBuildsettingsXiaomi => _dbuildsettingsxiaomi ??= EditorGUIUtility.IconContent("d_BuildSettings.Xiaomi");

		private static GUIContent _dbuildsettingsxiaomismall;
		/// <summary>
		/// d_BuildSettings.Xiaomi.Small
		/// </summary>
		public static GUIContent DBuildsettingsXiaomiSmall => _dbuildsettingsxiaomismall ??= EditorGUIUtility.IconContent("d_BuildSettings.Xiaomi.Small");

		private static GUIContent _dbuildsettingsxiaomismall2X;
		/// <summary>
		/// d_BuildSettings.Xiaomi.Small@2x
		/// </summary>
		public static GUIContent DBuildsettingsXiaomiSmall2X => _dbuildsettingsxiaomismall2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Xiaomi.Small@2x");

		private static GUIContent _dbuildsettingsxiaomi2X;
		/// <summary>
		/// d_BuildSettings.Xiaomi@2x
		/// </summary>
		public static GUIContent DBuildsettingsXiaomi2X => _dbuildsettingsxiaomi2X ??= EditorGUIUtility.IconContent("d_BuildSettings.Xiaomi@2x");

		private static GUIContent _dcacheserverconnected;
		/// <summary>
		/// d_CacheServerConnected
		/// </summary>
		public static GUIContent DCacheserverconnected => _dcacheserverconnected ??= EditorGUIUtility.IconContent("d_CacheServerConnected");

		private static GUIContent _dcacheserverconnected2X;
		/// <summary>
		/// d_CacheServerConnected@2x
		/// </summary>
		public static GUIContent DCacheserverconnected2X => _dcacheserverconnected2X ??= EditorGUIUtility.IconContent("d_CacheServerConnected@2x");

		private static GUIContent _dcacheserverdisabled;
		/// <summary>
		/// d_CacheServerDisabled
		/// </summary>
		public static GUIContent DCacheserverdisabled => _dcacheserverdisabled ??= EditorGUIUtility.IconContent("d_CacheServerDisabled");

		private static GUIContent _dcacheserverdisabled2X;
		/// <summary>
		/// d_CacheServerDisabled@2x
		/// </summary>
		public static GUIContent DCacheserverdisabled2X => _dcacheserverdisabled2X ??= EditorGUIUtility.IconContent("d_CacheServerDisabled@2x");

		private static GUIContent _dcacheserverdisconnected;
		/// <summary>
		/// d_CacheServerDisconnected
		/// </summary>
		public static GUIContent DCacheserverdisconnected => _dcacheserverdisconnected ??= EditorGUIUtility.IconContent("d_CacheServerDisconnected");

		private static GUIContent _dcacheserverdisconnected2X;
		/// <summary>
		/// d_CacheServerDisconnected@2x
		/// </summary>
		public static GUIContent DCacheserverdisconnected2X => _dcacheserverdisconnected2X ??= EditorGUIUtility.IconContent("d_CacheServerDisconnected@2x");

		private static GUIContent _dcheckerfloor;
		/// <summary>
		/// d_CheckerFloor
		/// </summary>
		public static GUIContent DCheckerfloor => _dcheckerfloor ??= EditorGUIUtility.IconContent("d_CheckerFloor");

		private static GUIContent _dcloudconnect;
		/// <summary>
		/// d_CloudConnect
		/// </summary>
		public static GUIContent DCloudconnect => _dcloudconnect ??= EditorGUIUtility.IconContent("d_CloudConnect");

		private static GUIContent _dcloudconnect2X;
		/// <summary>
		/// d_CloudConnect@2x
		/// </summary>
		public static GUIContent DCloudconnect2X => _dcloudconnect2X ??= EditorGUIUtility.IconContent("d_CloudConnect@2x");

		private static GUIContent _dcollabfileadded;
		/// <summary>
		/// d_Collab.FileAdded
		/// </summary>
		public static GUIContent DCollabFileadded => _dcollabfileadded ??= EditorGUIUtility.IconContent("d_Collab.FileAdded");

		private static GUIContent _dcollabfileconflict;
		/// <summary>
		/// d_Collab.FileConflict
		/// </summary>
		public static GUIContent DCollabFileconflict => _dcollabfileconflict ??= EditorGUIUtility.IconContent("d_Collab.FileConflict");

		private static GUIContent _dcollabfiledeleted;
		/// <summary>
		/// d_Collab.FileDeleted
		/// </summary>
		public static GUIContent DCollabFiledeleted => _dcollabfiledeleted ??= EditorGUIUtility.IconContent("d_Collab.FileDeleted");

		private static GUIContent _dcollabfileignored;
		/// <summary>
		/// d_Collab.FileIgnored
		/// </summary>
		public static GUIContent DCollabFileignored => _dcollabfileignored ??= EditorGUIUtility.IconContent("d_Collab.FileIgnored");

		private static GUIContent _dcollabfilemoved;
		/// <summary>
		/// d_Collab.FileMoved
		/// </summary>
		public static GUIContent DCollabFilemoved => _dcollabfilemoved ??= EditorGUIUtility.IconContent("d_Collab.FileMoved");

		private static GUIContent _dcollabfileupdated;
		/// <summary>
		/// d_Collab.FileUpdated
		/// </summary>
		public static GUIContent DCollabFileupdated => _dcollabfileupdated ??= EditorGUIUtility.IconContent("d_Collab.FileUpdated");

		private static GUIContent _dcollabfolderadded;
		/// <summary>
		/// d_Collab.FolderAdded
		/// </summary>
		public static GUIContent DCollabFolderadded => _dcollabfolderadded ??= EditorGUIUtility.IconContent("d_Collab.FolderAdded");

		private static GUIContent _dcollabfolderconflict;
		/// <summary>
		/// d_Collab.FolderConflict
		/// </summary>
		public static GUIContent DCollabFolderconflict => _dcollabfolderconflict ??= EditorGUIUtility.IconContent("d_Collab.FolderConflict");

		private static GUIContent _dcollabfolderdeleted;
		/// <summary>
		/// d_Collab.FolderDeleted
		/// </summary>
		public static GUIContent DCollabFolderdeleted => _dcollabfolderdeleted ??= EditorGUIUtility.IconContent("d_Collab.FolderDeleted");

		private static GUIContent _dcollabfolderignored;
		/// <summary>
		/// d_Collab.FolderIgnored
		/// </summary>
		public static GUIContent DCollabFolderignored => _dcollabfolderignored ??= EditorGUIUtility.IconContent("d_Collab.FolderIgnored");

		private static GUIContent _dcollabfoldermoved;
		/// <summary>
		/// d_Collab.FolderMoved
		/// </summary>
		public static GUIContent DCollabFoldermoved => _dcollabfoldermoved ??= EditorGUIUtility.IconContent("d_Collab.FolderMoved");

		private static GUIContent _dcollabfolderupdated;
		/// <summary>
		/// d_Collab.FolderUpdated
		/// </summary>
		public static GUIContent DCollabFolderupdated => _dcollabfolderupdated ??= EditorGUIUtility.IconContent("d_Collab.FolderUpdated");

		private static GUIContent _dcollab;
		/// <summary>
		/// d_Collab
		/// </summary>
		public static GUIContent DCollab => _dcollab ??= EditorGUIUtility.IconContent("d_Collab");

		private static GUIContent _dcollab2X;
		/// <summary>
		/// d_Collab@2x
		/// </summary>
		public static GUIContent DCollab2X => _dcollab2X ??= EditorGUIUtility.IconContent("d_Collab@2x");

		private static GUIContent _dcolorpickercyclecolor;
		/// <summary>
		/// d_ColorPicker.CycleColor
		/// </summary>
		public static GUIContent DColorpickerCyclecolor => _dcolorpickercyclecolor ??= EditorGUIUtility.IconContent("d_ColorPicker.CycleColor");

		private static GUIContent _dcolorpickercycleslider;
		/// <summary>
		/// d_ColorPicker.CycleSlider
		/// </summary>
		public static GUIContent DColorpickerCycleslider => _dcolorpickercycleslider ??= EditorGUIUtility.IconContent("d_ColorPicker.CycleSlider");

		private static GUIContent _dconsoleerroriconinactivesml;
		/// <summary>
		/// d_console.erroricon.inactive.sml
		/// </summary>
		public static GUIContent DConsoleErroriconInactiveSml => _dconsoleerroriconinactivesml ??= EditorGUIUtility.IconContent("d_console.erroricon.inactive.sml");

		private static GUIContent _dconsoleerroriconinactivesml2X;
		/// <summary>
		/// d_console.erroricon.inactive.sml@2x
		/// </summary>
		public static GUIContent DConsoleErroriconInactiveSml2X => _dconsoleerroriconinactivesml2X ??= EditorGUIUtility.IconContent("d_console.erroricon.inactive.sml@2x");

		private static GUIContent _dconsoleerroricon;
		/// <summary>
		/// d_console.erroricon
		/// </summary>
		public static GUIContent DConsoleErroricon => _dconsoleerroricon ??= EditorGUIUtility.IconContent("d_console.erroricon");

		private static GUIContent _dconsoleerroriconsml;
		/// <summary>
		/// d_console.erroricon.sml
		/// </summary>
		public static GUIContent DConsoleErroriconSml => _dconsoleerroriconsml ??= EditorGUIUtility.IconContent("d_console.erroricon.sml");

		private static GUIContent _dconsoleerroriconsml2X;
		/// <summary>
		/// d_console.erroricon.sml@2x
		/// </summary>
		public static GUIContent DConsoleErroriconSml2X => _dconsoleerroriconsml2X ??= EditorGUIUtility.IconContent("d_console.erroricon.sml@2x");

		private static GUIContent _dconsoleerroricon2X;
		/// <summary>
		/// d_console.erroricon@2x
		/// </summary>
		public static GUIContent DConsoleErroricon2X => _dconsoleerroricon2X ??= EditorGUIUtility.IconContent("d_console.erroricon@2x");

		private static GUIContent _dconsoleinfoiconinactivesml;
		/// <summary>
		/// d_console.infoicon.inactive.sml
		/// </summary>
		public static GUIContent DConsoleInfoiconInactiveSml => _dconsoleinfoiconinactivesml ??= EditorGUIUtility.IconContent("d_console.infoicon.inactive.sml");

		private static GUIContent _dconsoleinfoiconinactivesml2X;
		/// <summary>
		/// d_console.infoicon.inactive.sml@2x
		/// </summary>
		public static GUIContent DConsoleInfoiconInactiveSml2X => _dconsoleinfoiconinactivesml2X ??= EditorGUIUtility.IconContent("d_console.infoicon.inactive.sml@2x");

		private static GUIContent _dconsoleinfoicon;
		/// <summary>
		/// d_console.infoicon
		/// </summary>
		public static GUIContent DConsoleInfoicon => _dconsoleinfoicon ??= EditorGUIUtility.IconContent("d_console.infoicon");

		private static GUIContent _dconsoleinfoiconsml;
		/// <summary>
		/// d_console.infoicon.sml
		/// </summary>
		public static GUIContent DConsoleInfoiconSml => _dconsoleinfoiconsml ??= EditorGUIUtility.IconContent("d_console.infoicon.sml");

		private static GUIContent _dconsoleinfoiconsml2X;
		/// <summary>
		/// d_console.infoicon.sml@2x
		/// </summary>
		public static GUIContent DConsoleInfoiconSml2X => _dconsoleinfoiconsml2X ??= EditorGUIUtility.IconContent("d_console.infoicon.sml@2x");

		private static GUIContent _dconsoleinfoicon2X;
		/// <summary>
		/// d_console.infoicon@2x
		/// </summary>
		public static GUIContent DConsoleInfoicon2X => _dconsoleinfoicon2X ??= EditorGUIUtility.IconContent("d_console.infoicon@2x");

		private static GUIContent _dconsolewarniconinactivesml;
		/// <summary>
		/// d_console.warnicon.inactive.sml
		/// </summary>
		public static GUIContent DConsoleWarniconInactiveSml => _dconsolewarniconinactivesml ??= EditorGUIUtility.IconContent("d_console.warnicon.inactive.sml");

		private static GUIContent _dconsolewarniconinactivesml2X;
		/// <summary>
		/// d_console.warnicon.inactive.sml@2x
		/// </summary>
		public static GUIContent DConsoleWarniconInactiveSml2X => _dconsolewarniconinactivesml2X ??= EditorGUIUtility.IconContent("d_console.warnicon.inactive.sml@2x");

		private static GUIContent _dconsolewarnicon;
		/// <summary>
		/// d_console.warnicon
		/// </summary>
		public static GUIContent DConsoleWarnicon => _dconsolewarnicon ??= EditorGUIUtility.IconContent("d_console.warnicon");

		private static GUIContent _dconsolewarniconsml;
		/// <summary>
		/// d_console.warnicon.sml
		/// </summary>
		public static GUIContent DConsoleWarniconSml => _dconsolewarniconsml ??= EditorGUIUtility.IconContent("d_console.warnicon.sml");

		private static GUIContent _dconsolewarniconsml2X;
		/// <summary>
		/// d_console.warnicon.sml@2x
		/// </summary>
		public static GUIContent DConsoleWarniconSml2X => _dconsolewarniconsml2X ??= EditorGUIUtility.IconContent("d_console.warnicon.sml@2x");

		private static GUIContent _dconsolewarnicon2X;
		/// <summary>
		/// d_console.warnicon@2x
		/// </summary>
		public static GUIContent DConsoleWarnicon2X => _dconsolewarnicon2X ??= EditorGUIUtility.IconContent("d_console.warnicon@2x");

		private static GUIContent _dcreateaddnew;
		/// <summary>
		/// d_CreateAddNew
		/// </summary>
		public static GUIContent DCreateaddnew => _dcreateaddnew ??= EditorGUIUtility.IconContent("d_CreateAddNew");

		private static GUIContent _dcreateaddnew2X;
		/// <summary>
		/// d_CreateAddNew@2x
		/// </summary>
		public static GUIContent DCreateaddnew2X => _dcreateaddnew2X ??= EditorGUIUtility.IconContent("d_CreateAddNew@2x");

		private static GUIContent _dcurvekeyframe;
		/// <summary>
		/// d_curvekeyframe
		/// </summary>
		public static GUIContent DCurvekeyframe => _dcurvekeyframe ??= EditorGUIUtility.IconContent("d_curvekeyframe");

		private static GUIContent _dcurvekeyframeselected;
		/// <summary>
		/// d_curvekeyframeselected
		/// </summary>
		public static GUIContent DCurvekeyframeselected => _dcurvekeyframeselected ??= EditorGUIUtility.IconContent("d_curvekeyframeselected");

		private static GUIContent _dcurvekeyframeselectedoverlay;
		/// <summary>
		/// d_curvekeyframeselectedoverlay
		/// </summary>
		public static GUIContent DCurvekeyframeselectedoverlay => _dcurvekeyframeselectedoverlay ??= EditorGUIUtility.IconContent("d_curvekeyframeselectedoverlay");

		private static GUIContent _dcurvekeyframesemiselectedoverlay;
		/// <summary>
		/// d_curvekeyframesemiselectedoverlay
		/// </summary>
		public static GUIContent DCurvekeyframesemiselectedoverlay => _dcurvekeyframesemiselectedoverlay ??= EditorGUIUtility.IconContent("d_curvekeyframesemiselectedoverlay");

		private static GUIContent _dcurvekeyframeweighted;
		/// <summary>
		/// d_curvekeyframeweighted
		/// </summary>
		public static GUIContent DCurvekeyframeweighted => _dcurvekeyframeweighted ??= EditorGUIUtility.IconContent("d_curvekeyframeweighted");

		private static GUIContent _dcustomsorting;
		/// <summary>
		/// d_CustomSorting
		/// </summary>
		public static GUIContent DCustomsorting => _dcustomsorting ??= EditorGUIUtility.IconContent("d_CustomSorting");

		private static GUIContent _dcustomtool;
		/// <summary>
		/// d_CustomTool
		/// </summary>
		public static GUIContent DCustomtool => _dcustomtool ??= EditorGUIUtility.IconContent("d_CustomTool");

		private static GUIContent _dcustomtool2X;
		/// <summary>
		/// d_CustomTool@2x
		/// </summary>
		public static GUIContent DCustomtool2X => _dcustomtool2X ??= EditorGUIUtility.IconContent("d_CustomTool@2x");

		private static GUIContent _ddebuggerattached;
		/// <summary>
		/// d_DebuggerAttached
		/// </summary>
		public static GUIContent DDebuggerattached => _ddebuggerattached ??= EditorGUIUtility.IconContent("d_DebuggerAttached");

		private static GUIContent _ddebuggerattached2X;
		/// <summary>
		/// d_DebuggerAttached@2x
		/// </summary>
		public static GUIContent DDebuggerattached2X => _ddebuggerattached2X ??= EditorGUIUtility.IconContent("d_DebuggerAttached@2x");

		private static GUIContent _ddebuggerdisabled;
		/// <summary>
		/// d_DebuggerDisabled
		/// </summary>
		public static GUIContent DDebuggerdisabled => _ddebuggerdisabled ??= EditorGUIUtility.IconContent("d_DebuggerDisabled");

		private static GUIContent _ddebuggerdisabled2X;
		/// <summary>
		/// d_DebuggerDisabled@2x
		/// </summary>
		public static GUIContent DDebuggerdisabled2X => _ddebuggerdisabled2X ??= EditorGUIUtility.IconContent("d_DebuggerDisabled@2x");

		private static GUIContent _ddebuggerenabled;
		/// <summary>
		/// d_DebuggerEnabled
		/// </summary>
		public static GUIContent DDebuggerenabled => _ddebuggerenabled ??= EditorGUIUtility.IconContent("d_DebuggerEnabled");

		private static GUIContent _ddebuggerenabled2X;
		/// <summary>
		/// d_DebuggerEnabled@2x
		/// </summary>
		public static GUIContent DDebuggerenabled2X => _ddebuggerenabled2X ??= EditorGUIUtility.IconContent("d_DebuggerEnabled@2x");

		private static GUIContent _ddefaultsorting;
		/// <summary>
		/// d_DefaultSorting
		/// </summary>
		public static GUIContent DDefaultsorting => _ddefaultsorting ??= EditorGUIUtility.IconContent("d_DefaultSorting");

		private static GUIContent _ddefaultsorting2X;
		/// <summary>
		/// d_DefaultSorting@2x
		/// </summary>
		public static GUIContent DDefaultsorting2X => _ddefaultsorting2X ??= EditorGUIUtility.IconContent("d_DefaultSorting@2x");

		private static GUIContent _deditcollider;
		/// <summary>
		/// d_EditCollider
		/// </summary>
		public static GUIContent DEditcollider => _deditcollider ??= EditorGUIUtility.IconContent("d_EditCollider");

		private static GUIContent _deditcollision16;
		/// <summary>
		/// d_editcollision_16
		/// </summary>
		public static GUIContent DEditcollision16 => _deditcollision16 ??= EditorGUIUtility.IconContent("d_editcollision_16");

		private static GUIContent _deditcollision162X;
		/// <summary>
		/// d_editcollision_16@2x
		/// </summary>
		public static GUIContent DEditcollision162X => _deditcollision162X ??= EditorGUIUtility.IconContent("d_editcollision_16@2x");

		private static GUIContent _deditcollision32;
		/// <summary>
		/// d_editcollision_32
		/// </summary>
		public static GUIContent DEditcollision32 => _deditcollision32 ??= EditorGUIUtility.IconContent("d_editcollision_32");

		private static GUIContent _deditconstraints16;
		/// <summary>
		/// d_editconstraints_16
		/// </summary>
		public static GUIContent DEditconstraints16 => _deditconstraints16 ??= EditorGUIUtility.IconContent("d_editconstraints_16");

		private static GUIContent _deditconstraints162X;
		/// <summary>
		/// d_editconstraints_16@2x
		/// </summary>
		public static GUIContent DEditconstraints162X => _deditconstraints162X ??= EditorGUIUtility.IconContent("d_editconstraints_16@2x");

		private static GUIContent _deditconstraints32;
		/// <summary>
		/// d_editconstraints_32
		/// </summary>
		public static GUIContent DEditconstraints32 => _deditconstraints32 ??= EditorGUIUtility.IconContent("d_editconstraints_32");

		private static GUIContent _dediticonsml;
		/// <summary>
		/// d_editicon.sml
		/// </summary>
		public static GUIContent DEditiconSml => _dediticonsml ??= EditorGUIUtility.IconContent("d_editicon.sml");

		private static GUIContent _dendbuttonon;
		/// <summary>
		/// d_endButton-On
		/// </summary>
		public static GUIContent DEndbuttonOn => _dendbuttonon ??= EditorGUIUtility.IconContent("d_endButton-On");

		private static GUIContent _dendbutton;
		/// <summary>
		/// d_endButton
		/// </summary>
		public static GUIContent DEndbutton => _dendbutton ??= EditorGUIUtility.IconContent("d_endButton");

		private static GUIContent _dexposure;
		/// <summary>
		/// d_Exposure
		/// </summary>
		public static GUIContent DExposure => _dexposure ??= EditorGUIUtility.IconContent("d_Exposure");

		private static GUIContent _dexposure2X;
		/// <summary>
		/// d_Exposure@2x
		/// </summary>
		public static GUIContent DExposure2X => _dexposure2X ??= EditorGUIUtility.IconContent("d_Exposure@2x");

		private static GUIContent _deyedropperlarge;
		/// <summary>
		/// d_eyeDropper.Large
		/// </summary>
		public static GUIContent DEyedropperLarge => _deyedropperlarge ??= EditorGUIUtility.IconContent("d_eyeDropper.Large");

		private static GUIContent _deyedropperlarge2X;
		/// <summary>
		/// d_eyeDropper.Large@2x
		/// </summary>
		public static GUIContent DEyedropperLarge2X => _deyedropperlarge2X ??= EditorGUIUtility.IconContent("d_eyeDropper.Large@2x");

		private static GUIContent _deyedroppersml;
		/// <summary>
		/// d_eyeDropper.sml
		/// </summary>
		public static GUIContent DEyedropperSml => _deyedroppersml ??= EditorGUIUtility.IconContent("d_eyeDropper.sml");

		private static GUIContent _dfavorite;
		/// <summary>
		/// d_Favorite
		/// </summary>
		public static GUIContent DFavorite => _dfavorite ??= EditorGUIUtility.IconContent("d_Favorite");

		private static GUIContent _dfavorite2X;
		/// <summary>
		/// d_Favorite@2x
		/// </summary>
		public static GUIContent DFavorite2X => _dfavorite2X ??= EditorGUIUtility.IconContent("d_Favorite@2x");

		private static GUIContent _dfilterbylabel;
		/// <summary>
		/// d_FilterByLabel
		/// </summary>
		public static GUIContent DFilterbylabel => _dfilterbylabel ??= EditorGUIUtility.IconContent("d_FilterByLabel");

		private static GUIContent _dfilterbylabel2X;
		/// <summary>
		/// d_FilterByLabel@2x
		/// </summary>
		public static GUIContent DFilterbylabel2X => _dfilterbylabel2X ??= EditorGUIUtility.IconContent("d_FilterByLabel@2x");

		private static GUIContent _dfilterbytype;
		/// <summary>
		/// d_FilterByType
		/// </summary>
		public static GUIContent DFilterbytype => _dfilterbytype ??= EditorGUIUtility.IconContent("d_FilterByType");

		private static GUIContent _dfilterbytype2X;
		/// <summary>
		/// d_FilterByType@2x
		/// </summary>
		public static GUIContent DFilterbytype2X => _dfilterbytype2X ??= EditorGUIUtility.IconContent("d_FilterByType@2x");

		private static GUIContent _dfilterselectedonly;
		/// <summary>
		/// d_FilterSelectedOnly
		/// </summary>
		public static GUIContent DFilterselectedonly => _dfilterselectedonly ??= EditorGUIUtility.IconContent("d_FilterSelectedOnly");

		private static GUIContent _dfilterselectedonly2X;
		/// <summary>
		/// d_FilterSelectedOnly@2x
		/// </summary>
		public static GUIContent DFilterselectedonly2X => _dfilterselectedonly2X ??= EditorGUIUtility.IconContent("d_FilterSelectedOnly@2x");

		private static GUIContent _dforward;
		/// <summary>
		/// d_forward
		/// </summary>
		public static GUIContent DForward => _dforward ??= EditorGUIUtility.IconContent("d_forward");

		private static GUIContent _dforward2X;
		/// <summary>
		/// d_forward@2x
		/// </summary>
		public static GUIContent DForward2X => _dforward2X ??= EditorGUIUtility.IconContent("d_forward@2x");

		private static GUIContent _dframecapture;
		/// <summary>
		/// d_FrameCapture
		/// </summary>
		public static GUIContent DFramecapture => _dframecapture ??= EditorGUIUtility.IconContent("d_FrameCapture");

		private static GUIContent _dframecapture2X;
		/// <summary>
		/// d_FrameCapture@2x
		/// </summary>
		public static GUIContent DFramecapture2X => _dframecapture2X ??= EditorGUIUtility.IconContent("d_FrameCapture@2x");

		private static GUIContent _dgear;
		/// <summary>
		/// d_GEAR
		/// </summary>
		public static GUIContent DGear => _dgear ??= EditorGUIUtility.IconContent("d_GEAR");

		private static GUIContent _dgridboxtool;
		/// <summary>
		/// d_Grid.BoxTool
		/// </summary>
		public static GUIContent DGridBoxtool => _dgridboxtool ??= EditorGUIUtility.IconContent("d_Grid.BoxTool");

		private static GUIContent _dgridboxtool2X;
		/// <summary>
		/// d_Grid.BoxTool@2x
		/// </summary>
		public static GUIContent DGridBoxtool2X => _dgridboxtool2X ??= EditorGUIUtility.IconContent("d_Grid.BoxTool@2x");

		private static GUIContent _dgriddefault;
		/// <summary>
		/// d_Grid.Default
		/// </summary>
		public static GUIContent DGridDefault => _dgriddefault ??= EditorGUIUtility.IconContent("d_Grid.Default");

		private static GUIContent _dgriddefault2X;
		/// <summary>
		/// d_Grid.Default@2x
		/// </summary>
		public static GUIContent DGridDefault2X => _dgriddefault2X ??= EditorGUIUtility.IconContent("d_Grid.Default@2x");

		private static GUIContent _dgriderasertool;
		/// <summary>
		/// d_Grid.EraserTool
		/// </summary>
		public static GUIContent DGridErasertool => _dgriderasertool ??= EditorGUIUtility.IconContent("d_Grid.EraserTool");

		private static GUIContent _dgriderasertool2X;
		/// <summary>
		/// d_Grid.EraserTool@2x
		/// </summary>
		public static GUIContent DGridErasertool2X => _dgriderasertool2X ??= EditorGUIUtility.IconContent("d_Grid.EraserTool@2x");

		private static GUIContent _dgridfilltool;
		/// <summary>
		/// d_Grid.FillTool
		/// </summary>
		public static GUIContent DGridFilltool => _dgridfilltool ??= EditorGUIUtility.IconContent("d_Grid.FillTool");

		private static GUIContent _dgridfilltool2X;
		/// <summary>
		/// d_Grid.FillTool@2x
		/// </summary>
		public static GUIContent DGridFilltool2X => _dgridfilltool2X ??= EditorGUIUtility.IconContent("d_Grid.FillTool@2x");

		private static GUIContent _dgridmovetool;
		/// <summary>
		/// d_Grid.MoveTool
		/// </summary>
		public static GUIContent DGridMovetool => _dgridmovetool ??= EditorGUIUtility.IconContent("d_Grid.MoveTool");

		private static GUIContent _dgridmovetool2X;
		/// <summary>
		/// d_Grid.MoveTool@2x
		/// </summary>
		public static GUIContent DGridMovetool2X => _dgridmovetool2X ??= EditorGUIUtility.IconContent("d_Grid.MoveTool@2x");

		private static GUIContent _dgridpainttool;
		/// <summary>
		/// d_Grid.PaintTool
		/// </summary>
		public static GUIContent DGridPainttool => _dgridpainttool ??= EditorGUIUtility.IconContent("d_Grid.PaintTool");

		private static GUIContent _dgridpainttool2X;
		/// <summary>
		/// d_Grid.PaintTool@2x
		/// </summary>
		public static GUIContent DGridPainttool2X => _dgridpainttool2X ??= EditorGUIUtility.IconContent("d_Grid.PaintTool@2x");

		private static GUIContent _dgridpickingtool;
		/// <summary>
		/// d_Grid.PickingTool
		/// </summary>
		public static GUIContent DGridPickingtool => _dgridpickingtool ??= EditorGUIUtility.IconContent("d_Grid.PickingTool");

		private static GUIContent _dgridpickingtool2X;
		/// <summary>
		/// d_Grid.PickingTool@2x
		/// </summary>
		public static GUIContent DGridPickingtool2X => _dgridpickingtool2X ??= EditorGUIUtility.IconContent("d_Grid.PickingTool@2x");

		private static GUIContent _dgroove;
		/// <summary>
		/// d_Groove
		/// </summary>
		public static GUIContent DGroove => _dgroove ??= EditorGUIUtility.IconContent("d_Groove");

		private static GUIContent _dhorizontalsplit;
		/// <summary>
		/// d_HorizontalSplit
		/// </summary>
		public static GUIContent DHorizontalsplit => _dhorizontalsplit ??= EditorGUIUtility.IconContent("d_HorizontalSplit");

		private static GUIContent _dicondropdown;
		/// <summary>
		/// d_icon dropdown
		/// </summary>
		public static GUIContent DIconDropdown => _dicondropdown ??= EditorGUIUtility.IconContent("d_icon dropdown");

		private static GUIContent _dicondropdown2X;
		/// <summary>
		/// d_icon dropdown@2x
		/// </summary>
		public static GUIContent DIconDropdown2X => _dicondropdown2X ??= EditorGUIUtility.IconContent("d_icon dropdown@2x");

		private static GUIContent _dimport;
		/// <summary>
		/// d_Import
		/// </summary>
		public static GUIContent DImport => _dimport ??= EditorGUIUtility.IconContent("d_Import");

		private static GUIContent _dimport2X;
		/// <summary>
		/// d_Import@2x
		/// </summary>
		public static GUIContent DImport2X => _dimport2X ??= EditorGUIUtility.IconContent("d_Import@2x");

		private static GUIContent _dinspectorlock;
		/// <summary>
		/// d_InspectorLock
		/// </summary>
		public static GUIContent DInspectorlock => _dinspectorlock ??= EditorGUIUtility.IconContent("d_InspectorLock");

		private static GUIContent _dinvalid;
		/// <summary>
		/// d_Invalid
		/// </summary>
		public static GUIContent DInvalid => _dinvalid ??= EditorGUIUtility.IconContent("d_Invalid");

		private static GUIContent _dinvalid2X;
		/// <summary>
		/// d_Invalid@2x
		/// </summary>
		public static GUIContent DInvalid2X => _dinvalid2X ??= EditorGUIUtility.IconContent("d_Invalid@2x");

		private static GUIContent _djointangularlimits;
		/// <summary>
		/// d_JointAngularLimits
		/// </summary>
		public static GUIContent DJointangularlimits => _djointangularlimits ??= EditorGUIUtility.IconContent("d_JointAngularLimits");

		private static GUIContent _dleftbracket;
		/// <summary>
		/// d_leftBracket
		/// </summary>
		public static GUIContent DLeftbracket => _dleftbracket ??= EditorGUIUtility.IconContent("d_leftBracket");

		private static GUIContent _dlighting;
		/// <summary>
		/// d_Lighting
		/// </summary>
		public static GUIContent DLighting => _dlighting ??= EditorGUIUtility.IconContent("d_Lighting");

		private static GUIContent _dlighting2X;
		/// <summary>
		/// d_Lighting@2x
		/// </summary>
		public static GUIContent DLighting2X => _dlighting2X ??= EditorGUIUtility.IconContent("d_Lighting@2x");

		private static GUIContent _dlightmapeditorwindowtitle;
		/// <summary>
		/// d_LightmapEditor.WindowTitle
		/// </summary>
		public static GUIContent DLightmapeditorWindowtitle => _dlightmapeditorwindowtitle ??= EditorGUIUtility.IconContent("d_LightmapEditor.WindowTitle");

		private static GUIContent _dlightmapeditorwindowtitle2X;
		/// <summary>
		/// d_LightmapEditor.WindowTitle@2x
		/// </summary>
		public static GUIContent DLightmapeditorWindowtitle2X => _dlightmapeditorwindowtitle2X ??= EditorGUIUtility.IconContent("d_LightmapEditor.WindowTitle@2x");

		private static GUIContent _dlinked;
		/// <summary>
		/// d_Linked
		/// </summary>
		public static GUIContent DLinked => _dlinked ??= EditorGUIUtility.IconContent("d_Linked");

		private static GUIContent _dlinked2X;
		/// <summary>
		/// d_Linked@2x
		/// </summary>
		public static GUIContent DLinked2X => _dlinked2X ??= EditorGUIUtility.IconContent("d_Linked@2x");

		private static GUIContent _dmainstageview;
		/// <summary>
		/// d_MainStageView
		/// </summary>
		public static GUIContent DMainstageview => _dmainstageview ??= EditorGUIUtility.IconContent("d_MainStageView");

		private static GUIContent _dmainstageview2X;
		/// <summary>
		/// d_MainStageView@2x
		/// </summary>
		public static GUIContent DMainstageview2X => _dmainstageview2X ??= EditorGUIUtility.IconContent("d_MainStageView@2x");

		private static GUIContent _dmirror;
		/// <summary>
		/// d_Mirror
		/// </summary>
		public static GUIContent DMirror => _dmirror ??= EditorGUIUtility.IconContent("d_Mirror");

		private static GUIContent _dmodellarge;
		/// <summary>
		/// d_model large
		/// </summary>
		public static GUIContent DModelLarge => _dmodellarge ??= EditorGUIUtility.IconContent("d_model large");

		private static GUIContent _dmonologo;
		/// <summary>
		/// d_monologo
		/// </summary>
		public static GUIContent DMonologo => _dmonologo ??= EditorGUIUtility.IconContent("d_monologo");

		private static GUIContent _dmoreoptions;
		/// <summary>
		/// d_MoreOptions
		/// </summary>
		public static GUIContent DMoreoptions => _dmoreoptions ??= EditorGUIUtility.IconContent("d_MoreOptions");

		private static GUIContent _dmoreoptions2X;
		/// <summary>
		/// d_MoreOptions@2x
		/// </summary>
		public static GUIContent DMoreoptions2X => _dmoreoptions2X ??= EditorGUIUtility.IconContent("d_MoreOptions@2x");

		private static GUIContent _dmovetoolon;
		/// <summary>
		/// d_MoveTool on
		/// </summary>
		public static GUIContent DMovetoolOn => _dmovetoolon ??= EditorGUIUtility.IconContent("d_MoveTool on");

		private static GUIContent _dmovetoolon2X;
		/// <summary>
		/// d_MoveTool On@2x
		/// </summary>
		public static GUIContent DMovetoolOn2X => _dmovetoolon2X ??= EditorGUIUtility.IconContent("d_MoveTool On@2x");

		private static GUIContent _dmovetool;
		/// <summary>
		/// d_MoveTool
		/// </summary>
		public static GUIContent DMovetool => _dmovetool ??= EditorGUIUtility.IconContent("d_MoveTool");

		private static GUIContent _dmovetool2X;
		/// <summary>
		/// d_MoveTool@2x
		/// </summary>
		public static GUIContent DMovetool2X => _dmovetool2X ??= EditorGUIUtility.IconContent("d_MoveTool@2x");

		private static GUIContent _dnavigation;
		/// <summary>
		/// d_Navigation
		/// </summary>
		public static GUIContent DNavigation => _dnavigation ??= EditorGUIUtility.IconContent("d_Navigation");

		private static GUIContent _docclusion;
		/// <summary>
		/// d_Occlusion
		/// </summary>
		public static GUIContent DOcclusion => _docclusion ??= EditorGUIUtility.IconContent("d_Occlusion");

		private static GUIContent _docclusion2X;
		/// <summary>
		/// d_Occlusion@2x
		/// </summary>
		public static GUIContent DOcclusion2X => _docclusion2X ??= EditorGUIUtility.IconContent("d_Occlusion@2x");

		private static GUIContent _dpackagemanager;
		/// <summary>
		/// d_Package Manager
		/// </summary>
		public static GUIContent DPackageManager => _dpackagemanager ??= EditorGUIUtility.IconContent("d_Package Manager");
		
		private static GUIContent _dpackagemanager2X;
		/// <summary>
		/// d_Package Manager@2x
		/// </summary>
		public static GUIContent DPackageManager2X => _dpackagemanager2X ??= EditorGUIUtility.IconContent("d_Package Manager@2x");

		private static GUIContent _dparticleeffect;
		/// <summary>
		/// d_Particle Effect
		/// </summary>
		public static GUIContent DParticleEffect => _dparticleeffect ??= EditorGUIUtility.IconContent("d_Particle Effect");

		private static GUIContent _dparticleshapetoolon;
		/// <summary>
		/// d_ParticleShapeTool On
		/// </summary>
		public static GUIContent DParticleshapetoolOn => _dparticleshapetoolon ??= EditorGUIUtility.IconContent("d_ParticleShapeTool On");

		private static GUIContent _dparticleshapetoolon2X;
		/// <summary>
		/// d_ParticleShapeTool On@2x
		/// </summary>
		public static GUIContent DParticleshapetoolOn2X => _dparticleshapetoolon2X ??= EditorGUIUtility.IconContent("d_ParticleShapeTool On@2x");

		private static GUIContent _dparticleshapetoolon3X;
		/// <summary>
		/// d_ParticleShapeTool On@3x
		/// </summary>
		public static GUIContent DParticleshapetoolOn3X => _dparticleshapetoolon3X ??= EditorGUIUtility.IconContent("d_ParticleShapeTool On@3x");

		private static GUIContent _dparticleshapetoolon4X;
		/// <summary>
		/// d_ParticleShapeTool On@4x
		/// </summary>
		public static GUIContent DParticleshapetoolOn4X => _dparticleshapetoolon4X ??= EditorGUIUtility.IconContent("d_ParticleShapeTool On@4x");

		private static GUIContent _dparticleshapetool;
		/// <summary>
		/// d_ParticleShapeTool
		/// </summary>
		public static GUIContent DParticleshapetool => _dparticleshapetool ??= EditorGUIUtility.IconContent("d_ParticleShapeTool");

		private static GUIContent _dparticleshapetool2X;
		/// <summary>
		/// d_ParticleShapeTool@2x
		/// </summary>
		public static GUIContent DParticleshapetool2X => _dparticleshapetool2X ??= EditorGUIUtility.IconContent("d_ParticleShapeTool@2x");

		private static GUIContent _dparticleshapetool3X;
		/// <summary>
		/// d_ParticleShapeTool@3x
		/// </summary>
		public static GUIContent DParticleshapetool3X => _dparticleshapetool3X ??= EditorGUIUtility.IconContent("d_ParticleShapeTool@3x");

		private static GUIContent _dparticleshapetool4X;
		/// <summary>
		/// d_ParticleShapeTool@4x
		/// </summary>
		public static GUIContent DParticleshapetool4X => _dparticleshapetool4X ??= EditorGUIUtility.IconContent("d_ParticleShapeTool@4x");

		private static GUIContent _dpausebuttonon;
		/// <summary>
		/// d_PauseButton On
		/// </summary>
		public static GUIContent DPausebuttonOn => _dpausebuttonon ??= EditorGUIUtility.IconContent("d_PauseButton On");

		private static GUIContent _dpausebuttonon2X;
		/// <summary>
		/// d_PauseButton On@2x
		/// </summary>
		public static GUIContent DPausebuttonOn2X => _dpausebuttonon2X ??= EditorGUIUtility.IconContent("d_PauseButton On@2x");

		private static GUIContent _dpausebutton;
		/// <summary>
		/// d_PauseButton
		/// </summary>
		public static GUIContent DPausebutton => _dpausebutton ??= EditorGUIUtility.IconContent("d_PauseButton");

		private static GUIContent _dpausebutton2X;
		/// <summary>
		/// d_PauseButton@2x
		/// </summary>
		public static GUIContent DPausebutton2X => _dpausebutton2X ??= EditorGUIUtility.IconContent("d_PauseButton@2x");

		private static GUIContent _dplaybuttonon;
		/// <summary>
		/// d_PlayButton On
		/// </summary>
		public static GUIContent DPlaybuttonOn => _dplaybuttonon ??= EditorGUIUtility.IconContent("d_PlayButton On");

		private static GUIContent _dplaybuttonon2X;
		/// <summary>
		/// d_PlayButton On@2x
		/// </summary>
		public static GUIContent DPlaybuttonOn2X => _dplaybuttonon2X ??= EditorGUIUtility.IconContent("d_PlayButton On@2x");

		private static GUIContent _dplaybutton;
		/// <summary>
		/// d_PlayButton
		/// </summary>
		public static GUIContent DPlaybutton => _dplaybutton ??= EditorGUIUtility.IconContent("d_PlayButton");

		private static GUIContent _dplaybutton2X;
		/// <summary>
		/// d_PlayButton@2x
		/// </summary>
		public static GUIContent DPlaybutton2X => _dplaybutton2X ??= EditorGUIUtility.IconContent("d_PlayButton@2x");

		private static GUIContent _dplaybuttonprofileon;
		/// <summary>
		/// d_PlayButtonProfile On
		/// </summary>
		public static GUIContent DPlaybuttonprofileOn => _dplaybuttonprofileon ??= EditorGUIUtility.IconContent("d_PlayButtonProfile On");

		private static GUIContent _dplaybuttonprofile;
		/// <summary>
		/// d_PlayButtonProfile
		/// </summary>
		public static GUIContent DPlaybuttonprofile => _dplaybuttonprofile ??= EditorGUIUtility.IconContent("d_PlayButtonProfile");

		private static GUIContent _dplayloopoff;
		/// <summary>
		/// d_playLoopOff
		/// </summary>
		public static GUIContent DPlayloopoff => _dplayloopoff ??= EditorGUIUtility.IconContent("d_playLoopOff");

		private static GUIContent _dplayloopon;
		/// <summary>
		/// d_playLoopOn
		/// </summary>
		public static GUIContent DPlayloopon => _dplayloopon ??= EditorGUIUtility.IconContent("d_playLoopOn");

		private static GUIContent _dpreaudioautoplayoff;
		/// <summary>
		/// d_preAudioAutoPlayOff
		/// </summary>
		public static GUIContent DPreaudioautoplayoff => _dpreaudioautoplayoff ??= EditorGUIUtility.IconContent("d_preAudioAutoPlayOff");

		private static GUIContent _dpreaudioautoplayoff2X;
		/// <summary>
		/// d_preAudioAutoPlayOff@2x
		/// </summary>
		public static GUIContent DPreaudioautoplayoff2X => _dpreaudioautoplayoff2X ??= EditorGUIUtility.IconContent("d_preAudioAutoPlayOff@2x");

		private static GUIContent _dpreaudioautoplayon;
		/// <summary>
		/// d_preAudioAutoPlayOn
		/// </summary>
		public static GUIContent DPreaudioautoplayon => _dpreaudioautoplayon ??= EditorGUIUtility.IconContent("d_preAudioAutoPlayOn");

		private static GUIContent _dpreaudioloopoff;
		/// <summary>
		/// d_preAudioLoopOff
		/// </summary>
		public static GUIContent DPreaudioloopoff => _dpreaudioloopoff ??= EditorGUIUtility.IconContent("d_preAudioLoopOff");

		private static GUIContent _dpreaudioloopoff2X;
		/// <summary>
		/// d_preAudioLoopOff@2x
		/// </summary>
		public static GUIContent DPreaudioloopoff2X => _dpreaudioloopoff2X ??= EditorGUIUtility.IconContent("d_preAudioLoopOff@2x");

		private static GUIContent _dpreaudioloopon;
		/// <summary>
		/// d_preAudioLoopOn
		/// </summary>
		public static GUIContent DPreaudioloopon => _dpreaudioloopon ??= EditorGUIUtility.IconContent("d_preAudioLoopOn");

		private static GUIContent _dpreaudioplayoff;
		/// <summary>
		/// d_preAudioPlayOff
		/// </summary>
		public static GUIContent DPreaudioplayoff => _dpreaudioplayoff ??= EditorGUIUtility.IconContent("d_preAudioPlayOff");

		private static GUIContent _dpreaudioplayon;
		/// <summary>
		/// d_preAudioPlayOn
		/// </summary>
		public static GUIContent DPreaudioplayon => _dpreaudioplayon ??= EditorGUIUtility.IconContent("d_preAudioPlayOn");

		private static GUIContent _dprematcube;
		/// <summary>
		/// d_PreMatCube
		/// </summary>
		public static GUIContent DPrematcube => _dprematcube ??= EditorGUIUtility.IconContent("d_PreMatCube");

		private static GUIContent _dprematcube2X;
		/// <summary>
		/// d_PreMatCube@2x
		/// </summary>
		public static GUIContent DPrematcube2X => _dprematcube2X ??= EditorGUIUtility.IconContent("d_PreMatCube@2x");

		private static GUIContent _dprematcylinder;
		/// <summary>
		/// d_PreMatCylinder
		/// </summary>
		public static GUIContent DPrematcylinder => _dprematcylinder ??= EditorGUIUtility.IconContent("d_PreMatCylinder");

		private static GUIContent _dprematcylinder2X;
		/// <summary>
		/// d_PreMatCylinder@2x
		/// </summary>
		public static GUIContent DPrematcylinder2X => _dprematcylinder2X ??= EditorGUIUtility.IconContent("d_PreMatCylinder@2x");

		private static GUIContent _dprematlight0;
		/// <summary>
		/// d_PreMatLight0
		/// </summary>
		public static GUIContent DPrematlight0 => _dprematlight0 ??= EditorGUIUtility.IconContent("d_PreMatLight0");

		private static GUIContent _dprematlight02X;
		/// <summary>
		/// d_PreMatLight0@2x
		/// </summary>
		public static GUIContent DPrematlight02X => _dprematlight02X ??= EditorGUIUtility.IconContent("d_PreMatLight0@2x");

		private static GUIContent _dprematlight1;
		/// <summary>
		/// d_PreMatLight1
		/// </summary>
		public static GUIContent DPrematlight1 => _dprematlight1 ??= EditorGUIUtility.IconContent("d_PreMatLight1");

		private static GUIContent _dprematlight12X;
		/// <summary>
		/// d_PreMatLight1@2x
		/// </summary>
		public static GUIContent DPrematlight12X => _dprematlight12X ??= EditorGUIUtility.IconContent("d_PreMatLight1@2x");

		private static GUIContent _dprematquad;
		/// <summary>
		/// d_PreMatQuad
		/// </summary>
		public static GUIContent DPrematquad => _dprematquad ??= EditorGUIUtility.IconContent("d_PreMatQuad");

		private static GUIContent _dprematquad2X;
		/// <summary>
		/// d_PreMatQuad@2x
		/// </summary>
		public static GUIContent DPrematquad2X => _dprematquad2X ??= EditorGUIUtility.IconContent("d_PreMatQuad@2x");

		private static GUIContent _dprematsphere;
		/// <summary>
		/// d_PreMatSphere
		/// </summary>
		public static GUIContent DPrematsphere => _dprematsphere ??= EditorGUIUtility.IconContent("d_PreMatSphere");

		private static GUIContent _dprematsphere2X;
		/// <summary>
		/// d_PreMatSphere@2x
		/// </summary>
		public static GUIContent DPrematsphere2X => _dprematsphere2X ??= EditorGUIUtility.IconContent("d_PreMatSphere@2x");

		private static GUIContent _dpremattorus;
		/// <summary>
		/// d_PreMatTorus
		/// </summary>
		public static GUIContent DPremattorus => _dpremattorus ??= EditorGUIUtility.IconContent("d_PreMatTorus");

		private static GUIContent _dpremattorus2X;
		/// <summary>
		/// d_PreMatTorus@2x
		/// </summary>
		public static GUIContent DPremattorus2X => _dpremattorus2X ??= EditorGUIUtility.IconContent("d_PreMatTorus@2x");

		private static GUIContent _dpresetcontext;
		/// <summary>
		/// d_Preset.Context
		/// </summary>
		public static GUIContent DPresetContext => _dpresetcontext ??= EditorGUIUtility.IconContent("d_Preset.Context");

		private static GUIContent _dpresetcontext2X;
		/// <summary>
		/// d_Preset.Context@2x
		/// </summary>
		public static GUIContent DPresetContext2X => _dpresetcontext2X ??= EditorGUIUtility.IconContent("d_Preset.Context@2x");

		private static GUIContent _dpretexa;
		/// <summary>
		/// d_PreTexA
		/// </summary>
		public static GUIContent DPretexa => _dpretexa ??= EditorGUIUtility.IconContent("d_PreTexA");

		private static GUIContent _dpretexa2X;
		/// <summary>
		/// d_PreTexA@2x
		/// </summary>
		public static GUIContent DPretexa2X => _dpretexa2X ??= EditorGUIUtility.IconContent("d_PreTexA@2x");

		private static GUIContent _dpretexb;
		/// <summary>
		/// d_PreTexB
		/// </summary>
		public static GUIContent DPretexb => _dpretexb ??= EditorGUIUtility.IconContent("d_PreTexB");

		private static GUIContent _dpretexb2X;
		/// <summary>
		/// d_PreTexB@2x
		/// </summary>
		public static GUIContent DPretexb2X => _dpretexb2X ??= EditorGUIUtility.IconContent("d_PreTexB@2x");

		private static GUIContent _dpretexg;
		/// <summary>
		/// d_PreTexG
		/// </summary>
		public static GUIContent DPretexg => _dpretexg ??= EditorGUIUtility.IconContent("d_PreTexG");

		private static GUIContent _dpretexg2X;
		/// <summary>
		/// d_PreTexG@2x
		/// </summary>
		public static GUIContent DPretexg2X => _dpretexg2X ??= EditorGUIUtility.IconContent("d_PreTexG@2x");

		private static GUIContent _dpretexr;
		/// <summary>
		/// d_PreTexR
		/// </summary>
		public static GUIContent DPretexr => _dpretexr ??= EditorGUIUtility.IconContent("d_PreTexR");

		private static GUIContent _dpretexr2X;
		/// <summary>
		/// d_PreTexR@2x
		/// </summary>
		public static GUIContent DPretexr2X => _dpretexr2X ??= EditorGUIUtility.IconContent("d_PreTexR@2x");

		private static GUIContent _dpretexrgb;
		/// <summary>
		/// d_PreTexRGB
		/// </summary>
		public static GUIContent DPretexrgb => _dpretexrgb ??= EditorGUIUtility.IconContent("d_PreTexRGB");

		private static GUIContent _dpretexrgb2X;
		/// <summary>
		/// d_PreTexRGB@2x
		/// </summary>
		public static GUIContent DPretexrgb2X => _dpretexrgb2X ??= EditorGUIUtility.IconContent("d_PreTexRGB@2x");

		private static GUIContent _dpretexturealpha;
		/// <summary>
		/// d_PreTextureAlpha
		/// </summary>
		public static GUIContent DPretexturealpha => _dpretexturealpha ??= EditorGUIUtility.IconContent("d_PreTextureAlpha");

		private static GUIContent _dpretexturemipmaphigh;
		/// <summary>
		/// d_PreTextureMipMapHigh
		/// </summary>
		public static GUIContent DPretexturemipmaphigh => _dpretexturemipmaphigh ??= EditorGUIUtility.IconContent("d_PreTextureMipMapHigh");

		private static GUIContent _dpretexturemipmaplow;
		/// <summary>
		/// d_PreTextureMipMapLow
		/// </summary>
		public static GUIContent DPretexturemipmaplow => _dpretexturemipmaplow ??= EditorGUIUtility.IconContent("d_PreTextureMipMapLow");

		private static GUIContent _dpretexturergb;
		/// <summary>
		/// d_PreTextureRGB
		/// </summary>
		public static GUIContent DPretexturergb => _dpretexturergb ??= EditorGUIUtility.IconContent("d_PreTextureRGB");

		private static GUIContent _dprofileraudio;
		/// <summary>
		/// d_Profiler.Audio
		/// </summary>
		public static GUIContent DProfilerAudio => _dprofileraudio ??= EditorGUIUtility.IconContent("d_Profiler.Audio");

		private static GUIContent _dprofileraudio2X;
		/// <summary>
		/// d_Profiler.Audio@2x
		/// </summary>
		public static GUIContent DProfilerAudio2X => _dprofileraudio2X ??= EditorGUIUtility.IconContent("d_Profiler.Audio@2x");

		private static GUIContent _dprofilercpu;
		/// <summary>
		/// d_Profiler.CPU
		/// </summary>
		public static GUIContent DProfilerCpu => _dprofilercpu ??= EditorGUIUtility.IconContent("d_Profiler.CPU");

		private static GUIContent _dprofilercpu2X;
		/// <summary>
		/// d_Profiler.CPU@2x
		/// </summary>
		public static GUIContent DProfilerCpu2X => _dprofilercpu2X ??= EditorGUIUtility.IconContent("d_Profiler.CPU@2x");

		private static GUIContent _dprofilerfirstframe;
		/// <summary>
		/// d_Profiler.FirstFrame
		/// </summary>
		public static GUIContent DProfilerFirstframe => _dprofilerfirstframe ??= EditorGUIUtility.IconContent("d_Profiler.FirstFrame");

		private static GUIContent _dprofilerglobalillumination;
		/// <summary>
		/// d_Profiler.GlobalIllumination
		/// </summary>
		public static GUIContent DProfilerGlobalillumination => _dprofilerglobalillumination ??= EditorGUIUtility.IconContent("d_Profiler.GlobalIllumination");

		private static GUIContent _dprofilerglobalillumination2X;
		/// <summary>
		/// d_Profiler.GlobalIllumination@2x
		/// </summary>
		public static GUIContent DProfilerGlobalillumination2X => _dprofilerglobalillumination2X ??= EditorGUIUtility.IconContent("d_Profiler.GlobalIllumination@2x");

		private static GUIContent _dprofilergpu;
		/// <summary>
		/// d_Profiler.GPU
		/// </summary>
		public static GUIContent DProfilerGpu => _dprofilergpu ??= EditorGUIUtility.IconContent("d_Profiler.GPU");

		private static GUIContent _dprofilergpu2X;
		/// <summary>
		/// d_Profiler.GPU@2x
		/// </summary>
		public static GUIContent DProfilerGpu2X => _dprofilergpu2X ??= EditorGUIUtility.IconContent("d_Profiler.GPU@2x");

		private static GUIContent _dprofilerlastframe;
		/// <summary>
		/// d_Profiler.LastFrame
		/// </summary>
		public static GUIContent DProfilerLastframe => _dprofilerlastframe ??= EditorGUIUtility.IconContent("d_Profiler.LastFrame");

		private static GUIContent _dprofilermemory;
		/// <summary>
		/// d_Profiler.Memory
		/// </summary>
		public static GUIContent DProfilerMemory => _dprofilermemory ??= EditorGUIUtility.IconContent("d_Profiler.Memory");

		private static GUIContent _dprofilermemory2X;
		/// <summary>
		/// d_Profiler.Memory@2x
		/// </summary>
		public static GUIContent DProfilerMemory2X => _dprofilermemory2X ??= EditorGUIUtility.IconContent("d_Profiler.Memory@2x");

		private static GUIContent _dprofilernetwork;
		/// <summary>
		/// d_Profiler.Network
		/// </summary>
		public static GUIContent DProfilerNetwork => _dprofilernetwork ??= EditorGUIUtility.IconContent("d_Profiler.Network");

		private static GUIContent _dprofilernetworkmessages;
		/// <summary>
		/// d_Profiler.NetworkMessages
		/// </summary>
		public static GUIContent DProfilerNetworkmessages => _dprofilernetworkmessages ??= EditorGUIUtility.IconContent("d_Profiler.NetworkMessages");

		private static GUIContent _dprofilernetworkmessages2X;
		/// <summary>
		/// d_Profiler.NetworkMessages@2x
		/// </summary>
		public static GUIContent DProfilerNetworkmessages2X => _dprofilernetworkmessages2X ??= EditorGUIUtility.IconContent("d_Profiler.NetworkMessages@2x");

		private static GUIContent _dprofilernetworkoperations;
		/// <summary>
		/// d_Profiler.NetworkOperations
		/// </summary>
		public static GUIContent DProfilerNetworkoperations => _dprofilernetworkoperations ??= EditorGUIUtility.IconContent("d_Profiler.NetworkOperations");

		private static GUIContent _dprofilernetworkoperations2X;
		/// <summary>
		/// d_Profiler.NetworkOperations@2x
		/// </summary>
		public static GUIContent DProfilerNetworkoperations2X => _dprofilernetworkoperations2X ??= EditorGUIUtility.IconContent("d_Profiler.NetworkOperations@2x");

		private static GUIContent _dprofilernextframe;
		/// <summary>
		/// d_Profiler.NextFrame
		/// </summary>
		public static GUIContent DProfilerNextframe => _dprofilernextframe ??= EditorGUIUtility.IconContent("d_Profiler.NextFrame");

		private static GUIContent _dprofilerphysics;
		/// <summary>
		/// d_Profiler.Physics
		/// </summary>
		public static GUIContent DProfilerPhysics => _dprofilerphysics ??= EditorGUIUtility.IconContent("d_Profiler.Physics");

		private static GUIContent _dprofilerphysics2d;
		/// <summary>
		/// d_Profiler.Physics2D
		/// </summary>
		public static GUIContent DProfilerPhysics2d => _dprofilerphysics2d ??= EditorGUIUtility.IconContent("d_Profiler.Physics2D");

		private static GUIContent _dprofilerphysics2d2X;
		/// <summary>
		/// d_Profiler.Physics2D@2x
		/// </summary>
		public static GUIContent DProfilerPhysics2d2X => _dprofilerphysics2d2X ??= EditorGUIUtility.IconContent("d_Profiler.Physics2D@2x");

		private static GUIContent _dprofilerphysics2X;
		/// <summary>
		/// d_Profiler.Physics@2x
		/// </summary>
		public static GUIContent DProfilerPhysics2X => _dprofilerphysics2X ??= EditorGUIUtility.IconContent("d_Profiler.Physics@2x");

		private static GUIContent _dprofilerprevframe;
		/// <summary>
		/// d_Profiler.PrevFrame
		/// </summary>
		public static GUIContent DProfilerPrevframe => _dprofilerprevframe ??= EditorGUIUtility.IconContent("d_Profiler.PrevFrame");

		private static GUIContent _dprofilerrecord;
		/// <summary>
		/// d_Profiler.Record
		/// </summary>
		public static GUIContent DProfilerRecord => _dprofilerrecord ??= EditorGUIUtility.IconContent("d_Profiler.Record");

		private static GUIContent _dprofilerrendering;
		/// <summary>
		/// d_Profiler.Rendering
		/// </summary>
		public static GUIContent DProfilerRendering => _dprofilerrendering ??= EditorGUIUtility.IconContent("d_Profiler.Rendering");

		private static GUIContent _dprofilerrendering2X;
		/// <summary>
		/// d_Profiler.Rendering@2x
		/// </summary>
		public static GUIContent DProfilerRendering2X => _dprofilerrendering2X ??= EditorGUIUtility.IconContent("d_Profiler.Rendering@2x");

		private static GUIContent _dprofilerui;
		/// <summary>
		/// d_Profiler.UI
		/// </summary>
		public static GUIContent DProfilerUi => _dprofilerui ??= EditorGUIUtility.IconContent("d_Profiler.UI");

		private static GUIContent _dprofilerui2X;
		/// <summary>
		/// d_Profiler.UI@2x
		/// </summary>
		public static GUIContent DProfilerUi2X => _dprofilerui2X ??= EditorGUIUtility.IconContent("d_Profiler.UI@2x");

		private static GUIContent _dprofileruidetails;
		/// <summary>
		/// d_Profiler.UIDetails
		/// </summary>
		public static GUIContent DProfilerUidetails => _dprofileruidetails ??= EditorGUIUtility.IconContent("d_Profiler.UIDetails");

		private static GUIContent _dprofileruidetails2X;
		/// <summary>
		/// d_Profiler.UIDetails@2x
		/// </summary>
		public static GUIContent DProfilerUidetails2X => _dprofileruidetails2X ??= EditorGUIUtility.IconContent("d_Profiler.UIDetails@2x");

		private static GUIContent _dprofilervideo;
		/// <summary>
		/// d_Profiler.Video
		/// </summary>
		public static GUIContent DProfilerVideo => _dprofilervideo ??= EditorGUIUtility.IconContent("d_Profiler.Video");

		private static GUIContent _dprofilervideo2X;
		/// <summary>
		/// d_Profiler.Video@2x
		/// </summary>
		public static GUIContent DProfilerVideo2X => _dprofilervideo2X ??= EditorGUIUtility.IconContent("d_Profiler.Video@2x");

		private static GUIContent _dprofilercolumnwarningcount;
		/// <summary>
		/// d_ProfilerColumn.WarningCount
		/// </summary>
		public static GUIContent DProfilercolumnWarningcount => _dprofilercolumnwarningcount ??= EditorGUIUtility.IconContent("d_ProfilerColumn.WarningCount");

		private static GUIContent _dprogress;
		/// <summary>
		/// d_Progress
		/// </summary>
		public static GUIContent DProgress => _dprogress ??= EditorGUIUtility.IconContent("d_Progress");

		private static GUIContent _dprogress2X;
		/// <summary>
		/// d_Progress@2x
		/// </summary>
		public static GUIContent DProgress2X => _dprogress2X ??= EditorGUIUtility.IconContent("d_Progress@2x");

		private static GUIContent _dproject;
		/// <summary>
		/// d_Project
		/// </summary>
		public static GUIContent DProject => _dproject ??= EditorGUIUtility.IconContent("d_Project");

		private static GUIContent _dproject2X;
		/// <summary>
		/// d_Project@2x
		/// </summary>
		public static GUIContent DProject2X => _dproject2X ??= EditorGUIUtility.IconContent("d_Project@2x");

		private static GUIContent _drecordoff;
		/// <summary>
		/// d_Record Off
		/// </summary>
		public static GUIContent DRecordOff => _drecordoff ??= EditorGUIUtility.IconContent("d_Record Off");

		private static GUIContent _drecordoff2X;
		/// <summary>
		/// d_Record Off@2x
		/// </summary>
		public static GUIContent DRecordOff2X => _drecordoff2X ??= EditorGUIUtility.IconContent("d_Record Off@2x");

		private static GUIContent _drecordon;
		/// <summary>
		/// d_Record On
		/// </summary>
		public static GUIContent DRecordOn => _drecordon ??= EditorGUIUtility.IconContent("d_Record On");

		private static GUIContent _drecordon2X;
		/// <summary>
		/// d_Record On@2x
		/// </summary>
		public static GUIContent DRecordOn2X => _drecordon2X ??= EditorGUIUtility.IconContent("d_Record On@2x");

		private static GUIContent _drecttoolon;
		/// <summary>
		/// d_RectTool On
		/// </summary>
		public static GUIContent DRecttoolOn => _drecttoolon ??= EditorGUIUtility.IconContent("d_RectTool On");

		private static GUIContent _drecttoolon2X;
		/// <summary>
		/// d_RectTool On@2x
		/// </summary>
		public static GUIContent DRecttoolOn2X => _drecttoolon2X ??= EditorGUIUtility.IconContent("d_RectTool On@2x");

		private static GUIContent _drecttool;
		/// <summary>
		/// d_RectTool
		/// </summary>
		public static GUIContent DRecttool => _drecttool ??= EditorGUIUtility.IconContent("d_RectTool");

		private static GUIContent _drecttool2X;
		/// <summary>
		/// d_RectTool@2x
		/// </summary>
		public static GUIContent DRecttool2X => _drecttool2X ??= EditorGUIUtility.IconContent("d_RectTool@2x");

		private static GUIContent _drecttransformblueprint;
		/// <summary>
		/// d_RectTransformBlueprint
		/// </summary>
		public static GUIContent DRecttransformblueprint => _drecttransformblueprint ??= EditorGUIUtility.IconContent("d_RectTransformBlueprint");

		private static GUIContent _drecttransformraw;
		/// <summary>
		/// d_RectTransformRaw
		/// </summary>
		public static GUIContent DRecttransformraw => _drecttransformraw ??= EditorGUIUtility.IconContent("d_RectTransformRaw");

		private static GUIContent _dredgroove;
		/// <summary>
		/// d_redGroove
		/// </summary>
		public static GUIContent DRedgroove => _dredgroove ??= EditorGUIUtility.IconContent("d_redGroove");

		private static GUIContent _dreflectionprobeselector;
		/// <summary>
		/// d_ReflectionProbeSelector
		/// </summary>
		public static GUIContent DReflectionprobeselector => _dreflectionprobeselector ??= EditorGUIUtility.IconContent("d_ReflectionProbeSelector");

		private static GUIContent _dreflectionprobeselector2X;
		/// <summary>
		/// d_ReflectionProbeSelector@2x
		/// </summary>
		public static GUIContent DReflectionprobeselector2X => _dreflectionprobeselector2X ??= EditorGUIUtility.IconContent("d_ReflectionProbeSelector@2x");

		private static GUIContent _drefresh;
		/// <summary>
		/// d_Refresh
		/// </summary>
		public static GUIContent DRefresh => _drefresh ??= EditorGUIUtility.IconContent("d_Refresh");

		private static GUIContent _drefresh2X;
		/// <summary>
		/// d_Refresh@2x
		/// </summary>
		public static GUIContent DRefresh2X => _drefresh2X ??= EditorGUIUtility.IconContent("d_Refresh@2x");

		private static GUIContent _drightbracket;
		/// <summary>
		/// d_rightBracket
		/// </summary>
		public static GUIContent DRightbracket => _drightbracket ??= EditorGUIUtility.IconContent("d_rightBracket");

		private static GUIContent _drotatetoolon;
		/// <summary>
		/// d_RotateTool On
		/// </summary>
		public static GUIContent DRotatetoolOn => _drotatetoolon ??= EditorGUIUtility.IconContent("d_RotateTool On");

		private static GUIContent _drotatetoolon2X;
		/// <summary>
		/// d_RotateTool On@2x
		/// </summary>
		public static GUIContent DRotatetoolOn2X => _drotatetoolon2X ??= EditorGUIUtility.IconContent("d_RotateTool On@2x");

		private static GUIContent _drotatetool;
		/// <summary>
		/// d_RotateTool
		/// </summary>
		public static GUIContent DRotatetool => _drotatetool ??= EditorGUIUtility.IconContent("d_RotateTool");

		private static GUIContent _drotatetool2X;
		/// <summary>
		/// d_RotateTool@2x
		/// </summary>
		public static GUIContent DRotatetool2X => _drotatetool2X ??= EditorGUIUtility.IconContent("d_RotateTool@2x");

		private static GUIContent _dsaveas;
		/// <summary>
		/// d_SaveAs
		/// </summary>
		public static GUIContent DSaveas => _dsaveas ??= EditorGUIUtility.IconContent("d_SaveAs");

		private static GUIContent _dsaveas2X;
		/// <summary>
		/// d_SaveAs@2x
		/// </summary>
		public static GUIContent DSaveas2X => _dsaveas2X ??= EditorGUIUtility.IconContent("d_SaveAs@2x");

		private static GUIContent _dscaletoolon;
		/// <summary>
		/// d_ScaleTool On
		/// </summary>
		public static GUIContent DScaletoolOn => _dscaletoolon ??= EditorGUIUtility.IconContent("d_ScaleTool On");

		private static GUIContent _dscaletoolon2X;
		/// <summary>
		/// d_ScaleTool On@2x
		/// </summary>
		public static GUIContent DScaletoolOn2X => _dscaletoolon2X ??= EditorGUIUtility.IconContent("d_ScaleTool On@2x");

		private static GUIContent _dscaletool;
		/// <summary>
		/// d_ScaleTool
		/// </summary>
		public static GUIContent DScaletool => _dscaletool ??= EditorGUIUtility.IconContent("d_ScaleTool");

		private static GUIContent _dscaletool2X;
		/// <summary>
		/// d_ScaleTool@2x
		/// </summary>
		public static GUIContent DScaletool2X => _dscaletool2X ??= EditorGUIUtility.IconContent("d_ScaleTool@2x");

		private static GUIContent _dscenepickingnotpickablemixed;
		/// <summary>
		/// d_scenepicking_notpickable-mixed
		/// </summary>
		public static GUIContent DScenepickingNotpickableMixed => _dscenepickingnotpickablemixed ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable-mixed");

		private static GUIContent _dscenepickingnotpickablemixed2X;
		/// <summary>
		/// d_scenepicking_notpickable-mixed@2x
		/// </summary>
		public static GUIContent DScenepickingNotpickableMixed2X => _dscenepickingnotpickablemixed2X ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable-mixed@2x");

		private static GUIContent _dscenepickingnotpickablemixedhover;
		/// <summary>
		/// d_scenepicking_notpickable-mixed_hover
		/// </summary>
		public static GUIContent DScenepickingNotpickableMixedHover => _dscenepickingnotpickablemixedhover ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable-mixed_hover");

		private static GUIContent _dscenepickingnotpickablemixedhover2X;
		/// <summary>
		/// d_scenepicking_notpickable-mixed_hover@2x
		/// </summary>
		public static GUIContent DScenepickingNotpickableMixedHover2X => _dscenepickingnotpickablemixedhover2X ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable-mixed_hover@2x");

		private static GUIContent _dscenepickingnotpickable;
		/// <summary>
		/// d_scenepicking_notpickable
		/// </summary>
		public static GUIContent DScenepickingNotpickable => _dscenepickingnotpickable ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable");

		private static GUIContent _dscenepickingnotpickable2X;
		/// <summary>
		/// d_scenepicking_notpickable@2x
		/// </summary>
		public static GUIContent DScenepickingNotpickable2X => _dscenepickingnotpickable2X ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable@2x");

		private static GUIContent _dscenepickingnotpickablehover;
		/// <summary>
		/// d_scenepicking_notpickable_hover
		/// </summary>
		public static GUIContent DScenepickingNotpickableHover => _dscenepickingnotpickablehover ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable_hover");

		private static GUIContent _dscenepickingnotpickablehover2X;
		/// <summary>
		/// d_scenepicking_notpickable_hover@2x
		/// </summary>
		public static GUIContent DScenepickingNotpickableHover2X => _dscenepickingnotpickablehover2X ??= EditorGUIUtility.IconContent("d_scenepicking_notpickable_hover@2x");

		private static GUIContent _dscenepickingpickablemixed;
		/// <summary>
		/// d_scenepicking_pickable-mixed
		/// </summary>
		public static GUIContent DScenepickingPickableMixed => _dscenepickingpickablemixed ??= EditorGUIUtility.IconContent("d_scenepicking_pickable-mixed");

		private static GUIContent _dscenepickingpickablemixed2X;
		/// <summary>
		/// d_scenepicking_pickable-mixed@2x
		/// </summary>
		public static GUIContent DScenepickingPickableMixed2X => _dscenepickingpickablemixed2X ??= EditorGUIUtility.IconContent("d_scenepicking_pickable-mixed@2x");

		private static GUIContent _dscenepickingpickablemixedhover;
		/// <summary>
		/// d_scenepicking_pickable-mixed_hover
		/// </summary>
		public static GUIContent DScenepickingPickableMixedHover => _dscenepickingpickablemixedhover ??= EditorGUIUtility.IconContent("d_scenepicking_pickable-mixed_hover");

		private static GUIContent _dscenepickingpickablemixedhover2X;
		/// <summary>
		/// d_scenepicking_pickable-mixed_hover@2x
		/// </summary>
		public static GUIContent DScenepickingPickableMixedHover2X => _dscenepickingpickablemixedhover2X ??= EditorGUIUtility.IconContent("d_scenepicking_pickable-mixed_hover@2x");

		private static GUIContent _dscenepickingpickable;
		/// <summary>
		/// d_scenepicking_pickable
		/// </summary>
		public static GUIContent DScenepickingPickable => _dscenepickingpickable ??= EditorGUIUtility.IconContent("d_scenepicking_pickable");

		private static GUIContent _dscenepickingpickable2X;
		/// <summary>
		/// d_scenepicking_pickable@2x
		/// </summary>
		public static GUIContent DScenepickingPickable2X => _dscenepickingpickable2X ??= EditorGUIUtility.IconContent("d_scenepicking_pickable@2x");

		private static GUIContent _dscenepickingpickablehover;
		/// <summary>
		/// d_scenepicking_pickable_hover
		/// </summary>
		public static GUIContent DScenepickingPickableHover => _dscenepickingpickablehover ??= EditorGUIUtility.IconContent("d_scenepicking_pickable_hover");

		private static GUIContent _dscenepickingpickablehover2X;
		/// <summary>
		/// d_scenepicking_pickable_hover@2x
		/// </summary>
		public static GUIContent DScenepickingPickableHover2X => _dscenepickingpickablehover2X ??= EditorGUIUtility.IconContent("d_scenepicking_pickable_hover@2x");

		private static GUIContent _dsceneview2d;
		/// <summary>
		/// d_SceneView2D
		/// </summary>
		public static GUIContent DSceneview2d => _dsceneview2d ??= EditorGUIUtility.IconContent("d_SceneView2D");

		private static GUIContent _dsceneview2d2X;
		/// <summary>
		/// d_SceneView2D@2x
		/// </summary>
		public static GUIContent DSceneview2d2X => _dsceneview2d2X ??= EditorGUIUtility.IconContent("d_SceneView2D@2x");

		private static GUIContent _dsceneviewalpha;
		/// <summary>
		/// d_SceneViewAlpha
		/// </summary>
		public static GUIContent DSceneviewalpha => _dsceneviewalpha ??= EditorGUIUtility.IconContent("d_SceneViewAlpha");

		private static GUIContent _dsceneviewaudiooff;
		/// <summary>
		/// d_SceneViewAudio Off
		/// </summary>
		public static GUIContent DSceneviewaudioOff => _dsceneviewaudiooff ??= EditorGUIUtility.IconContent("d_SceneViewAudio Off");

		private static GUIContent _dsceneviewaudiooff2X;
		/// <summary>
		/// d_SceneViewAudio Off@2x
		/// </summary>
		public static GUIContent DSceneviewaudioOff2X => _dsceneviewaudiooff2X ??= EditorGUIUtility.IconContent("d_SceneViewAudio Off@2x");

		private static GUIContent _dsceneviewaudio;
		/// <summary>
		/// d_SceneViewAudio
		/// </summary>
		public static GUIContent DSceneviewaudio => _dsceneviewaudio ??= EditorGUIUtility.IconContent("d_SceneViewAudio");

		private static GUIContent _dsceneviewaudio2X;
		/// <summary>
		/// d_SceneViewAudio@2x
		/// </summary>
		public static GUIContent DSceneviewaudio2X => _dsceneviewaudio2X ??= EditorGUIUtility.IconContent("d_SceneViewAudio@2x");

		private static GUIContent _dsceneviewcamera;
		/// <summary>
		/// d_SceneViewCamera
		/// </summary>
		public static GUIContent DSceneviewcamera => _dsceneviewcamera ??= EditorGUIUtility.IconContent("d_SceneViewCamera");

		private static GUIContent _dsceneviewcamera2X;
		/// <summary>
		/// d_SceneViewCamera@2x
		/// </summary>
		public static GUIContent DSceneviewcamera2X => _dsceneviewcamera2X ??= EditorGUIUtility.IconContent("d_SceneViewCamera@2x");

		private static GUIContent _dsceneviewfx;
		/// <summary>
		/// d_SceneViewFx
		/// </summary>
		public static GUIContent DSceneviewfx => _dsceneviewfx ??= EditorGUIUtility.IconContent("d_SceneViewFx");

		private static GUIContent _dsceneviewfx2X;
		/// <summary>
		/// d_SceneViewFX@2x
		/// </summary>
		public static GUIContent DSceneviewfx2X => _dsceneviewfx2X ??= EditorGUIUtility.IconContent("d_SceneViewFX@2x");

		private static GUIContent _dsceneviewlightingoff;
		/// <summary>
		/// d_SceneViewLighting Off
		/// </summary>
		public static GUIContent DSceneviewlightingOff => _dsceneviewlightingoff ??= EditorGUIUtility.IconContent("d_SceneViewLighting Off");

		private static GUIContent _dsceneviewlightingoff2X;
		/// <summary>
		/// d_SceneViewLighting Off@2x
		/// </summary>
		public static GUIContent DSceneviewlightingOff2X => _dsceneviewlightingoff2X ??= EditorGUIUtility.IconContent("d_SceneViewLighting Off@2x");

		private static GUIContent _dsceneviewlighting;
		/// <summary>
		/// d_SceneViewLighting
		/// </summary>
		public static GUIContent DSceneviewlighting => _dsceneviewlighting ??= EditorGUIUtility.IconContent("d_SceneViewLighting");

		private static GUIContent _dsceneviewlighting2X;
		/// <summary>
		/// d_SceneViewLighting@2x
		/// </summary>
		public static GUIContent DSceneviewlighting2X => _dsceneviewlighting2X ??= EditorGUIUtility.IconContent("d_SceneViewLighting@2x");

		private static GUIContent _dsceneviewortho;
		/// <summary>
		/// d_SceneViewOrtho
		/// </summary>
		public static GUIContent DSceneviewortho => _dsceneviewortho ??= EditorGUIUtility.IconContent("d_SceneViewOrtho");

		private static GUIContent _dsceneviewrgb;
		/// <summary>
		/// d_SceneViewRGB
		/// </summary>
		public static GUIContent DSceneviewrgb => _dsceneviewrgb ??= EditorGUIUtility.IconContent("d_SceneViewRGB");

		private static GUIContent _dsceneviewtools;
		/// <summary>
		/// d_SceneViewTools
		/// </summary>
		public static GUIContent DSceneviewtools => _dsceneviewtools ??= EditorGUIUtility.IconContent("d_SceneViewTools");

		private static GUIContent _dsceneviewtools2X;
		/// <summary>
		/// d_SceneViewTools@2x
		/// </summary>
		public static GUIContent DSceneviewtools2X => _dsceneviewtools2X ??= EditorGUIUtility.IconContent("d_SceneViewTools@2x");

		private static GUIContent _dsceneviewvisibility;
		/// <summary>
		/// d_SceneViewVisibility
		/// </summary>
		public static GUIContent DSceneviewvisibility => _dsceneviewvisibility ??= EditorGUIUtility.IconContent("d_SceneViewVisibility");

		private static GUIContent _dsceneviewvisibility2X;
		/// <summary>
		/// d_SceneViewVisibility@2x
		/// </summary>
		public static GUIContent DSceneviewvisibility2X => _dsceneviewvisibility2X ??= EditorGUIUtility.IconContent("d_SceneViewVisibility@2x");

		private static GUIContent _dscenevishiddenmixed;
		/// <summary>
		/// d_scenevis_hidden-mixed
		/// </summary>
		public static GUIContent DScenevisHiddenMixed => _dscenevishiddenmixed ??= EditorGUIUtility.IconContent("d_scenevis_hidden-mixed");

		private static GUIContent _dscenevishiddenmixed2X;
		/// <summary>
		/// d_scenevis_hidden-mixed@2x
		/// </summary>
		public static GUIContent DScenevisHiddenMixed2X => _dscenevishiddenmixed2X ??= EditorGUIUtility.IconContent("d_scenevis_hidden-mixed@2x");

		private static GUIContent _dscenevishiddenmixedhover;
		/// <summary>
		/// d_scenevis_hidden-mixed_hover
		/// </summary>
		public static GUIContent DScenevisHiddenMixedHover => _dscenevishiddenmixedhover ??= EditorGUIUtility.IconContent("d_scenevis_hidden-mixed_hover");

		private static GUIContent _dscenevishiddenmixedhover2X;
		/// <summary>
		/// d_scenevis_hidden-mixed_hover@2x
		/// </summary>
		public static GUIContent DScenevisHiddenMixedHover2X => _dscenevishiddenmixedhover2X ??= EditorGUIUtility.IconContent("d_scenevis_hidden-mixed_hover@2x");

		private static GUIContent _dscenevishidden;
		/// <summary>
		/// d_scenevis_hidden
		/// </summary>
		public static GUIContent DScenevisHidden => _dscenevishidden ??= EditorGUIUtility.IconContent("d_scenevis_hidden");

		private static GUIContent _dscenevishidden2X;
		/// <summary>
		/// d_scenevis_hidden@2x
		/// </summary>
		public static GUIContent DScenevisHidden2X => _dscenevishidden2X ??= EditorGUIUtility.IconContent("d_scenevis_hidden@2x");

		private static GUIContent _dscenevishiddenhover;
		/// <summary>
		/// d_scenevis_hidden_hover
		/// </summary>
		public static GUIContent DScenevisHiddenHover => _dscenevishiddenhover ??= EditorGUIUtility.IconContent("d_scenevis_hidden_hover");

		private static GUIContent _dscenevishiddenhover2X;
		/// <summary>
		/// d_scenevis_hidden_hover@2x
		/// </summary>
		public static GUIContent DScenevisHiddenHover2X => _dscenevishiddenhover2X ??= EditorGUIUtility.IconContent("d_scenevis_hidden_hover@2x");

		private static GUIContent _dscenevisscenehover;
		/// <summary>
		/// d_scenevis_scene_hover
		/// </summary>
		public static GUIContent DScenevisSceneHover => _dscenevisscenehover ??= EditorGUIUtility.IconContent("d_scenevis_scene_hover");

		private static GUIContent _dscenevisscenehover2X;
		/// <summary>
		/// d_scenevis_scene_hover@2x
		/// </summary>
		public static GUIContent DScenevisSceneHover2X => _dscenevisscenehover2X ??= EditorGUIUtility.IconContent("d_scenevis_scene_hover@2x");

		private static GUIContent _dscenevisvisiblemixed;
		/// <summary>
		/// d_scenevis_visible-mixed
		/// </summary>
		public static GUIContent DScenevisVisibleMixed => _dscenevisvisiblemixed ??= EditorGUIUtility.IconContent("d_scenevis_visible-mixed");

		private static GUIContent _dscenevisvisiblemixed2X;
		/// <summary>
		/// d_scenevis_visible-mixed@2x
		/// </summary>
		public static GUIContent DScenevisVisibleMixed2X => _dscenevisvisiblemixed2X ??= EditorGUIUtility.IconContent("d_scenevis_visible-mixed@2x");

		private static GUIContent _dscenevisvisiblemixedhover;
		/// <summary>
		/// d_scenevis_visible-mixed_hover
		/// </summary>
		public static GUIContent DScenevisVisibleMixedHover => _dscenevisvisiblemixedhover ??= EditorGUIUtility.IconContent("d_scenevis_visible-mixed_hover");

		private static GUIContent _dscenevisvisiblemixedhover2X;
		/// <summary>
		/// d_scenevis_visible-mixed_hover@2x
		/// </summary>
		public static GUIContent DScenevisVisibleMixedHover2X => _dscenevisvisiblemixedhover2X ??= EditorGUIUtility.IconContent("d_scenevis_visible-mixed_hover@2x");

		private static GUIContent _dscenevisvisible;
		/// <summary>
		/// d_scenevis_visible
		/// </summary>
		public static GUIContent DScenevisVisible => _dscenevisvisible ??= EditorGUIUtility.IconContent("d_scenevis_visible");

		private static GUIContent _dscenevisvisible2X;
		/// <summary>
		/// d_scenevis_visible@2x
		/// </summary>
		public static GUIContent DScenevisVisible2X => _dscenevisvisible2X ??= EditorGUIUtility.IconContent("d_scenevis_visible@2x");

		private static GUIContent _dscenevisvisiblehover;
		/// <summary>
		/// d_scenevis_visible_hover
		/// </summary>
		public static GUIContent DScenevisVisibleHover => _dscenevisvisiblehover ??= EditorGUIUtility.IconContent("d_scenevis_visible_hover");

		private static GUIContent _dscenevisvisiblehover2X;
		/// <summary>
		/// d_scenevis_visible_hover@2x
		/// </summary>
		public static GUIContent DScenevisVisibleHover2X => _dscenevisvisiblehover2X ??= EditorGUIUtility.IconContent("d_scenevis_visible_hover@2x");

		private static GUIContent _dscrollshadow;
		/// <summary>
		/// d_ScrollShadow
		/// </summary>
		public static GUIContent DScrollshadow => _dscrollshadow ??= EditorGUIUtility.IconContent("d_ScrollShadow");

		private static GUIContent _dsettings;
		/// <summary>
		/// d_Settings
		/// </summary>
		public static GUIContent DSettings => _dsettings ??= EditorGUIUtility.IconContent("d_Settings");

		private static GUIContent _dsettings2X;
		/// <summary>
		/// d_Settings@2x
		/// </summary>
		public static GUIContent DSettings2X => _dsettings2X ??= EditorGUIUtility.IconContent("d_Settings@2x");

		private static GUIContent _dsettingsicon;
		/// <summary>
		/// d_SettingsIcon
		/// </summary>
		public static GUIContent DSettingsicon => _dsettingsicon ??= EditorGUIUtility.IconContent("d_SettingsIcon");

		private static GUIContent _dsettingsicon2X;
		/// <summary>
		/// d_SettingsIcon@2x
		/// </summary>
		public static GUIContent DSettingsicon2X => _dsettingsicon2X ??= EditorGUIUtility.IconContent("d_SettingsIcon@2x");

		private static GUIContent _dsocialnetworksfacebookshare;
		/// <summary>
		/// d_SocialNetworks.FacebookShare
		/// </summary>
		public static GUIContent DSocialnetworksFacebookshare => _dsocialnetworksfacebookshare ??= EditorGUIUtility.IconContent("d_SocialNetworks.FacebookShare");

		private static GUIContent _dsocialnetworkslinkedinshare;
		/// <summary>
		/// d_SocialNetworks.LinkedInShare
		/// </summary>
		public static GUIContent DSocialnetworksLinkedinshare => _dsocialnetworkslinkedinshare ??= EditorGUIUtility.IconContent("d_SocialNetworks.LinkedInShare");

		private static GUIContent _dsocialnetworkstweet;
		/// <summary>
		/// d_SocialNetworks.Tweet
		/// </summary>
		public static GUIContent DSocialnetworksTweet => _dsocialnetworkstweet ??= EditorGUIUtility.IconContent("d_SocialNetworks.Tweet");

		private static GUIContent _dsocialnetworksudnopen;
		/// <summary>
		/// d_SocialNetworks.UDNOpen
		/// </summary>
		public static GUIContent DSocialnetworksUdnopen => _dsocialnetworksudnopen ??= EditorGUIUtility.IconContent("d_SocialNetworks.UDNOpen");

		private static GUIContent _dspeedscale;
		/// <summary>
		/// d_SpeedScale
		/// </summary>
		public static GUIContent DSpeedscale => _dspeedscale ??= EditorGUIUtility.IconContent("d_SpeedScale");

		private static GUIContent _dstepbuttonon;
		/// <summary>
		/// d_StepButton On
		/// </summary>
		public static GUIContent DStepbuttonOn => _dstepbuttonon ??= EditorGUIUtility.IconContent("d_StepButton On");

		private static GUIContent _dstepbuttonon2X;
		/// <summary>
		/// d_StepButton On@2x
		/// </summary>
		public static GUIContent DStepbuttonOn2X => _dstepbuttonon2X ??= EditorGUIUtility.IconContent("d_StepButton On@2x");

		private static GUIContent _dstepbutton;
		/// <summary>
		/// d_StepButton
		/// </summary>
		public static GUIContent DStepbutton => _dstepbutton ??= EditorGUIUtility.IconContent("d_StepButton");

		private static GUIContent _dstepbutton2X;
		/// <summary>
		/// d_StepButton@2x
		/// </summary>
		public static GUIContent DStepbutton2X => _dstepbutton2X ??= EditorGUIUtility.IconContent("d_StepButton@2x");

		private static GUIContent _dstepleftbuttonon;
		/// <summary>
		/// d_StepLeftButton-On
		/// </summary>
		public static GUIContent DStepleftbuttonOn => _dstepleftbuttonon ??= EditorGUIUtility.IconContent("d_StepLeftButton-On");

		private static GUIContent _dstepleftbutton;
		/// <summary>
		/// d_StepLeftButton
		/// </summary>
		public static GUIContent DStepleftbutton => _dstepleftbutton ??= EditorGUIUtility.IconContent("d_StepLeftButton");

		private static GUIContent _dtabnext;
		/// <summary>
		/// d_tab_next
		/// </summary>
		public static GUIContent DTabNext => _dtabnext ??= EditorGUIUtility.IconContent("d_tab_next");

		private static GUIContent _dtabnext2X;
		/// <summary>
		/// d_tab_next@2x
		/// </summary>
		public static GUIContent DTabNext2X => _dtabnext2X ??= EditorGUIUtility.IconContent("d_tab_next@2x");

		private static GUIContent _dtabprev;
		/// <summary>
		/// d_tab_prev
		/// </summary>
		public static GUIContent DTabPrev => _dtabprev ??= EditorGUIUtility.IconContent("d_tab_prev");

		private static GUIContent _dtabprev2X;
		/// <summary>
		/// d_tab_prev@2x
		/// </summary>
		public static GUIContent DTabPrev2X => _dtabprev2X ??= EditorGUIUtility.IconContent("d_tab_prev@2x");

		private static GUIContent _dterraininspectorterraintoolloweron;
		/// <summary>
		/// d_TerrainInspector.TerrainToolLower On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoollowerOn => _dterraininspectorterraintoolloweron ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolLower On");

		private static GUIContent _dterraininspectorterraintoolloweralt;
		/// <summary>
		/// d_TerrainInspector.TerrainToolLowerAlt
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolloweralt => _dterraininspectorterraintoolloweralt ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolLowerAlt");

		private static GUIContent _dterraininspectorterraintoolplantson;
		/// <summary>
		/// d_TerrainInspector.TerrainToolPlants On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolplantsOn => _dterraininspectorterraintoolplantson ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolPlants On");

		private static GUIContent _dterraininspectorterraintoolplants;
		/// <summary>
		/// d_TerrainInspector.TerrainToolPlants
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolplants => _dterraininspectorterraintoolplants ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolPlants");

		private static GUIContent _dterraininspectorterraintoolplantsalton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolPlantsAlt On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolplantsaltOn => _dterraininspectorterraintoolplantsalton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolPlantsAlt On");

		private static GUIContent _dterraininspectorterraintoolplantsalt;
		/// <summary>
		/// d_TerrainInspector.TerrainToolPlantsAlt
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolplantsalt => _dterraininspectorterraintoolplantsalt ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolPlantsAlt");

		private static GUIContent _dterraininspectorterraintoolraiseon;
		/// <summary>
		/// d_TerrainInspector.TerrainToolRaise On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolraiseOn => _dterraininspectorterraintoolraiseon ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolRaise On");

		private static GUIContent _dterraininspectorterraintoolraise;
		/// <summary>
		/// d_TerrainInspector.TerrainToolRaise
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolraise => _dterraininspectorterraintoolraise ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolRaise");

		private static GUIContent _dterraininspectorterraintoolsetheighton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSetheight On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsetheightOn => _dterraininspectorterraintoolsetheighton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSetheight On");

		private static GUIContent _dterraininspectorterraintoolsetheight;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSetheight
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsetheight => _dterraininspectorterraintoolsetheight ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSetheight");

		private static GUIContent _dterraininspectorterraintoolsetheightalton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSetheightAlt On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsetheightaltOn => _dterraininspectorterraintoolsetheightalton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSetheightAlt On");

		private static GUIContent _dterraininspectorterraintoolsetheightalt;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSetheightAlt
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsetheightalt => _dterraininspectorterraintoolsetheightalt ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSetheightAlt");

		private static GUIContent _dterraininspectorterraintoolsettingson;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSettings On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsettingsOn => _dterraininspectorterraintoolsettingson ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSettings On");

		private static GUIContent _dterraininspectorterraintoolsettings;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSettings
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsettings => _dterraininspectorterraintoolsettings ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSettings");

		private static GUIContent _dterraininspectorterraintoolsmoothheighton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSmoothHeight On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsmoothheightOn => _dterraininspectorterraintoolsmoothheighton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSmoothHeight On");

		private static GUIContent _dterraininspectorterraintoolsmoothheight;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSmoothHeight
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsmoothheight => _dterraininspectorterraintoolsmoothheight ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSmoothHeight");

		private static GUIContent _dterraininspectorterraintoolsplaton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSplat On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsplatOn => _dterraininspectorterraintoolsplaton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSplat On");

		private static GUIContent _dterraininspectorterraintoolsplat;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSplat
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsplat => _dterraininspectorterraintoolsplat ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSplat");

		private static GUIContent _dterraininspectorterraintoolsplatalton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSplatAlt On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsplataltOn => _dterraininspectorterraintoolsplatalton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSplatAlt On");

		private static GUIContent _dterraininspectorterraintoolsplatalt;
		/// <summary>
		/// d_TerrainInspector.TerrainToolSplatAlt
		/// </summary>
		public static GUIContent DTerraininspectorTerraintoolsplatalt => _dterraininspectorterraintoolsplatalt ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolSplatAlt");

		private static GUIContent _dterraininspectorterraintooltreeson;
		/// <summary>
		/// d_TerrainInspector.TerrainToolTrees On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintooltreesOn => _dterraininspectorterraintooltreeson ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolTrees On");

		private static GUIContent _dterraininspectorterraintooltrees;
		/// <summary>
		/// d_TerrainInspector.TerrainToolTrees
		/// </summary>
		public static GUIContent DTerraininspectorTerraintooltrees => _dterraininspectorterraintooltrees ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolTrees");

		private static GUIContent _dterraininspectorterraintooltreesalton;
		/// <summary>
		/// d_TerrainInspector.TerrainToolTreesAlt On
		/// </summary>
		public static GUIContent DTerraininspectorTerraintooltreesaltOn => _dterraininspectorterraintooltreesalton ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolTreesAlt On");

		private static GUIContent _dterraininspectorterraintooltreesalt;
		/// <summary>
		/// d_TerrainInspector.TerrainToolTreesAlt
		/// </summary>
		public static GUIContent DTerraininspectorTerraintooltreesalt => _dterraininspectorterraintooltreesalt ??= EditorGUIUtility.IconContent("d_TerrainInspector.TerrainToolTreesAlt");

		private static GUIContent _dtoggleuvoverlay;
		/// <summary>
		/// d_ToggleUVOverlay
		/// </summary>
		public static GUIContent DToggleuvoverlay => _dtoggleuvoverlay ??= EditorGUIUtility.IconContent("d_ToggleUVOverlay");

		private static GUIContent _dtoggleuvoverlay2X;
		/// <summary>
		/// d_ToggleUVOverlay@2x
		/// </summary>
		public static GUIContent DToggleuvoverlay2X => _dtoggleuvoverlay2X ??= EditorGUIUtility.IconContent("d_ToggleUVOverlay@2x");

		private static GUIContent _dtoolbarminus;
		/// <summary>
		/// d_Toolbar Minus
		/// </summary>
		public static GUIContent DToolbarMinus => _dtoolbarminus ??= EditorGUIUtility.IconContent("d_Toolbar Minus");

		private static GUIContent _dtoolbarminus2X;
		/// <summary>
		/// d_Toolbar Minus@2x
		/// </summary>
		public static GUIContent DToolbarMinus2X => _dtoolbarminus2X ??= EditorGUIUtility.IconContent("d_Toolbar Minus@2x");

		private static GUIContent _dtoolbarplusmore;
		/// <summary>
		/// d_Toolbar Plus More
		/// </summary>
		public static GUIContent DToolbarPlusMore => _dtoolbarplusmore ??= EditorGUIUtility.IconContent("d_Toolbar Plus More");

		private static GUIContent _dtoolbarplusmore2X;
		/// <summary>
		/// d_Toolbar Plus More@2x
		/// </summary>
		public static GUIContent DToolbarPlusMore2X => _dtoolbarplusmore2X ??= EditorGUIUtility.IconContent("d_Toolbar Plus More@2x");

		private static GUIContent _dtoolbarplus;
		/// <summary>
		/// d_Toolbar Plus
		/// </summary>
		public static GUIContent DToolbarPlus => _dtoolbarplus ??= EditorGUIUtility.IconContent("d_Toolbar Plus");

		private static GUIContent _dtoolbarplus2X;
		/// <summary>
		/// d_Toolbar Plus@2x
		/// </summary>
		public static GUIContent DToolbarPlus2X => _dtoolbarplus2X ??= EditorGUIUtility.IconContent("d_Toolbar Plus@2x");

		private static GUIContent _dtoolhandlecenter;
		/// <summary>
		/// d_ToolHandleCenter
		/// </summary>
		public static GUIContent DToolhandlecenter => _dtoolhandlecenter ??= EditorGUIUtility.IconContent("d_ToolHandleCenter");

		private static GUIContent _dtoolhandlecenter2X;
		/// <summary>
		/// d_ToolHandleCenter@2x
		/// </summary>
		public static GUIContent DToolhandlecenter2X => _dtoolhandlecenter2X ??= EditorGUIUtility.IconContent("d_ToolHandleCenter@2x");

		private static GUIContent _dtoolhandleglobal;
		/// <summary>
		/// d_ToolHandleGlobal
		/// </summary>
		public static GUIContent DToolhandleglobal => _dtoolhandleglobal ??= EditorGUIUtility.IconContent("d_ToolHandleGlobal");

		private static GUIContent _dtoolhandleglobal2X;
		/// <summary>
		/// d_ToolHandleGlobal@2x
		/// </summary>
		public static GUIContent DToolhandleglobal2X => _dtoolhandleglobal2X ??= EditorGUIUtility.IconContent("d_ToolHandleGlobal@2x");

		private static GUIContent _dtoolhandlelocal;
		/// <summary>
		/// d_ToolHandleLocal
		/// </summary>
		public static GUIContent DToolhandlelocal => _dtoolhandlelocal ??= EditorGUIUtility.IconContent("d_ToolHandleLocal");

		private static GUIContent _dtoolhandlelocal2X;
		/// <summary>
		/// d_ToolHandleLocal@2x
		/// </summary>
		public static GUIContent DToolhandlelocal2X => _dtoolhandlelocal2X ??= EditorGUIUtility.IconContent("d_ToolHandleLocal@2x");

		private static GUIContent _dtoolhandlepivot;
		/// <summary>
		/// d_ToolHandlePivot
		/// </summary>
		public static GUIContent DToolhandlepivot => _dtoolhandlepivot ??= EditorGUIUtility.IconContent("d_ToolHandlePivot");

		private static GUIContent _dtoolhandlepivot2X;
		/// <summary>
		/// d_ToolHandlePivot@2x
		/// </summary>
		public static GUIContent DToolhandlepivot2X => _dtoolhandlepivot2X ??= EditorGUIUtility.IconContent("d_ToolHandlePivot@2x");

		private static GUIContent _dtoolsicon;
		/// <summary>
		/// d_ToolsIcon
		/// </summary>
		public static GUIContent DToolsicon => _dtoolsicon ??= EditorGUIUtility.IconContent("d_ToolsIcon");

		private static GUIContent _dtranp;
		/// <summary>
		/// d_tranp
		/// </summary>
		public static GUIContent DTranp => _dtranp ??= EditorGUIUtility.IconContent("d_tranp");

		private static GUIContent _dtransformtoolon;
		/// <summary>
		/// d_TransformTool On
		/// </summary>
		public static GUIContent DTransformtoolOn => _dtransformtoolon ??= EditorGUIUtility.IconContent("d_TransformTool On");

		private static GUIContent _dtransformtoolon2X;
		/// <summary>
		/// d_TransformTool On@2x
		/// </summary>
		public static GUIContent DTransformtoolOn2X => _dtransformtoolon2X ??= EditorGUIUtility.IconContent("d_TransformTool On@2x");

		private static GUIContent _dtransformtool;
		/// <summary>
		/// d_TransformTool
		/// </summary>
		public static GUIContent DTransformtool => _dtransformtool ??= EditorGUIUtility.IconContent("d_TransformTool");

		private static GUIContent _dtransformtool2X;
		/// <summary>
		/// d_TransformTool@2x
		/// </summary>
		public static GUIContent DTransformtool2X => _dtransformtool2X ??= EditorGUIUtility.IconContent("d_TransformTool@2x");

		private static GUIContent _dtreeicon;
		/// <summary>
		/// d_tree_icon
		/// </summary>
		public static GUIContent DTreeIcon => _dtreeicon ??= EditorGUIUtility.IconContent("d_tree_icon");

		private static GUIContent _dtreeiconbranch;
		/// <summary>
		/// d_tree_icon_branch
		/// </summary>
		public static GUIContent DTreeIconBranch => _dtreeiconbranch ??= EditorGUIUtility.IconContent("d_tree_icon_branch");

		private static GUIContent _dtreeiconbranchfrond;
		/// <summary>
		/// d_tree_icon_branch_frond
		/// </summary>
		public static GUIContent DTreeIconBranchFrond => _dtreeiconbranchfrond ??= EditorGUIUtility.IconContent("d_tree_icon_branch_frond");

		private static GUIContent _dtreeiconfrond;
		/// <summary>
		/// d_tree_icon_frond
		/// </summary>
		public static GUIContent DTreeIconFrond => _dtreeiconfrond ??= EditorGUIUtility.IconContent("d_tree_icon_frond");

		private static GUIContent _dtreeiconleaf;
		/// <summary>
		/// d_tree_icon_leaf
		/// </summary>
		public static GUIContent DTreeIconLeaf => _dtreeiconleaf ??= EditorGUIUtility.IconContent("d_tree_icon_leaf");

		private static GUIContent _dtreeeditoraddbranches;
		/// <summary>
		/// d_TreeEditor.AddBranches
		/// </summary>
		public static GUIContent DTreeeditorAddbranches => _dtreeeditoraddbranches ??= EditorGUIUtility.IconContent("d_TreeEditor.AddBranches");

		private static GUIContent _dtreeeditoraddleaves;
		/// <summary>
		/// d_TreeEditor.AddLeaves
		/// </summary>
		public static GUIContent DTreeeditorAddleaves => _dtreeeditoraddleaves ??= EditorGUIUtility.IconContent("d_TreeEditor.AddLeaves");

		private static GUIContent _dtreeeditorbranchon;
		/// <summary>
		/// d_TreeEditor.Branch On
		/// </summary>
		public static GUIContent DTreeeditorBranchOn => _dtreeeditorbranchon ??= EditorGUIUtility.IconContent("d_TreeEditor.Branch On");

		private static GUIContent _dtreeeditorbranch;
		/// <summary>
		/// d_TreeEditor.Branch
		/// </summary>
		public static GUIContent DTreeeditorBranch => _dtreeeditorbranch ??= EditorGUIUtility.IconContent("d_TreeEditor.Branch");

		private static GUIContent _dtreeeditorbranchfreehandon;
		/// <summary>
		/// d_TreeEditor.BranchFreeHand On
		/// </summary>
		public static GUIContent DTreeeditorBranchfreehandOn => _dtreeeditorbranchfreehandon ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchFreeHand On");

		private static GUIContent _dtreeeditorbranchfreehand;
		/// <summary>
		/// d_TreeEditor.BranchFreeHand
		/// </summary>
		public static GUIContent DTreeeditorBranchfreehand => _dtreeeditorbranchfreehand ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchFreeHand");

		private static GUIContent _dtreeeditorbranchrotateon;
		/// <summary>
		/// d_TreeEditor.BranchRotate On
		/// </summary>
		public static GUIContent DTreeeditorBranchrotateOn => _dtreeeditorbranchrotateon ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchRotate On");

		private static GUIContent _dtreeeditorbranchrotate;
		/// <summary>
		/// d_TreeEditor.BranchRotate
		/// </summary>
		public static GUIContent DTreeeditorBranchrotate => _dtreeeditorbranchrotate ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchRotate");

		private static GUIContent _dtreeeditorbranchscaleon;
		/// <summary>
		/// d_TreeEditor.BranchScale On
		/// </summary>
		public static GUIContent DTreeeditorBranchscaleOn => _dtreeeditorbranchscaleon ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchScale On");

		private static GUIContent _dtreeeditorbranchscale;
		/// <summary>
		/// d_TreeEditor.BranchScale
		/// </summary>
		public static GUIContent DTreeeditorBranchscale => _dtreeeditorbranchscale ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchScale");

		private static GUIContent _dtreeeditorbranchtranslateon;
		/// <summary>
		/// d_TreeEditor.BranchTranslate On
		/// </summary>
		public static GUIContent DTreeeditorBranchtranslateOn => _dtreeeditorbranchtranslateon ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchTranslate On");

		private static GUIContent _dtreeeditorbranchtranslate;
		/// <summary>
		/// d_TreeEditor.BranchTranslate
		/// </summary>
		public static GUIContent DTreeeditorBranchtranslate => _dtreeeditorbranchtranslate ??= EditorGUIUtility.IconContent("d_TreeEditor.BranchTranslate");

		private static GUIContent _dtreeeditordistributionon;
		/// <summary>
		/// d_TreeEditor.Distribution On
		/// </summary>
		public static GUIContent DTreeeditorDistributionOn => _dtreeeditordistributionon ??= EditorGUIUtility.IconContent("d_TreeEditor.Distribution On");

		private static GUIContent _dtreeeditordistribution;
		/// <summary>
		/// d_TreeEditor.Distribution
		/// </summary>
		public static GUIContent DTreeeditorDistribution => _dtreeeditordistribution ??= EditorGUIUtility.IconContent("d_TreeEditor.Distribution");

		private static GUIContent _dtreeeditorduplicate;
		/// <summary>
		/// d_TreeEditor.Duplicate
		/// </summary>
		public static GUIContent DTreeeditorDuplicate => _dtreeeditorduplicate ??= EditorGUIUtility.IconContent("d_TreeEditor.Duplicate");

		private static GUIContent _dtreeeditorgeometryon;
		/// <summary>
		/// d_TreeEditor.Geometry On
		/// </summary>
		public static GUIContent DTreeeditorGeometryOn => _dtreeeditorgeometryon ??= EditorGUIUtility.IconContent("d_TreeEditor.Geometry On");

		private static GUIContent _dtreeeditorgeometry;
		/// <summary>
		/// d_TreeEditor.Geometry
		/// </summary>
		public static GUIContent DTreeeditorGeometry => _dtreeeditorgeometry ??= EditorGUIUtility.IconContent("d_TreeEditor.Geometry");

		private static GUIContent _dtreeeditorleafon;
		/// <summary>
		/// d_TreeEditor.Leaf On
		/// </summary>
		public static GUIContent DTreeeditorLeafOn => _dtreeeditorleafon ??= EditorGUIUtility.IconContent("d_TreeEditor.Leaf On");

		private static GUIContent _dtreeeditorleaf;
		/// <summary>
		/// d_TreeEditor.Leaf
		/// </summary>
		public static GUIContent DTreeeditorLeaf => _dtreeeditorleaf ??= EditorGUIUtility.IconContent("d_TreeEditor.Leaf");

		private static GUIContent _dtreeeditorleaffreehandon;
		/// <summary>
		/// d_TreeEditor.LeafFreeHand On
		/// </summary>
		public static GUIContent DTreeeditorLeaffreehandOn => _dtreeeditorleaffreehandon ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafFreeHand On");

		private static GUIContent _dtreeeditorleaffreehand;
		/// <summary>
		/// d_TreeEditor.LeafFreeHand
		/// </summary>
		public static GUIContent DTreeeditorLeaffreehand => _dtreeeditorleaffreehand ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafFreeHand");

		private static GUIContent _dtreeeditorleafrotateon;
		/// <summary>
		/// d_TreeEditor.LeafRotate On
		/// </summary>
		public static GUIContent DTreeeditorLeafrotateOn => _dtreeeditorleafrotateon ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafRotate On");

		private static GUIContent _dtreeeditorleafrotate;
		/// <summary>
		/// d_TreeEditor.LeafRotate
		/// </summary>
		public static GUIContent DTreeeditorLeafrotate => _dtreeeditorleafrotate ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafRotate");

		private static GUIContent _dtreeeditorleafscaleon;
		/// <summary>
		/// d_TreeEditor.LeafScale On
		/// </summary>
		public static GUIContent DTreeeditorLeafscaleOn => _dtreeeditorleafscaleon ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafScale On");

		private static GUIContent _dtreeeditorleafscale;
		/// <summary>
		/// d_TreeEditor.LeafScale
		/// </summary>
		public static GUIContent DTreeeditorLeafscale => _dtreeeditorleafscale ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafScale");

		private static GUIContent _dtreeeditorleaftranslateon;
		/// <summary>
		/// d_TreeEditor.LeafTranslate On
		/// </summary>
		public static GUIContent DTreeeditorLeaftranslateOn => _dtreeeditorleaftranslateon ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafTranslate On");

		private static GUIContent _dtreeeditorleaftranslate;
		/// <summary>
		/// d_TreeEditor.LeafTranslate
		/// </summary>
		public static GUIContent DTreeeditorLeaftranslate => _dtreeeditorleaftranslate ??= EditorGUIUtility.IconContent("d_TreeEditor.LeafTranslate");

		private static GUIContent _dtreeeditormaterialon;
		/// <summary>
		/// d_TreeEditor.Material On
		/// </summary>
		public static GUIContent DTreeeditorMaterialOn => _dtreeeditormaterialon ??= EditorGUIUtility.IconContent("d_TreeEditor.Material On");

		private static GUIContent _dtreeeditormaterial;
		/// <summary>
		/// d_TreeEditor.Material
		/// </summary>
		public static GUIContent DTreeeditorMaterial => _dtreeeditormaterial ??= EditorGUIUtility.IconContent("d_TreeEditor.Material");

		private static GUIContent _dtreeeditorrefresh;
		/// <summary>
		/// d_TreeEditor.Refresh
		/// </summary>
		public static GUIContent DTreeeditorRefresh => _dtreeeditorrefresh ??= EditorGUIUtility.IconContent("d_TreeEditor.Refresh");

		private static GUIContent _dtreeeditortrash;
		/// <summary>
		/// d_TreeEditor.Trash
		/// </summary>
		public static GUIContent DTreeeditorTrash => _dtreeeditortrash ??= EditorGUIUtility.IconContent("d_TreeEditor.Trash");

		private static GUIContent _dtreeeditorwindon;
		/// <summary>
		/// d_TreeEditor.Wind On
		/// </summary>
		public static GUIContent DTreeeditorWindOn => _dtreeeditorwindon ??= EditorGUIUtility.IconContent("d_TreeEditor.Wind On");

		private static GUIContent _dtreeeditorwind;
		/// <summary>
		/// d_TreeEditor.Wind
		/// </summary>
		public static GUIContent DTreeeditorWind => _dtreeeditorwind ??= EditorGUIUtility.IconContent("d_TreeEditor.Wind");

		private static GUIContent _dunityeditoranimationwindow;
		/// <summary>
		/// d_UnityEditor.AnimationWindow
		/// </summary>
		public static GUIContent DUnityeditorAnimationwindow => _dunityeditoranimationwindow ??= EditorGUIUtility.IconContent("d_UnityEditor.AnimationWindow");

		private static GUIContent _dunityeditoranimationwindow2X;
		/// <summary>
		/// d_UnityEditor.AnimationWindow@2x
		/// </summary>
		public static GUIContent DUnityeditorAnimationwindow2X => _dunityeditoranimationwindow2X ??= EditorGUIUtility.IconContent("d_UnityEditor.AnimationWindow@2x");

		private static GUIContent _dunityeditorconsolewindow;
		/// <summary>
		/// d_UnityEditor.ConsoleWindow
		/// </summary>
		public static GUIContent DUnityeditorConsolewindow => _dunityeditorconsolewindow ??= EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow");

		private static GUIContent _dunityeditorconsolewindow2X;
		/// <summary>
		/// d_UnityEditor.ConsoleWindow@2x
		/// </summary>
		public static GUIContent DUnityeditorConsolewindow2X => _dunityeditorconsolewindow2X ??= EditorGUIUtility.IconContent("d_UnityEditor.ConsoleWindow@2x");

		private static GUIContent _dunityeditordebuginspectorwindow;
		/// <summary>
		/// d_UnityEditor.DebugInspectorWindow
		/// </summary>
		public static GUIContent DUnityeditorDebuginspectorwindow => _dunityeditordebuginspectorwindow ??= EditorGUIUtility.IconContent("d_UnityEditor.DebugInspectorWindow");

		private static GUIContent _dunityeditorfinddependencies;
		/// <summary>
		/// d_UnityEditor.FindDependencies
		/// </summary>
		public static GUIContent DUnityeditorFinddependencies => _dunityeditorfinddependencies ??= EditorGUIUtility.IconContent("d_UnityEditor.FindDependencies");

		private static GUIContent _dunityeditorgameview;
		/// <summary>
		/// d_UnityEditor.GameView
		/// </summary>
		public static GUIContent DUnityeditorGameview => _dunityeditorgameview ??= EditorGUIUtility.IconContent("d_UnityEditor.GameView");

		private static GUIContent _dunityeditorgameview2X;
		/// <summary>
		/// d_UnityEditor.GameView@2x
		/// </summary>
		public static GUIContent DUnityeditorGameview2X => _dunityeditorgameview2X ??= EditorGUIUtility.IconContent("d_UnityEditor.GameView@2x");

		private static GUIContent _dunityeditorgraphsanimatorcontrollertool;
		/// <summary>
		/// d_UnityEditor.Graphs.AnimatorControllerTool
		/// </summary>
		public static GUIContent DUnityeditorGraphsAnimatorcontrollertool => _dunityeditorgraphsanimatorcontrollertool ??= EditorGUIUtility.IconContent("d_UnityEditor.Graphs.AnimatorControllerTool");

		private static GUIContent _dunityeditorgraphsanimatorcontrollertool2X;
		/// <summary>
		/// d_UnityEditor.Graphs.AnimatorControllerTool@2x
		/// </summary>
		public static GUIContent DUnityeditorGraphsAnimatorcontrollertool2X => _dunityeditorgraphsanimatorcontrollertool2X ??= EditorGUIUtility.IconContent("d_UnityEditor.Graphs.AnimatorControllerTool@2x");

		private static GUIContent _dunityeditorhierarchywindow;
		/// <summary>
		/// d_UnityEditor.HierarchyWindow
		/// </summary>
		public static GUIContent DUnityeditorHierarchywindow => _dunityeditorhierarchywindow ??= EditorGUIUtility.IconContent("d_UnityEditor.HierarchyWindow");

		private static GUIContent _dunityeditorinspectorwindow;
		/// <summary>
		/// d_UnityEditor.InspectorWindow
		/// </summary>
		public static GUIContent DUnityeditorInspectorwindow => _dunityeditorinspectorwindow ??= EditorGUIUtility.IconContent("d_UnityEditor.InspectorWindow");

		private static GUIContent _dunityeditorinspectorwindow2X;
		/// <summary>
		/// d_UnityEditor.InspectorWindow@2x
		/// </summary>
		public static GUIContent DUnityeditorInspectorwindow2X => _dunityeditorinspectorwindow2X ??= EditorGUIUtility.IconContent("d_UnityEditor.InspectorWindow@2x");

		private static GUIContent _dunityeditorprofilerwindow;
		/// <summary>
		/// d_UnityEditor.ProfilerWindow
		/// </summary>
		public static GUIContent DUnityeditorProfilerwindow => _dunityeditorprofilerwindow ??= EditorGUIUtility.IconContent("d_UnityEditor.ProfilerWindow");

		private static GUIContent _dunityeditorprofilerwindow2X;
		/// <summary>
		/// d_UnityEditor.ProfilerWindow@2x
		/// </summary>
		public static GUIContent DUnityeditorProfilerwindow2X => _dunityeditorprofilerwindow2X ??= EditorGUIUtility.IconContent("d_UnityEditor.ProfilerWindow@2x");

		private static GUIContent _dunityeditorscenehierarchywindow;
		/// <summary>
		/// d_UnityEditor.SceneHierarchyWindow
		/// </summary>
		public static GUIContent DUnityeditorScenehierarchywindow => _dunityeditorscenehierarchywindow ??= EditorGUIUtility.IconContent("d_UnityEditor.SceneHierarchyWindow");

		private static GUIContent _dunityeditorscenehierarchywindow2X;
		/// <summary>
		/// d_UnityEditor.SceneHierarchyWindow@2x
		/// </summary>
		public static GUIContent DUnityeditorScenehierarchywindow2X => _dunityeditorscenehierarchywindow2X ??= EditorGUIUtility.IconContent("d_UnityEditor.SceneHierarchyWindow@2x");

		private static GUIContent _dunityeditorsceneview;
		/// <summary>
		/// d_UnityEditor.SceneView
		/// </summary>
		public static GUIContent DUnityeditorSceneview => _dunityeditorsceneview ??= EditorGUIUtility.IconContent("d_UnityEditor.SceneView");

		private static GUIContent _dunityeditorsceneview2X;
		/// <summary>
		/// d_UnityEditor.SceneView@2x
		/// </summary>
		public static GUIContent DUnityeditorSceneview2X => _dunityeditorsceneview2X ??= EditorGUIUtility.IconContent("d_UnityEditor.SceneView@2x");

		private static GUIContent _dunityeditortimelinetimelinewindow;
		/// <summary>
		/// d_UnityEditor.Timeline.TimelineWindow
		/// </summary>
		public static GUIContent DUnityeditorTimelineTimelinewindow => _dunityeditortimelinetimelinewindow ??= EditorGUIUtility.IconContent("d_UnityEditor.Timeline.TimelineWindow");

		private static GUIContent _dunityeditortimelinetimelinewindow2X;
		/// <summary>
		/// d_UnityEditor.Timeline.TimelineWindow@2x
		/// </summary>
		public static GUIContent DUnityeditorTimelineTimelinewindow2X => _dunityeditortimelinetimelinewindow2X ??= EditorGUIUtility.IconContent("d_UnityEditor.Timeline.TimelineWindow@2x");

		private static GUIContent _dunityeditorversioncontrol;
		/// <summary>
		/// d_UnityEditor.VersionControl
		/// </summary>
		public static GUIContent DUnityeditorVersioncontrol => _dunityeditorversioncontrol ??= EditorGUIUtility.IconContent("d_UnityEditor.VersionControl");

		private static GUIContent _dunitylogo;
		/// <summary>
		/// d_UnityLogo
		/// </summary>
		public static GUIContent DUnitylogo => _dunitylogo ??= EditorGUIUtility.IconContent("d_UnityLogo");

		private static GUIContent _dunlinked;
		/// <summary>
		/// d_Unlinked
		/// </summary>
		public static GUIContent DUnlinked => _dunlinked ??= EditorGUIUtility.IconContent("d_Unlinked");

		private static GUIContent _dunlinked2X;
		/// <summary>
		/// d_Unlinked@2x
		/// </summary>
		public static GUIContent DUnlinked2X => _dunlinked2X ??= EditorGUIUtility.IconContent("d_Unlinked@2x");

		private static GUIContent _dvalid;
		/// <summary>
		/// d_Valid
		/// </summary>
		public static GUIContent DValid => _dvalid ??= EditorGUIUtility.IconContent("d_Valid");

		private static GUIContent _dvalid2X;
		/// <summary>
		/// d_Valid@2x
		/// </summary>
		public static GUIContent DValid2X => _dvalid2X ??= EditorGUIUtility.IconContent("d_Valid@2x");

		private static GUIContent _dverticalsplit;
		/// <summary>
		/// d_VerticalSplit
		/// </summary>
		public static GUIContent DVerticalsplit => _dverticalsplit ??= EditorGUIUtility.IconContent("d_VerticalSplit");

		private static GUIContent _dviewtoolmoveon;
		/// <summary>
		/// d_ViewToolMove On
		/// </summary>
		public static GUIContent DViewtoolmoveOn => _dviewtoolmoveon ??= EditorGUIUtility.IconContent("d_ViewToolMove On");

		private static GUIContent _dviewtoolmoveon2X;
		/// <summary>
		/// d_ViewToolMove On@2x
		/// </summary>
		public static GUIContent DViewtoolmoveOn2X => _dviewtoolmoveon2X ??= EditorGUIUtility.IconContent("d_ViewToolMove On@2x");

		private static GUIContent _dviewtoolmove;
		/// <summary>
		/// d_ViewToolMove
		/// </summary>
		public static GUIContent DViewtoolmove => _dviewtoolmove ??= EditorGUIUtility.IconContent("d_ViewToolMove");

		private static GUIContent _dviewtoolmove2X;
		/// <summary>
		/// d_ViewToolMove@2x
		/// </summary>
		public static GUIContent DViewtoolmove2X => _dviewtoolmove2X ??= EditorGUIUtility.IconContent("d_ViewToolMove@2x");

		private static GUIContent _dviewtoolorbiton;
		/// <summary>
		/// d_ViewToolOrbit On
		/// </summary>
		public static GUIContent DViewtoolorbitOn => _dviewtoolorbiton ??= EditorGUIUtility.IconContent("d_ViewToolOrbit On");

		private static GUIContent _dviewtoolorbiton2X;
		/// <summary>
		/// d_ViewToolOrbit On@2x
		/// </summary>
		public static GUIContent DViewtoolorbitOn2X => _dviewtoolorbiton2X ??= EditorGUIUtility.IconContent("d_ViewToolOrbit On@2x");

		private static GUIContent _dviewtoolorbit;
		/// <summary>
		/// d_ViewToolOrbit
		/// </summary>
		public static GUIContent DViewtoolorbit => _dviewtoolorbit ??= EditorGUIUtility.IconContent("d_ViewToolOrbit");

		private static GUIContent _dviewtoolorbit2X;
		/// <summary>
		/// d_ViewToolOrbit@2x
		/// </summary>
		public static GUIContent DViewtoolorbit2X => _dviewtoolorbit2X ??= EditorGUIUtility.IconContent("d_ViewToolOrbit@2x");

		private static GUIContent _dviewtoolzoomon;
		/// <summary>
		/// d_ViewToolZoom On
		/// </summary>
		public static GUIContent DViewtoolzoomOn => _dviewtoolzoomon ??= EditorGUIUtility.IconContent("d_ViewToolZoom On");

		private static GUIContent _dviewtoolzoomon2X;
		/// <summary>
		/// d_ViewToolZoom On@2x
		/// </summary>
		public static GUIContent DViewtoolzoomOn2X => _dviewtoolzoomon2X ??= EditorGUIUtility.IconContent("d_ViewToolZoom On@2x");

		private static GUIContent _dviewtoolzoom;
		/// <summary>
		/// d_ViewToolZoom
		/// </summary>
		public static GUIContent DViewtoolzoom => _dviewtoolzoom ??= EditorGUIUtility.IconContent("d_ViewToolZoom");

		private static GUIContent _dviewtoolzoom2X;
		/// <summary>
		/// d_ViewToolZoom@2x
		/// </summary>
		public static GUIContent DViewtoolzoom2X => _dviewtoolzoom2X ??= EditorGUIUtility.IconContent("d_ViewToolZoom@2x");

		private static GUIContent _dvisibilityoff;
		/// <summary>
		/// d_VisibilityOff
		/// </summary>
		public static GUIContent DVisibilityoff => _dvisibilityoff ??= EditorGUIUtility.IconContent("d_VisibilityOff");

		private static GUIContent _dvisibilityon;
		/// <summary>
		/// d_VisibilityOn
		/// </summary>
		public static GUIContent DVisibilityon => _dvisibilityon ??= EditorGUIUtility.IconContent("d_VisibilityOn");

		private static GUIContent _dvumetertexturehorizontal;
		/// <summary>
		/// d_VUMeterTextureHorizontal
		/// </summary>
		public static GUIContent DVumetertexturehorizontal => _dvumetertexturehorizontal ??= EditorGUIUtility.IconContent("d_VUMeterTextureHorizontal");

		private static GUIContent _dvumetertexturevertical;
		/// <summary>
		/// d_VUMeterTextureVertical
		/// </summary>
		public static GUIContent DVumetertexturevertical => _dvumetertexturevertical ??= EditorGUIUtility.IconContent("d_VUMeterTextureVertical");

		private static GUIContent _dwaitspin00;
		/// <summary>
		/// d_WaitSpin00
		/// </summary>
		public static GUIContent DWaitspin00 => _dwaitspin00 ??= EditorGUIUtility.IconContent("d_WaitSpin00");

		private static GUIContent _dwaitspin01;
		/// <summary>
		/// d_WaitSpin01
		/// </summary>
		public static GUIContent DWaitspin01 => _dwaitspin01 ??= EditorGUIUtility.IconContent("d_WaitSpin01");

		private static GUIContent _dwaitspin02;
		/// <summary>
		/// d_WaitSpin02
		/// </summary>
		public static GUIContent DWaitspin02 => _dwaitspin02 ??= EditorGUIUtility.IconContent("d_WaitSpin02");

		private static GUIContent _dwaitspin03;
		/// <summary>
		/// d_WaitSpin03
		/// </summary>
		public static GUIContent DWaitspin03 => _dwaitspin03 ??= EditorGUIUtility.IconContent("d_WaitSpin03");

		private static GUIContent _dwaitspin04;
		/// <summary>
		/// d_WaitSpin04
		/// </summary>
		public static GUIContent DWaitspin04 => _dwaitspin04 ??= EditorGUIUtility.IconContent("d_WaitSpin04");

		private static GUIContent _dwaitspin05;
		/// <summary>
		/// d_WaitSpin05
		/// </summary>
		public static GUIContent DWaitspin05 => _dwaitspin05 ??= EditorGUIUtility.IconContent("d_WaitSpin05");

		private static GUIContent _dwaitspin06;
		/// <summary>
		/// d_WaitSpin06
		/// </summary>
		public static GUIContent DWaitspin06 => _dwaitspin06 ??= EditorGUIUtility.IconContent("d_WaitSpin06");

		private static GUIContent _dwaitspin07;
		/// <summary>
		/// d_WaitSpin07
		/// </summary>
		public static GUIContent DWaitspin07 => _dwaitspin07 ??= EditorGUIUtility.IconContent("d_WaitSpin07");

		private static GUIContent _dwaitspin08;
		/// <summary>
		/// d_WaitSpin08
		/// </summary>
		public static GUIContent DWaitspin08 => _dwaitspin08 ??= EditorGUIUtility.IconContent("d_WaitSpin08");

		private static GUIContent _dwaitspin09;
		/// <summary>
		/// d_WaitSpin09
		/// </summary>
		public static GUIContent DWaitspin09 => _dwaitspin09 ??= EditorGUIUtility.IconContent("d_WaitSpin09");

		private static GUIContent _dwaitspin10;
		/// <summary>
		/// d_WaitSpin10
		/// </summary>
		public static GUIContent DWaitspin10 => _dwaitspin10 ??= EditorGUIUtility.IconContent("d_WaitSpin10");

		private static GUIContent _dwaitspin11;
		/// <summary>
		/// d_WaitSpin11
		/// </summary>
		public static GUIContent DWaitspin11 => _dwaitspin11 ??= EditorGUIUtility.IconContent("d_WaitSpin11");

		private static GUIContent _dwelcomescreenassetstorelogo;
		/// <summary>
		/// d_WelcomeScreen.AssetStoreLogo
		/// </summary>
		public static GUIContent DWelcomescreenAssetstorelogo => _dwelcomescreenassetstorelogo ??= EditorGUIUtility.IconContent("d_WelcomeScreen.AssetStoreLogo");

		private static GUIContent _dwinbtngraph;
		/// <summary>
		/// d_winbtn_graph
		/// </summary>
		public static GUIContent DWinbtnGraph => _dwinbtngraph ??= EditorGUIUtility.IconContent("d_winbtn_graph");

		private static GUIContent _dwinbtngraphcloseh;
		/// <summary>
		/// d_winbtn_graph_close_h
		/// </summary>
		public static GUIContent DWinbtnGraphCloseH => _dwinbtngraphcloseh ??= EditorGUIUtility.IconContent("d_winbtn_graph_close_h");

		private static GUIContent _dwinbtngraphmaxh;
		/// <summary>
		/// d_winbtn_graph_max_h
		/// </summary>
		public static GUIContent DWinbtnGraphMaxH => _dwinbtngraphmaxh ??= EditorGUIUtility.IconContent("d_winbtn_graph_max_h");

		private static GUIContent _dwinbtngraphminh;
		/// <summary>
		/// d_winbtn_graph_min_h
		/// </summary>
		public static GUIContent DWinbtnGraphMinH => _dwinbtngraphminh ??= EditorGUIUtility.IconContent("d_winbtn_graph_min_h");

		private static GUIContent _dwinbtnmacclose;
		/// <summary>
		/// d_winbtn_mac_close
		/// </summary>
		public static GUIContent DWinbtnMacClose => _dwinbtnmacclose ??= EditorGUIUtility.IconContent("d_winbtn_mac_close");

		private static GUIContent _dwinbtnmacclose2X;
		/// <summary>
		/// d_winbtn_mac_close@2x
		/// </summary>
		public static GUIContent DWinbtnMacClose2X => _dwinbtnmacclose2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_close@2x");

		private static GUIContent _dwinbtnmacclosea;
		/// <summary>
		/// d_winbtn_mac_close_a
		/// </summary>
		public static GUIContent DWinbtnMacCloseA => _dwinbtnmacclosea ??= EditorGUIUtility.IconContent("d_winbtn_mac_close_a");

		private static GUIContent _dwinbtnmacclosea2X;
		/// <summary>
		/// d_winbtn_mac_close_a@2x
		/// </summary>
		public static GUIContent DWinbtnMacCloseA2X => _dwinbtnmacclosea2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_close_a@2x");

		private static GUIContent _dwinbtnmaccloseh;
		/// <summary>
		/// d_winbtn_mac_close_h
		/// </summary>
		public static GUIContent DWinbtnMacCloseH => _dwinbtnmaccloseh ??= EditorGUIUtility.IconContent("d_winbtn_mac_close_h");

		private static GUIContent _dwinbtnmaccloseh2X;
		/// <summary>
		/// d_winbtn_mac_close_h@2x
		/// </summary>
		public static GUIContent DWinbtnMacCloseH2X => _dwinbtnmaccloseh2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_close_h@2x");

		private static GUIContent _dwinbtnmacinact;
		/// <summary>
		/// d_winbtn_mac_inact
		/// </summary>
		public static GUIContent DWinbtnMacInact => _dwinbtnmacinact ??= EditorGUIUtility.IconContent("d_winbtn_mac_inact");

		private static GUIContent _dwinbtnmacmax;
		/// <summary>
		/// d_winbtn_mac_max
		/// </summary>
		public static GUIContent DWinbtnMacMax => _dwinbtnmacmax ??= EditorGUIUtility.IconContent("d_winbtn_mac_max");

		private static GUIContent _dwinbtnmacmax2X;
		/// <summary>
		/// d_winbtn_mac_max@2x
		/// </summary>
		public static GUIContent DWinbtnMacMax2X => _dwinbtnmacmax2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_max@2x");

		private static GUIContent _dwinbtnmacmaxa;
		/// <summary>
		/// d_winbtn_mac_max_a
		/// </summary>
		public static GUIContent DWinbtnMacMaxA => _dwinbtnmacmaxa ??= EditorGUIUtility.IconContent("d_winbtn_mac_max_a");

		private static GUIContent _dwinbtnmacmaxa2X;
		/// <summary>
		/// d_winbtn_mac_max_a@2x
		/// </summary>
		public static GUIContent DWinbtnMacMaxA2X => _dwinbtnmacmaxa2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_max_a@2x");

		private static GUIContent _dwinbtnmacmaxh;
		/// <summary>
		/// d_winbtn_mac_max_h
		/// </summary>
		public static GUIContent DWinbtnMacMaxH => _dwinbtnmacmaxh ??= EditorGUIUtility.IconContent("d_winbtn_mac_max_h");

		private static GUIContent _dwinbtnmacmaxh2X;
		/// <summary>
		/// d_winbtn_mac_max_h@2x
		/// </summary>
		public static GUIContent DWinbtnMacMaxH2X => _dwinbtnmacmaxh2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_max_h@2x");

		private static GUIContent _dwinbtnmacmin;
		/// <summary>
		/// d_winbtn_mac_min
		/// </summary>
		public static GUIContent DWinbtnMacMin => _dwinbtnmacmin ??= EditorGUIUtility.IconContent("d_winbtn_mac_min");

		private static GUIContent _dwinbtnmacmin2X;
		/// <summary>
		/// d_winbtn_mac_min@2x
		/// </summary>
		public static GUIContent DWinbtnMacMin2X => _dwinbtnmacmin2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_min@2x");

		private static GUIContent _dwinbtnmacmina;
		/// <summary>
		/// d_winbtn_mac_min_a
		/// </summary>
		public static GUIContent DWinbtnMacMinA => _dwinbtnmacmina ??= EditorGUIUtility.IconContent("d_winbtn_mac_min_a");

		private static GUIContent _dwinbtnmacmina2X;
		/// <summary>
		/// d_winbtn_mac_min_a@2x
		/// </summary>
		public static GUIContent DWinbtnMacMinA2X => _dwinbtnmacmina2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_min_a@2x");

		private static GUIContent _dwinbtnmacminh;
		/// <summary>
		/// d_winbtn_mac_min_h
		/// </summary>
		public static GUIContent DWinbtnMacMinH => _dwinbtnmacminh ??= EditorGUIUtility.IconContent("d_winbtn_mac_min_h");

		private static GUIContent _dwinbtnmacminh2X;
		/// <summary>
		/// d_winbtn_mac_min_h@2x
		/// </summary>
		public static GUIContent DWinbtnMacMinH2X => _dwinbtnmacminh2X ??= EditorGUIUtility.IconContent("d_winbtn_mac_min_h@2x");

		private static GUIContent _dwinbtnwinclose;
		/// <summary>
		/// d_winbtn_win_close
		/// </summary>
		public static GUIContent DWinbtnWinClose => _dwinbtnwinclose ??= EditorGUIUtility.IconContent("d_winbtn_win_close");

		private static GUIContent _dwinbtnwinclose2X;
		/// <summary>
		/// d_winbtn_win_close@2x
		/// </summary>
		public static GUIContent DWinbtnWinClose2X => _dwinbtnwinclose2X ??= EditorGUIUtility.IconContent("d_winbtn_win_close@2x");

		private static GUIContent _dwinbtnwinclosea;
		/// <summary>
		/// d_winbtn_win_close_a
		/// </summary>
		public static GUIContent DWinbtnWinCloseA => _dwinbtnwinclosea ??= EditorGUIUtility.IconContent("d_winbtn_win_close_a");

		private static GUIContent _dwinbtnwinclosea2X;
		/// <summary>
		/// d_winbtn_win_close_a@2x
		/// </summary>
		public static GUIContent DWinbtnWinCloseA2X => _dwinbtnwinclosea2X ??= EditorGUIUtility.IconContent("d_winbtn_win_close_a@2x");

		private static GUIContent _dwinbtnwincloseh;
		/// <summary>
		/// d_winbtn_win_close_h
		/// </summary>
		public static GUIContent DWinbtnWinCloseH => _dwinbtnwincloseh ??= EditorGUIUtility.IconContent("d_winbtn_win_close_h");

		private static GUIContent _dwinbtnwincloseh2X;
		/// <summary>
		/// d_winbtn_win_close_h@2x
		/// </summary>
		public static GUIContent DWinbtnWinCloseH2X => _dwinbtnwincloseh2X ??= EditorGUIUtility.IconContent("d_winbtn_win_close_h@2x");

		private static GUIContent _dwinbtnwinmax;
		/// <summary>
		/// d_winbtn_win_max
		/// </summary>
		public static GUIContent DWinbtnWinMax => _dwinbtnwinmax ??= EditorGUIUtility.IconContent("d_winbtn_win_max");

		private static GUIContent _dwinbtnwinmax2X;
		/// <summary>
		/// d_winbtn_win_max@2x
		/// </summary>
		public static GUIContent DWinbtnWinMax2X => _dwinbtnwinmax2X ??= EditorGUIUtility.IconContent("d_winbtn_win_max@2x");

		private static GUIContent _dwinbtnwinmaxa;
		/// <summary>
		/// d_winbtn_win_max_a
		/// </summary>
		public static GUIContent DWinbtnWinMaxA => _dwinbtnwinmaxa ??= EditorGUIUtility.IconContent("d_winbtn_win_max_a");

		private static GUIContent _dwinbtnwinmaxa2X;
		/// <summary>
		/// d_winbtn_win_max_a@2x
		/// </summary>
		public static GUIContent DWinbtnWinMaxA2X => _dwinbtnwinmaxa2X ??= EditorGUIUtility.IconContent("d_winbtn_win_max_a@2x");

		private static GUIContent _dwinbtnwinmaxh;
		/// <summary>
		/// d_winbtn_win_max_h
		/// </summary>
		public static GUIContent DWinbtnWinMaxH => _dwinbtnwinmaxh ??= EditorGUIUtility.IconContent("d_winbtn_win_max_h");

		private static GUIContent _dwinbtnwinmaxh2X;
		/// <summary>
		/// d_winbtn_win_max_h@2x
		/// </summary>
		public static GUIContent DWinbtnWinMaxH2X => _dwinbtnwinmaxh2X ??= EditorGUIUtility.IconContent("d_winbtn_win_max_h@2x");

		private static GUIContent _dwinbtnwinmin;
		/// <summary>
		/// d_winbtn_win_min
		/// </summary>
		public static GUIContent DWinbtnWinMin => _dwinbtnwinmin ??= EditorGUIUtility.IconContent("d_winbtn_win_min");

		private static GUIContent _dwinbtnwinmina;
		/// <summary>
		/// d_winbtn_win_min_a
		/// </summary>
		public static GUIContent DWinbtnWinMinA => _dwinbtnwinmina ??= EditorGUIUtility.IconContent("d_winbtn_win_min_a");

		private static GUIContent _dwinbtnwinminh;
		/// <summary>
		/// d_winbtn_win_min_h
		/// </summary>
		public static GUIContent DWinbtnWinMinH => _dwinbtnwinminh ??= EditorGUIUtility.IconContent("d_winbtn_win_min_h");

		private static GUIContent _dwinbtnwinrest;
		/// <summary>
		/// d_winbtn_win_rest
		/// </summary>
		public static GUIContent DWinbtnWinRest => _dwinbtnwinrest ??= EditorGUIUtility.IconContent("d_winbtn_win_rest");

		private static GUIContent _dwinbtnwinresta;
		/// <summary>
		/// d_winbtn_win_rest_a
		/// </summary>
		public static GUIContent DWinbtnWinRestA => _dwinbtnwinresta ??= EditorGUIUtility.IconContent("d_winbtn_win_rest_a");

		private static GUIContent _dwinbtnwinresth;
		/// <summary>
		/// d_winbtn_win_rest_h
		/// </summary>
		public static GUIContent DWinbtnWinRestH => _dwinbtnwinresth ??= EditorGUIUtility.IconContent("d_winbtn_win_rest_h");

		private static GUIContent _dwinbtnwinrestore;
		/// <summary>
		/// d_winbtn_win_restore
		/// </summary>
		public static GUIContent DWinbtnWinRestore => _dwinbtnwinrestore ??= EditorGUIUtility.IconContent("d_winbtn_win_restore");

		private static GUIContent _dwinbtnwinrestore2X;
		/// <summary>
		/// d_winbtn_win_restore@2x
		/// </summary>
		public static GUIContent DWinbtnWinRestore2X => _dwinbtnwinrestore2X ??= EditorGUIUtility.IconContent("d_winbtn_win_restore@2x");

		private static GUIContent _dwinbtnwinrestorea;
		/// <summary>
		/// d_winbtn_win_restore_a
		/// </summary>
		public static GUIContent DWinbtnWinRestoreA => _dwinbtnwinrestorea ??= EditorGUIUtility.IconContent("d_winbtn_win_restore_a");

		private static GUIContent _dwinbtnwinrestorea2X;
		/// <summary>
		/// d_winbtn_win_restore_a@2x
		/// </summary>
		public static GUIContent DWinbtnWinRestoreA2X => _dwinbtnwinrestorea2X ??= EditorGUIUtility.IconContent("d_winbtn_win_restore_a@2x");

		private static GUIContent _dwinbtnwinrestoreh;
		/// <summary>
		/// d_winbtn_win_restore_h
		/// </summary>
		public static GUIContent DWinbtnWinRestoreH => _dwinbtnwinrestoreh ??= EditorGUIUtility.IconContent("d_winbtn_win_restore_h");

		private static GUIContent _dwinbtnwinrestoreh2X;
		/// <summary>
		/// d_winbtn_win_restore_h@2x
		/// </summary>
		public static GUIContent DWinbtnWinRestoreH2X => _dwinbtnwinrestoreh2X ??= EditorGUIUtility.IconContent("d_winbtn_win_restore_h@2x");

		private static GUIContent _debuggerattached;
		/// <summary>
		/// DebuggerAttached
		/// </summary>
		public static GUIContent Debuggerattached => _debuggerattached ??= EditorGUIUtility.IconContent("DebuggerAttached");

		private static GUIContent _debuggerattached2X;
		/// <summary>
		/// DebuggerAttached@2x
		/// </summary>
		public static GUIContent Debuggerattached2X => _debuggerattached2X ??= EditorGUIUtility.IconContent("DebuggerAttached@2x");

		private static GUIContent _debuggerdisabled;
		/// <summary>
		/// DebuggerDisabled
		/// </summary>
		public static GUIContent Debuggerdisabled => _debuggerdisabled ??= EditorGUIUtility.IconContent("DebuggerDisabled");

		private static GUIContent _debuggerdisabled2X;
		/// <summary>
		/// DebuggerDisabled@2x
		/// </summary>
		public static GUIContent Debuggerdisabled2X => _debuggerdisabled2X ??= EditorGUIUtility.IconContent("DebuggerDisabled@2x");

		private static GUIContent _debuggerenabled;
		/// <summary>
		/// DebuggerEnabled
		/// </summary>
		public static GUIContent Debuggerenabled => _debuggerenabled ??= EditorGUIUtility.IconContent("DebuggerEnabled");

		private static GUIContent _debuggerenabled2X;
		/// <summary>
		/// DebuggerEnabled@2x
		/// </summary>
		public static GUIContent Debuggerenabled2X => _debuggerenabled2X ??= EditorGUIUtility.IconContent("DebuggerEnabled@2x");

		private static GUIContent _defaultsorting;
		/// <summary>
		/// DefaultSorting
		/// </summary>
		public static GUIContent Defaultsorting => _defaultsorting ??= EditorGUIUtility.IconContent("DefaultSorting");

		private static GUIContent _defaultsorting2X;
		/// <summary>
		/// DefaultSorting@2x
		/// </summary>
		public static GUIContent Defaultsorting2X => _defaultsorting2X ??= EditorGUIUtility.IconContent("DefaultSorting@2x");

		private static GUIContent _editcollider;
		/// <summary>
		/// EditCollider
		/// </summary>
		public static GUIContent Editcollider => _editcollider ??= EditorGUIUtility.IconContent("EditCollider");

		private static GUIContent _editcollision16;
		/// <summary>
		/// editcollision_16
		/// </summary>
		public static GUIContent Editcollision16 => _editcollision16 ??= EditorGUIUtility.IconContent("editcollision_16");

		private static GUIContent _editcollision162X;
		/// <summary>
		/// editcollision_16@2x
		/// </summary>
		public static GUIContent Editcollision162X => _editcollision162X ??= EditorGUIUtility.IconContent("editcollision_16@2x");

		private static GUIContent _editcollision32;
		/// <summary>
		/// editcollision_32
		/// </summary>
		public static GUIContent Editcollision32 => _editcollision32 ??= EditorGUIUtility.IconContent("editcollision_32");

		private static GUIContent _editconstraints16;
		/// <summary>
		/// editconstraints_16
		/// </summary>
		public static GUIContent Editconstraints16 => _editconstraints16 ??= EditorGUIUtility.IconContent("editconstraints_16");

		private static GUIContent _editconstraints162X;
		/// <summary>
		/// editconstraints_16@2x
		/// </summary>
		public static GUIContent Editconstraints162X => _editconstraints162X ??= EditorGUIUtility.IconContent("editconstraints_16@2x");

		private static GUIContent _editconstraints32;
		/// <summary>
		/// editconstraints_32
		/// </summary>
		public static GUIContent Editconstraints32 => _editconstraints32 ??= EditorGUIUtility.IconContent("editconstraints_32");

		private static GUIContent _editiconsml;
		/// <summary>
		/// editicon.sml
		/// </summary>
		public static GUIContent EditiconSml => _editiconsml ??= EditorGUIUtility.IconContent("editicon.sml");

		private static GUIContent _endbuttonon;
		/// <summary>
		/// endButton-On
		/// </summary>
		public static GUIContent EndbuttonOn => _endbuttonon ??= EditorGUIUtility.IconContent("endButton-On");

		private static GUIContent _endbutton;
		/// <summary>
		/// endButton
		/// </summary>
		public static GUIContent Endbutton => _endbutton ??= EditorGUIUtility.IconContent("endButton");

		private static GUIContent _exposure;
		/// <summary>
		/// Exposure
		/// </summary>
		public static GUIContent Exposure => _exposure ??= EditorGUIUtility.IconContent("Exposure");

		private static GUIContent _exposure2X;
		/// <summary>
		/// Exposure@2x
		/// </summary>
		public static GUIContent Exposure2X => _exposure2X ??= EditorGUIUtility.IconContent("Exposure@2x");

		private static GUIContent _eyedropperlarge;
		/// <summary>
		/// eyeDropper.Large
		/// </summary>
		public static GUIContent EyedropperLarge => _eyedropperlarge ??= EditorGUIUtility.IconContent("eyeDropper.Large");

		private static GUIContent _eyedropperlarge2X;
		/// <summary>
		/// eyeDropper.Large@2x
		/// </summary>
		public static GUIContent EyedropperLarge2X => _eyedropperlarge2X ??= EditorGUIUtility.IconContent("eyeDropper.Large@2x");

		private static GUIContent _eyedroppersml;
		/// <summary>
		/// eyeDropper.sml
		/// </summary>
		public static GUIContent EyedropperSml => _eyedroppersml ??= EditorGUIUtility.IconContent("eyeDropper.sml");

		private static GUIContent _favorite;
		/// <summary>
		/// Favorite
		/// </summary>
		public static GUIContent Favorite => _favorite ??= EditorGUIUtility.IconContent("Favorite");

		private static GUIContent _favorite2X;
		/// <summary>
		/// Favorite@2x
		/// </summary>
		public static GUIContent Favorite2X => _favorite2X ??= EditorGUIUtility.IconContent("Favorite@2x");

		private static GUIContent _filterbylabel;
		/// <summary>
		/// FilterByLabel
		/// </summary>
		public static GUIContent Filterbylabel => _filterbylabel ??= EditorGUIUtility.IconContent("FilterByLabel");

		private static GUIContent _filterbylabel2X;
		/// <summary>
		/// FilterByLabel@2x
		/// </summary>
		public static GUIContent Filterbylabel2X => _filterbylabel2X ??= EditorGUIUtility.IconContent("FilterByLabel@2x");

		private static GUIContent _filterbytype;
		/// <summary>
		/// FilterByType
		/// </summary>
		public static GUIContent Filterbytype => _filterbytype ??= EditorGUIUtility.IconContent("FilterByType");

		private static GUIContent _filterbytype2X;
		/// <summary>
		/// FilterByType@2x
		/// </summary>
		public static GUIContent Filterbytype2X => _filterbytype2X ??= EditorGUIUtility.IconContent("FilterByType@2x");

		private static GUIContent _filterselectedonly;
		/// <summary>
		/// FilterSelectedOnly
		/// </summary>
		public static GUIContent Filterselectedonly => _filterselectedonly ??= EditorGUIUtility.IconContent("FilterSelectedOnly");

		private static GUIContent _filterselectedonly2X;
		/// <summary>
		/// FilterSelectedOnly@2x
		/// </summary>
		public static GUIContent Filterselectedonly2X => _filterselectedonly2X ??= EditorGUIUtility.IconContent("FilterSelectedOnly@2x");

		private static GUIContent _forward;
		/// <summary>
		/// forward
		/// </summary>
		public static GUIContent Forward => _forward ??= EditorGUIUtility.IconContent("forward");

		private static GUIContent _forward2X;
		/// <summary>
		/// forward@2x
		/// </summary>
		public static GUIContent Forward2X => _forward2X ??= EditorGUIUtility.IconContent("forward@2x");

		private static GUIContent _framecapture;
		/// <summary>
		/// FrameCapture
		/// </summary>
		public static GUIContent Framecapture => _framecapture ??= EditorGUIUtility.IconContent("FrameCapture");

		private static GUIContent _framecapture2X;
		/// <summary>
		/// FrameCapture@2x
		/// </summary>
		public static GUIContent Framecapture2X => _framecapture2X ??= EditorGUIUtility.IconContent("FrameCapture@2x");

		private static GUIContent _gear;
		/// <summary>
		/// GEAR
		/// </summary>
		public static GUIContent Gear => _gear ??= EditorGUIUtility.IconContent("GEAR");

		private static GUIContent _gridboxtool;
		/// <summary>
		/// Grid.BoxTool
		/// </summary>
		public static GUIContent GridBoxtool => _gridboxtool ??= EditorGUIUtility.IconContent("Grid.BoxTool");

		private static GUIContent _gridboxtool2X;
		/// <summary>
		/// Grid.BoxTool@2x
		/// </summary>
		public static GUIContent GridBoxtool2X => _gridboxtool2X ??= EditorGUIUtility.IconContent("Grid.BoxTool@2x");

		private static GUIContent _griddefault;
		/// <summary>
		/// Grid.Default
		/// </summary>
		public static GUIContent GridDefault => _griddefault ??= EditorGUIUtility.IconContent("Grid.Default");

		private static GUIContent _griddefault2X;
		/// <summary>
		/// Grid.Default@2x
		/// </summary>
		public static GUIContent GridDefault2X => _griddefault2X ??= EditorGUIUtility.IconContent("Grid.Default@2x");

		private static GUIContent _griderasertool;
		/// <summary>
		/// Grid.EraserTool
		/// </summary>
		public static GUIContent GridErasertool => _griderasertool ??= EditorGUIUtility.IconContent("Grid.EraserTool");

		private static GUIContent _griderasertool2X;
		/// <summary>
		/// Grid.EraserTool@2x
		/// </summary>
		public static GUIContent GridErasertool2X => _griderasertool2X ??= EditorGUIUtility.IconContent("Grid.EraserTool@2x");

		private static GUIContent _gridfilltool;
		/// <summary>
		/// Grid.FillTool
		/// </summary>
		public static GUIContent GridFilltool => _gridfilltool ??= EditorGUIUtility.IconContent("Grid.FillTool");

		private static GUIContent _gridfilltool2X;
		/// <summary>
		/// Grid.FillTool@2x
		/// </summary>
		public static GUIContent GridFilltool2X => _gridfilltool2X ??= EditorGUIUtility.IconContent("Grid.FillTool@2x");

		private static GUIContent _gridmovetool;
		/// <summary>
		/// Grid.MoveTool
		/// </summary>
		public static GUIContent GridMovetool => _gridmovetool ??= EditorGUIUtility.IconContent("Grid.MoveTool");

		private static GUIContent _gridmovetool2X;
		/// <summary>
		/// Grid.MoveTool@2x
		/// </summary>
		public static GUIContent GridMovetool2X => _gridmovetool2X ??= EditorGUIUtility.IconContent("Grid.MoveTool@2x");

		private static GUIContent _gridpainttool;
		/// <summary>
		/// Grid.PaintTool
		/// </summary>
		public static GUIContent GridPainttool => _gridpainttool ??= EditorGUIUtility.IconContent("Grid.PaintTool");

		private static GUIContent _gridpainttool2X;
		/// <summary>
		/// Grid.PaintTool@2x
		/// </summary>
		public static GUIContent GridPainttool2X => _gridpainttool2X ??= EditorGUIUtility.IconContent("Grid.PaintTool@2x");

		private static GUIContent _gridpickingtool;
		/// <summary>
		/// Grid.PickingTool
		/// </summary>
		public static GUIContent GridPickingtool => _gridpickingtool ??= EditorGUIUtility.IconContent("Grid.PickingTool");

		private static GUIContent _gridpickingtool2X;
		/// <summary>
		/// Grid.PickingTool@2x
		/// </summary>
		public static GUIContent GridPickingtool2X => _gridpickingtool2X ??= EditorGUIUtility.IconContent("Grid.PickingTool@2x");

		private static GUIContent _groove;
		/// <summary>
		/// Groove
		/// </summary>
		public static GUIContent Groove => _groove ??= EditorGUIUtility.IconContent("Groove");

		private static GUIContent _alignhorizontally;
		/// <summary>
		/// align_horizontally
		/// </summary>
		public static GUIContent AlignHorizontally => _alignhorizontally ??= EditorGUIUtility.IconContent("align_horizontally");

		private static GUIContent _alignhorizontallycenter;
		/// <summary>
		/// align_horizontally_center
		/// </summary>
		public static GUIContent AlignHorizontallyCenter => _alignhorizontallycenter ??= EditorGUIUtility.IconContent("align_horizontally_center");

		private static GUIContent _alignhorizontallycenteractive;
		/// <summary>
		/// align_horizontally_center_active
		/// </summary>
		public static GUIContent AlignHorizontallyCenterActive => _alignhorizontallycenteractive ??= EditorGUIUtility.IconContent("align_horizontally_center_active");

		private static GUIContent _alignhorizontallyleft;
		/// <summary>
		/// align_horizontally_left
		/// </summary>
		public static GUIContent AlignHorizontallyLeft => _alignhorizontallyleft ??= EditorGUIUtility.IconContent("align_horizontally_left");

		private static GUIContent _alignhorizontallyleftactive;
		/// <summary>
		/// align_horizontally_left_active
		/// </summary>
		public static GUIContent AlignHorizontallyLeftActive => _alignhorizontallyleftactive ??= EditorGUIUtility.IconContent("align_horizontally_left_active");

		private static GUIContent _alignhorizontallyright;
		/// <summary>
		/// align_horizontally_right
		/// </summary>
		public static GUIContent AlignHorizontallyRight => _alignhorizontallyright ??= EditorGUIUtility.IconContent("align_horizontally_right");

		private static GUIContent _alignhorizontallyrightactive;
		/// <summary>
		/// align_horizontally_right_active
		/// </summary>
		public static GUIContent AlignHorizontallyRightActive => _alignhorizontallyrightactive ??= EditorGUIUtility.IconContent("align_horizontally_right_active");

		private static GUIContent _alignvertically;
		/// <summary>
		/// align_vertically
		/// </summary>
		public static GUIContent AlignVertically => _alignvertically ??= EditorGUIUtility.IconContent("align_vertically");

		private static GUIContent _alignverticallybottom;
		/// <summary>
		/// align_vertically_bottom
		/// </summary>
		public static GUIContent AlignVerticallyBottom => _alignverticallybottom ??= EditorGUIUtility.IconContent("align_vertically_bottom");

		private static GUIContent _alignverticallybottomactive;
		/// <summary>
		/// align_vertically_bottom_active
		/// </summary>
		public static GUIContent AlignVerticallyBottomActive => _alignverticallybottomactive ??= EditorGUIUtility.IconContent("align_vertically_bottom_active");

		private static GUIContent _alignverticallycenter;
		/// <summary>
		/// align_vertically_center
		/// </summary>
		public static GUIContent AlignVerticallyCenter => _alignverticallycenter ??= EditorGUIUtility.IconContent("align_vertically_center");

		private static GUIContent _alignverticallycenteractive;
		/// <summary>
		/// align_vertically_center_active
		/// </summary>
		public static GUIContent AlignVerticallyCenterActive => _alignverticallycenteractive ??= EditorGUIUtility.IconContent("align_vertically_center_active");

		private static GUIContent _alignverticallytop;
		/// <summary>
		/// align_vertically_top
		/// </summary>
		public static GUIContent AlignVerticallyTop => _alignverticallytop ??= EditorGUIUtility.IconContent("align_vertically_top");

		private static GUIContent _alignverticallytopactive;
		/// <summary>
		/// align_vertically_top_active
		/// </summary>
		public static GUIContent AlignVerticallyTopActive => _alignverticallytopactive ??= EditorGUIUtility.IconContent("align_vertically_top_active");

		private static GUIContent _dalignhorizontally;
		/// <summary>
		/// d_align_horizontally
		/// </summary>
		public static GUIContent DAlignHorizontally => _dalignhorizontally ??= EditorGUIUtility.IconContent("d_align_horizontally");

		private static GUIContent _dalignhorizontallycenter;
		/// <summary>
		/// d_align_horizontally_center
		/// </summary>
		public static GUIContent DAlignHorizontallyCenter => _dalignhorizontallycenter ??= EditorGUIUtility.IconContent("d_align_horizontally_center");

		private static GUIContent _dalignhorizontallycenteractive;
		/// <summary>
		/// d_align_horizontally_center_active
		/// </summary>
		public static GUIContent DAlignHorizontallyCenterActive => _dalignhorizontallycenteractive ??= EditorGUIUtility.IconContent("d_align_horizontally_center_active");

		private static GUIContent _dalignhorizontallyleft;
		/// <summary>
		/// d_align_horizontally_left
		/// </summary>
		public static GUIContent DAlignHorizontallyLeft => _dalignhorizontallyleft ??= EditorGUIUtility.IconContent("d_align_horizontally_left");

		private static GUIContent _dalignhorizontallyleftactive;
		/// <summary>
		/// d_align_horizontally_left_active
		/// </summary>
		public static GUIContent DAlignHorizontallyLeftActive => _dalignhorizontallyleftactive ??= EditorGUIUtility.IconContent("d_align_horizontally_left_active");

		private static GUIContent _dalignhorizontallyright;
		/// <summary>
		/// d_align_horizontally_right
		/// </summary>
		public static GUIContent DAlignHorizontallyRight => _dalignhorizontallyright ??= EditorGUIUtility.IconContent("d_align_horizontally_right");

		private static GUIContent _dalignhorizontallyrightactive;
		/// <summary>
		/// d_align_horizontally_right_active
		/// </summary>
		public static GUIContent DAlignHorizontallyRightActive => _dalignhorizontallyrightactive ??= EditorGUIUtility.IconContent("d_align_horizontally_right_active");

		private static GUIContent _dalignvertically;
		/// <summary>
		/// d_align_vertically
		/// </summary>
		public static GUIContent DAlignVertically => _dalignvertically ??= EditorGUIUtility.IconContent("d_align_vertically");

		private static GUIContent _dalignverticallybottom;
		/// <summary>
		/// d_align_vertically_bottom
		/// </summary>
		public static GUIContent DAlignVerticallyBottom => _dalignverticallybottom ??= EditorGUIUtility.IconContent("d_align_vertically_bottom");

		private static GUIContent _dalignverticallybottomactive;
		/// <summary>
		/// d_align_vertically_bottom_active
		/// </summary>
		public static GUIContent DAlignVerticallyBottomActive => _dalignverticallybottomactive ??= EditorGUIUtility.IconContent("d_align_vertically_bottom_active");

		private static GUIContent _dalignverticallycenter;
		/// <summary>
		/// d_align_vertically_center
		/// </summary>
		public static GUIContent DAlignVerticallyCenter => _dalignverticallycenter ??= EditorGUIUtility.IconContent("d_align_vertically_center");

		private static GUIContent _dalignverticallycenteractive;
		/// <summary>
		/// d_align_vertically_center_active
		/// </summary>
		public static GUIContent DAlignVerticallyCenterActive => _dalignverticallycenteractive ??= EditorGUIUtility.IconContent("d_align_vertically_center_active");

		private static GUIContent _dalignverticallytop;
		/// <summary>
		/// d_align_vertically_top
		/// </summary>
		public static GUIContent DAlignVerticallyTop => _dalignverticallytop ??= EditorGUIUtility.IconContent("d_align_vertically_top");

		private static GUIContent _dalignverticallytopactive;
		/// <summary>
		/// d_align_vertically_top_active
		/// </summary>
		public static GUIContent DAlignVerticallyTopActive => _dalignverticallytopactive ??= EditorGUIUtility.IconContent("d_align_vertically_top_active");

		private static GUIContent _horizontalsplit;
		/// <summary>
		/// HorizontalSplit
		/// </summary>
		public static GUIContent Horizontalsplit => _horizontalsplit ??= EditorGUIUtility.IconContent("HorizontalSplit");

		private static GUIContent _icondropdown;
		/// <summary>
		/// icon dropdown
		/// </summary>
		public static GUIContent IconDropdown => _icondropdown ??= EditorGUIUtility.IconContent("icon dropdown");

		private static GUIContent _icondropdown2X;
		/// <summary>
		/// icon dropdown@2x
		/// </summary>
		public static GUIContent IconDropdown2X => _icondropdown2X ??= EditorGUIUtility.IconContent("icon dropdown@2x");

		private static GUIContent _import;
		/// <summary>
		/// Import
		/// </summary>
		public static GUIContent Import => _import ??= EditorGUIUtility.IconContent("Import");

		private static GUIContent _import2X;
		/// <summary>
		/// Import@2x
		/// </summary>
		public static GUIContent Import2X => _import2X ??= EditorGUIUtility.IconContent("Import@2x");

		private static GUIContent _inspectorlock;
		/// <summary>
		/// InspectorLock
		/// </summary>
		public static GUIContent Inspectorlock => _inspectorlock ??= EditorGUIUtility.IconContent("InspectorLock");

		private static GUIContent _invalid;
		/// <summary>
		/// Invalid
		/// </summary>
		public static GUIContent Invalid => _invalid ??= EditorGUIUtility.IconContent("Invalid");

		private static GUIContent _invalid2X;
		/// <summary>
		/// Invalid@2x
		/// </summary>
		public static GUIContent Invalid2X => _invalid2X ??= EditorGUIUtility.IconContent("Invalid@2x");

		private static GUIContent _jointangularlimits;
		/// <summary>
		/// JointAngularLimits
		/// </summary>
		public static GUIContent Jointangularlimits => _jointangularlimits ??= EditorGUIUtility.IconContent("JointAngularLimits");

		private static GUIContent _knobcshape;
		/// <summary>
		/// KnobCShape
		/// </summary>
		public static GUIContent Knobcshape => _knobcshape ??= EditorGUIUtility.IconContent("KnobCShape");

		private static GUIContent _knobcshapemini;
		/// <summary>
		/// KnobCShapeMini
		/// </summary>
		public static GUIContent Knobcshapemini => _knobcshapemini ??= EditorGUIUtility.IconContent("KnobCShapeMini");

		private static GUIContent _leftbracket;
		/// <summary>
		/// leftBracket
		/// </summary>
		public static GUIContent Leftbracket => _leftbracket ??= EditorGUIUtility.IconContent("leftBracket");

		private static GUIContent _lighting;
		/// <summary>
		/// Lighting
		/// </summary>
		public static GUIContent Lighting => _lighting ??= EditorGUIUtility.IconContent("Lighting");

		private static GUIContent _lighting2X;
		/// <summary>
		/// Lighting@2x
		/// </summary>
		public static GUIContent Lighting2X => _lighting2X ??= EditorGUIUtility.IconContent("Lighting@2x");

		private static GUIContent _lightmapeditorwindowtitle;
		/// <summary>
		/// LightmapEditor.WindowTitle
		/// </summary>
		public static GUIContent LightmapeditorWindowtitle => _lightmapeditorwindowtitle ??= EditorGUIUtility.IconContent("LightmapEditor.WindowTitle");

		private static GUIContent _lightmapeditorwindowtitle2X;
		/// <summary>
		/// LightmapEditor.WindowTitle@2x
		/// </summary>
		public static GUIContent LightmapeditorWindowtitle2X => _lightmapeditorwindowtitle2X ??= EditorGUIUtility.IconContent("LightmapEditor.WindowTitle@2x");

		private static GUIContent _lightmapping;
		/// <summary>
		/// Lightmapping
		/// </summary>
		public static GUIContent Lightmapping => _lightmapping ??= EditorGUIUtility.IconContent("Lightmapping");

		private static GUIContent _dgreenlight;
		/// <summary>
		/// d_greenLight
		/// </summary>
		public static GUIContent DGreenlight => _dgreenlight ??= EditorGUIUtility.IconContent("d_greenLight");

		private static GUIContent _dlightoff;
		/// <summary>
		/// d_lightOff
		/// </summary>
		public static GUIContent DLightoff => _dlightoff ??= EditorGUIUtility.IconContent("d_lightOff");

		private static GUIContent _dlightrim;
		/// <summary>
		/// d_lightRim
		/// </summary>
		public static GUIContent DLightrim => _dlightrim ??= EditorGUIUtility.IconContent("d_lightRim");

		private static GUIContent _dorangelight;
		/// <summary>
		/// d_orangeLight
		/// </summary>
		public static GUIContent DOrangelight => _dorangelight ??= EditorGUIUtility.IconContent("d_orangeLight");

		private static GUIContent _dredlight;
		/// <summary>
		/// d_redLight
		/// </summary>
		public static GUIContent DRedlight => _dredlight ??= EditorGUIUtility.IconContent("d_redLight");

		private static GUIContent _greenlight;
		/// <summary>
		/// greenLight
		/// </summary>
		public static GUIContent Greenlight => _greenlight ??= EditorGUIUtility.IconContent("greenLight");

		private static GUIContent _lightoff;
		/// <summary>
		/// lightOff
		/// </summary>
		public static GUIContent Lightoff => _lightoff ??= EditorGUIUtility.IconContent("lightOff");

		private static GUIContent _lightrim;
		/// <summary>
		/// lightRim
		/// </summary>
		public static GUIContent Lightrim => _lightrim ??= EditorGUIUtility.IconContent("lightRim");

		private static GUIContent _orangelight;
		/// <summary>
		/// orangeLight
		/// </summary>
		public static GUIContent Orangelight => _orangelight ??= EditorGUIUtility.IconContent("orangeLight");

		private static GUIContent _redlight;
		/// <summary>
		/// redLight
		/// </summary>
		public static GUIContent Redlight => _redlight ??= EditorGUIUtility.IconContent("redLight");

		private static GUIContent _linked;
		/// <summary>
		/// Linked
		/// </summary>
		public static GUIContent Linked => _linked ??= EditorGUIUtility.IconContent("Linked");

		private static GUIContent _linked2X;
		/// <summary>
		/// Linked@2x
		/// </summary>
		public static GUIContent Linked2X => _linked2X ??= EditorGUIUtility.IconContent("Linked@2x");

		private static GUIContent _lockiconon;
		/// <summary>
		/// LockIcon-On
		/// </summary>
		public static GUIContent LockiconOn => _lockiconon ??= EditorGUIUtility.IconContent("LockIcon-On");

		private static GUIContent _lockicon;
		/// <summary>
		/// LockIcon
		/// </summary>
		public static GUIContent Lockicon => _lockicon ??= EditorGUIUtility.IconContent("LockIcon");

		private static GUIContent _loop;
		/// <summary>
		/// loop
		/// </summary>
		public static GUIContent Loop => _loop ??= EditorGUIUtility.IconContent("loop");

		private static GUIContent _mainstageview;
		/// <summary>
		/// MainStageView
		/// </summary>
		public static GUIContent Mainstageview => _mainstageview ??= EditorGUIUtility.IconContent("MainStageView");

		private static GUIContent _mainstageview2X;
		/// <summary>
		/// MainStageView@2x
		/// </summary>
		public static GUIContent Mainstageview2X => _mainstageview2X ??= EditorGUIUtility.IconContent("MainStageView@2x");

		private static GUIContent _mirror;
		/// <summary>
		/// Mirror
		/// </summary>
		public static GUIContent Mirror => _mirror ??= EditorGUIUtility.IconContent("Mirror");

		private static GUIContent _monologo;
		/// <summary>
		/// monologo
		/// </summary>
		public static GUIContent Monologo => _monologo ??= EditorGUIUtility.IconContent("monologo");

		private static GUIContent _moreoptions;
		/// <summary>
		/// MoreOptions
		/// </summary>
		public static GUIContent Moreoptions => _moreoptions ??= EditorGUIUtility.IconContent("MoreOptions");

		private static GUIContent _moreoptions2X;
		/// <summary>
		/// MoreOptions@2x
		/// </summary>
		public static GUIContent Moreoptions2X => _moreoptions2X ??= EditorGUIUtility.IconContent("MoreOptions@2x");

		private static GUIContent _movetoolon;
		/// <summary>
		/// MoveTool on
		/// </summary>
		public static GUIContent MovetoolOn => _movetoolon ??= EditorGUIUtility.IconContent("MoveTool on");

		private static GUIContent _movetoolon2X;
		/// <summary>
		/// MoveTool On@2x
		/// </summary>
		public static GUIContent MovetoolOn2X => _movetoolon2X ??= EditorGUIUtility.IconContent("MoveTool On@2x");

		private static GUIContent _movetool;
		/// <summary>
		/// MoveTool
		/// </summary>
		public static GUIContent Movetool => _movetool ??= EditorGUIUtility.IconContent("MoveTool");

		private static GUIContent _movetool2X;
		/// <summary>
		/// MoveTool@2x
		/// </summary>
		public static GUIContent Movetool2X => _movetool2X ??= EditorGUIUtility.IconContent("MoveTool@2x");

		private static GUIContent _navigation;
		/// <summary>
		/// Navigation
		/// </summary>
		public static GUIContent Navigation => _navigation ??= EditorGUIUtility.IconContent("Navigation");

		private static GUIContent _occlusion;
		/// <summary>
		/// Occlusion
		/// </summary>
		public static GUIContent Occlusion => _occlusion ??= EditorGUIUtility.IconContent("Occlusion");

		private static GUIContent _occlusion2X;
		/// <summary>
		/// Occlusion@2x
		/// </summary>
		public static GUIContent Occlusion2X => _occlusion2X ??= EditorGUIUtility.IconContent("Occlusion@2x");

		private static GUIContent _packagemanager;
		/// <summary>
		/// Package Manager
		/// </summary>
		public static GUIContent PackageManager => _packagemanager ??= EditorGUIUtility.IconContent("Package Manager");

		private static GUIContent _packagemanager2X;
		/// <summary>
		/// Package Manager@2x
		/// </summary>
		public static GUIContent PackageManager2X => _packagemanager2X ??= EditorGUIUtility.IconContent("Package Manager@2x");

		private static GUIContent _packagebadgedelete;
		/// <summary>
		/// PackageBadgeDelete
		/// </summary>
		public static GUIContent Packagebadgedelete => _packagebadgedelete ??= EditorGUIUtility.IconContent("PackageBadgeDelete");

		private static GUIContent _packagebadgenew;
		/// <summary>
		/// PackageBadgeNew
		/// </summary>
		public static GUIContent Packagebadgenew => _packagebadgenew ??= EditorGUIUtility.IconContent("PackageBadgeNew");

		private static GUIContent _addavailable;
		/// <summary>
		/// Add-Available
		/// </summary>
		public static GUIContent AddAvailable => _addavailable ??= EditorGUIUtility.IconContent("Add-Available");

		private static GUIContent _addavailable2X;
		/// <summary>
		/// Add-Available@2x
		/// </summary>
		public static GUIContent AddAvailable2X => _addavailable2X ??= EditorGUIUtility.IconContent("Add-Available@2x");

		private static GUIContent _downloadavailable;
		/// <summary>
		/// Download-Available
		/// </summary>
		public static GUIContent DownloadAvailable => _downloadavailable ??= EditorGUIUtility.IconContent("Download-Available");

		private static GUIContent _downloadavailable2X;
		/// <summary>
		/// Download-Available@2x
		/// </summary>
		public static GUIContent DownloadAvailable2X => _downloadavailable2X ??= EditorGUIUtility.IconContent("Download-Available@2x");

		private static GUIContent _error;
		/// <summary>
		/// Error
		/// </summary>
		public static GUIContent Error => _error ??= EditorGUIUtility.IconContent("Error");

		private static GUIContent _error2X;
		/// <summary>
		/// Error@2x
		/// </summary>
		public static GUIContent Error2X => _error2X ??= EditorGUIUtility.IconContent("Error@2x");

		private static GUIContent _importavailable;
		/// <summary>
		/// Import-Available
		/// </summary>
		public static GUIContent ImportAvailable => _importavailable ??= EditorGUIUtility.IconContent("Import-Available");

		private static GUIContent _importavailable2X;
		/// <summary>
		/// Import-Available@2x
		/// </summary>
		public static GUIContent ImportAvailable2X => _importavailable2X ??= EditorGUIUtility.IconContent("Import-Available@2x");

		private static GUIContent _indevelopment;
		/// <summary>
		/// In-Development
		/// </summary>
		public static GUIContent InDevelopment => _indevelopment ??= EditorGUIUtility.IconContent("In-Development");

		private static GUIContent _indevelopment2X;
		/// <summary>
		/// In-Development@2x
		/// </summary>
		public static GUIContent InDevelopment2X => _indevelopment2X ??= EditorGUIUtility.IconContent("In-Development@2x");

		private static GUIContent _installed;
		/// <summary>
		/// Installed
		/// </summary>
		public static GUIContent Installed => _installed ??= EditorGUIUtility.IconContent("Installed");

		private static GUIContent _installed2X;
		/// <summary>
		/// Installed@2x
		/// </summary>
		public static GUIContent Installed2X => _installed2X ??= EditorGUIUtility.IconContent("Installed@2x");

		private static GUIContent _loading;
		/// <summary>
		/// Loading
		/// </summary>
		public static GUIContent Loading => _loading ??= EditorGUIUtility.IconContent("Loading");

		private static GUIContent _loading2X;
		/// <summary>
		/// Loading@2x
		/// </summary>
		public static GUIContent Loading2X => _loading2X ??= EditorGUIUtility.IconContent("Loading@2x");

		private static GUIContent _refresh;
		/// <summary>
		/// Refresh
		/// </summary>
		public static GUIContent Refresh => _refresh ??= EditorGUIUtility.IconContent("Refresh");

		private static GUIContent _refresh2X;
		/// <summary>
		/// Refresh@2x
		/// </summary>
		public static GUIContent Refresh2X => _refresh2X ??= EditorGUIUtility.IconContent("Refresh@2x");

		private static GUIContent _updateavailable;
		/// <summary>
		/// Update-Available
		/// </summary>
		public static GUIContent UpdateAvailable => _updateavailable ??= EditorGUIUtility.IconContent("Update-Available");

		private static GUIContent _updateavailable2X;
		/// <summary>
		/// Update-Available@2x
		/// </summary>
		public static GUIContent UpdateAvailable2X => _updateavailable2X ??= EditorGUIUtility.IconContent("Update-Available@2x");

		private static GUIContent _warning;
		/// <summary>
		/// Warning
		/// </summary>
		public static GUIContent Warning => _warning ??= EditorGUIUtility.IconContent("Warning");

		private static GUIContent _warning2X;
		/// <summary>
		/// Warning@2x
		/// </summary>
		public static GUIContent Warning2X => _warning2X ??= EditorGUIUtility.IconContent("Warning@2x");

		private static GUIContent _addavailable1;
		/// <summary>
		/// Add-Available
		/// </summary>
		public static GUIContent AddAvailable1 => _addavailable1 ??= EditorGUIUtility.IconContent("Add-Available");

		private static GUIContent _addavailable2X1;
		/// <summary>
		/// Add-Available@2x
		/// </summary>
		public static GUIContent AddAvailable2X1 => _addavailable2X1 ??= EditorGUIUtility.IconContent("Add-Available@2x");

		private static GUIContent _downloadavailable1;
		/// <summary>
		/// Download-Available
		/// </summary>
		public static GUIContent DownloadAvailable1 => _downloadavailable1 ??= EditorGUIUtility.IconContent("Download-Available");

		private static GUIContent _downloadavailable2X1;
		/// <summary>
		/// Download-Available@2x
		/// </summary>
		public static GUIContent DownloadAvailable2X1 => _downloadavailable2X1 ??= EditorGUIUtility.IconContent("Download-Available@2x");

		private static GUIContent _error1;
		/// <summary>
		/// Error
		/// </summary>
		public static GUIContent Error1 => _error1 ??= EditorGUIUtility.IconContent("Error");

		private static GUIContent _error2X1;
		/// <summary>
		/// Error@2x
		/// </summary>
		public static GUIContent Error2X1 => _error2X1 ??= EditorGUIUtility.IconContent("Error@2x");

		private static GUIContent _importavailable1;
		/// <summary>
		/// Import-Available
		/// </summary>
		public static GUIContent ImportAvailable1 => _importavailable1 ??= EditorGUIUtility.IconContent("Import-Available");

		private static GUIContent _importavailable2X1;
		/// <summary>
		/// Import-Available@2x
		/// </summary>
		public static GUIContent ImportAvailable2X1 => _importavailable2X1 ??= EditorGUIUtility.IconContent("Import-Available@2x");

		private static GUIContent _indevelopment1;
		/// <summary>
		/// In-Development
		/// </summary>
		public static GUIContent InDevelopment1 => _indevelopment1 ??= EditorGUIUtility.IconContent("In-Development");

		private static GUIContent _indevelopment2X1;
		/// <summary>
		/// In-Development@2x
		/// </summary>
		public static GUIContent InDevelopment2X1 => _indevelopment2X1 ??= EditorGUIUtility.IconContent("In-Development@2x");

		private static GUIContent _installed1;
		/// <summary>
		/// Installed
		/// </summary>
		public static GUIContent Installed1 => _installed1 ??= EditorGUIUtility.IconContent("Installed");

		private static GUIContent _installed2X1;
		/// <summary>
		/// Installed@2x
		/// </summary>
		public static GUIContent Installed2X1 => _installed2X1 ??= EditorGUIUtility.IconContent("Installed@2x");

		private static GUIContent _loading1;
		/// <summary>
		/// Loading
		/// </summary>
		public static GUIContent Loading1 => _loading1 ??= EditorGUIUtility.IconContent("Loading");

		private static GUIContent _loading2X1;
		/// <summary>
		/// Loading@2x
		/// </summary>
		public static GUIContent Loading2X1 => _loading2X1 ??= EditorGUIUtility.IconContent("Loading@2x");

		private static GUIContent _refresh1;
		/// <summary>
		/// Refresh
		/// </summary>
		public static GUIContent Refresh1 => _refresh1 ??= EditorGUIUtility.IconContent("Refresh");

		private static GUIContent _refresh2X1;
		/// <summary>
		/// Refresh@2x
		/// </summary>
		public static GUIContent Refresh2X1 => _refresh2X1 ??= EditorGUIUtility.IconContent("Refresh@2x");

		private static GUIContent _updateavailable1;
		/// <summary>
		/// Update-Available
		/// </summary>
		public static GUIContent UpdateAvailable1 => _updateavailable1 ??= EditorGUIUtility.IconContent("Update-Available");

		private static GUIContent _updateavailable2X1;
		/// <summary>
		/// Update-Available@2x
		/// </summary>
		public static GUIContent UpdateAvailable2X1 => _updateavailable2X1 ??= EditorGUIUtility.IconContent("Update-Available@2x");

		private static GUIContent _warning1;
		/// <summary>
		/// Warning
		/// </summary>
		public static GUIContent Warning1 => _warning1 ??= EditorGUIUtility.IconContent("Warning");

		private static GUIContent _warning2X1;
		/// <summary>
		/// Warning@2x
		/// </summary>
		public static GUIContent Warning2X1 => _warning2X1 ??= EditorGUIUtility.IconContent("Warning@2x");

		private static GUIContent _particleeffect;
		/// <summary>
		/// Particle Effect
		/// </summary>
		public static GUIContent ParticleEffect => _particleeffect ??= EditorGUIUtility.IconContent("Particle Effect");

		private static GUIContent _particleshapetoolon;
		/// <summary>
		/// ParticleShapeTool On
		/// </summary>
		public static GUIContent ParticleshapetoolOn => _particleshapetoolon ??= EditorGUIUtility.IconContent("ParticleShapeTool On");

		private static GUIContent _particleshapetoolon2X;
		/// <summary>
		/// ParticleShapeTool On@2x
		/// </summary>
		public static GUIContent ParticleshapetoolOn2X => _particleshapetoolon2X ??= EditorGUIUtility.IconContent("ParticleShapeTool On@2x");

		private static GUIContent _particleshapetoolon3X;
		/// <summary>
		/// ParticleShapeTool On@3x
		/// </summary>
		public static GUIContent ParticleshapetoolOn3X => _particleshapetoolon3X ??= EditorGUIUtility.IconContent("ParticleShapeTool On@3x");

		private static GUIContent _particleshapetoolon4X;
		/// <summary>
		/// ParticleShapeTool On@4x
		/// </summary>
		public static GUIContent ParticleshapetoolOn4X => _particleshapetoolon4X ??= EditorGUIUtility.IconContent("ParticleShapeTool On@4x");

		private static GUIContent _particleshapetool;
		/// <summary>
		/// ParticleShapeTool
		/// </summary>
		public static GUIContent Particleshapetool => _particleshapetool ??= EditorGUIUtility.IconContent("ParticleShapeTool");

		private static GUIContent _particleshapetool2X;
		/// <summary>
		/// ParticleShapeTool@2x
		/// </summary>
		public static GUIContent Particleshapetool2X => _particleshapetool2X ??= EditorGUIUtility.IconContent("ParticleShapeTool@2x");

		private static GUIContent _particleshapetool3X;
		/// <summary>
		/// ParticleShapeTool@3x
		/// </summary>
		public static GUIContent Particleshapetool3X => _particleshapetool3X ??= EditorGUIUtility.IconContent("ParticleShapeTool@3x");

		private static GUIContent _particleshapetool4X;
		/// <summary>
		/// ParticleShapeTool@4x
		/// </summary>
		public static GUIContent Particleshapetool4X => _particleshapetool4X ??= EditorGUIUtility.IconContent("ParticleShapeTool@4x");

		private static GUIContent _pausebuttonon;
		/// <summary>
		/// PauseButton On
		/// </summary>
		public static GUIContent PausebuttonOn => _pausebuttonon ??= EditorGUIUtility.IconContent("PauseButton On");

		private static GUIContent _pausebuttonon2X;
		/// <summary>
		/// PauseButton On@2x
		/// </summary>
		public static GUIContent PausebuttonOn2X => _pausebuttonon2X ??= EditorGUIUtility.IconContent("PauseButton On@2x");

		private static GUIContent _pausebutton;
		/// <summary>
		/// PauseButton
		/// </summary>
		public static GUIContent Pausebutton => _pausebutton ??= EditorGUIUtility.IconContent("PauseButton");

		private static GUIContent _pausebutton2X;
		/// <summary>
		/// PauseButton@2x
		/// </summary>
		public static GUIContent Pausebutton2X => _pausebutton2X ??= EditorGUIUtility.IconContent("PauseButton@2x");

		private static GUIContent _playbuttonon;
		/// <summary>
		/// PlayButton On
		/// </summary>
		public static GUIContent PlaybuttonOn => _playbuttonon ??= EditorGUIUtility.IconContent("PlayButton On");

		private static GUIContent _playbuttonon2X;
		/// <summary>
		/// PlayButton On@2x
		/// </summary>
		public static GUIContent PlaybuttonOn2X => _playbuttonon2X ??= EditorGUIUtility.IconContent("PlayButton On@2x");

		private static GUIContent _playbutton;
		/// <summary>
		/// PlayButton
		/// </summary>
		public static GUIContent Playbutton => _playbutton ??= EditorGUIUtility.IconContent("PlayButton");

		private static GUIContent _playbutton2X;
		/// <summary>
		/// PlayButton@2x
		/// </summary>
		public static GUIContent Playbutton2X => _playbutton2X ??= EditorGUIUtility.IconContent("PlayButton@2x");

		private static GUIContent _playbuttonprofileon;
		/// <summary>
		/// PlayButtonProfile On
		/// </summary>
		public static GUIContent PlaybuttonprofileOn => _playbuttonprofileon ??= EditorGUIUtility.IconContent("PlayButtonProfile On");

		private static GUIContent _playbuttonprofile;
		/// <summary>
		/// PlayButtonProfile
		/// </summary>
		public static GUIContent Playbuttonprofile => _playbuttonprofile ??= EditorGUIUtility.IconContent("PlayButtonProfile");

		private static GUIContent _playloopoff;
		/// <summary>
		/// playLoopOff
		/// </summary>
		public static GUIContent Playloopoff => _playloopoff ??= EditorGUIUtility.IconContent("playLoopOff");

		private static GUIContent _playloopon;
		/// <summary>
		/// playLoopOn
		/// </summary>
		public static GUIContent Playloopon => _playloopon ??= EditorGUIUtility.IconContent("playLoopOn");

		private static GUIContent _playspeed;
		/// <summary>
		/// playSpeed
		/// </summary>
		public static GUIContent Playspeed => _playspeed ??= EditorGUIUtility.IconContent("playSpeed");

		private static GUIContent _preaudioautoplayoff;
		/// <summary>
		/// preAudioAutoPlayOff
		/// </summary>
		public static GUIContent Preaudioautoplayoff => _preaudioautoplayoff ??= EditorGUIUtility.IconContent("preAudioAutoPlayOff");

		private static GUIContent _preaudioautoplayoff2X;
		/// <summary>
		/// preAudioAutoPlayOff@2x
		/// </summary>
		public static GUIContent Preaudioautoplayoff2X => _preaudioautoplayoff2X ??= EditorGUIUtility.IconContent("preAudioAutoPlayOff@2x");

		private static GUIContent _preaudioautoplayon;
		/// <summary>
		/// preAudioAutoPlayOn
		/// </summary>
		public static GUIContent Preaudioautoplayon => _preaudioautoplayon ??= EditorGUIUtility.IconContent("preAudioAutoPlayOn");

		private static GUIContent _preaudioloopoff;
		/// <summary>
		/// preAudioLoopOff
		/// </summary>
		public static GUIContent Preaudioloopoff => _preaudioloopoff ??= EditorGUIUtility.IconContent("preAudioLoopOff");

		private static GUIContent _preaudioloopoff2X;
		/// <summary>
		/// preAudioLoopOff@2x
		/// </summary>
		public static GUIContent Preaudioloopoff2X => _preaudioloopoff2X ??= EditorGUIUtility.IconContent("preAudioLoopOff@2x");

		private static GUIContent _preaudioloopon;
		/// <summary>
		/// preAudioLoopOn
		/// </summary>
		public static GUIContent Preaudioloopon => _preaudioloopon ??= EditorGUIUtility.IconContent("preAudioLoopOn");

		private static GUIContent _preaudioplayoff;
		/// <summary>
		/// preAudioPlayOff
		/// </summary>
		public static GUIContent Preaudioplayoff => _preaudioplayoff ??= EditorGUIUtility.IconContent("preAudioPlayOff");

		private static GUIContent _preaudioplayon;
		/// <summary>
		/// preAudioPlayOn
		/// </summary>
		public static GUIContent Preaudioplayon => _preaudioplayon ??= EditorGUIUtility.IconContent("preAudioPlayOn");

		private static GUIContent _prematcube;
		/// <summary>
		/// PreMatCube
		/// </summary>
		public static GUIContent Prematcube => _prematcube ??= EditorGUIUtility.IconContent("PreMatCube");

		private static GUIContent _prematcube2X;
		/// <summary>
		/// PreMatCube@2x
		/// </summary>
		public static GUIContent Prematcube2X => _prematcube2X ??= EditorGUIUtility.IconContent("PreMatCube@2x");

		private static GUIContent _prematcylinder;
		/// <summary>
		/// PreMatCylinder
		/// </summary>
		public static GUIContent Prematcylinder => _prematcylinder ??= EditorGUIUtility.IconContent("PreMatCylinder");

		private static GUIContent _prematcylinder2X;
		/// <summary>
		/// PreMatCylinder@2x
		/// </summary>
		public static GUIContent Prematcylinder2X => _prematcylinder2X ??= EditorGUIUtility.IconContent("PreMatCylinder@2x");

		private static GUIContent _prematlight0;
		/// <summary>
		/// PreMatLight0
		/// </summary>
		public static GUIContent Prematlight0 => _prematlight0 ??= EditorGUIUtility.IconContent("PreMatLight0");

		private static GUIContent _prematlight02X;
		/// <summary>
		/// PreMatLight0@2x
		/// </summary>
		public static GUIContent Prematlight02X => _prematlight02X ??= EditorGUIUtility.IconContent("PreMatLight0@2x");

		private static GUIContent _prematlight1;
		/// <summary>
		/// PreMatLight1
		/// </summary>
		public static GUIContent Prematlight1 => _prematlight1 ??= EditorGUIUtility.IconContent("PreMatLight1");

		private static GUIContent _prematlight12X;
		/// <summary>
		/// PreMatLight1@2x
		/// </summary>
		public static GUIContent Prematlight12X => _prematlight12X ??= EditorGUIUtility.IconContent("PreMatLight1@2x");

		private static GUIContent _prematquad;
		/// <summary>
		/// PreMatQuad
		/// </summary>
		public static GUIContent Prematquad => _prematquad ??= EditorGUIUtility.IconContent("PreMatQuad");

		private static GUIContent _prematquad2X;
		/// <summary>
		/// PreMatQuad@2x
		/// </summary>
		public static GUIContent Prematquad2X => _prematquad2X ??= EditorGUIUtility.IconContent("PreMatQuad@2x");

		private static GUIContent _prematsphere;
		/// <summary>
		/// PreMatSphere
		/// </summary>
		public static GUIContent Prematsphere => _prematsphere ??= EditorGUIUtility.IconContent("PreMatSphere");

		private static GUIContent _prematsphere2X;
		/// <summary>
		/// PreMatSphere@2x
		/// </summary>
		public static GUIContent Prematsphere2X => _prematsphere2X ??= EditorGUIUtility.IconContent("PreMatSphere@2x");

		private static GUIContent _premattorus;
		/// <summary>
		/// PreMatTorus
		/// </summary>
		public static GUIContent Premattorus => _premattorus ??= EditorGUIUtility.IconContent("PreMatTorus");

		private static GUIContent _premattorus2X;
		/// <summary>
		/// PreMatTorus@2x
		/// </summary>
		public static GUIContent Premattorus2X => _premattorus2X ??= EditorGUIUtility.IconContent("PreMatTorus@2x");

		private static GUIContent _presetcontext;
		/// <summary>
		/// Preset.Context
		/// </summary>
		public static GUIContent PresetContext => _presetcontext ??= EditorGUIUtility.IconContent("Preset.Context");

		private static GUIContent _presetcontext2X;
		/// <summary>
		/// Preset.Context@2x
		/// </summary>
		public static GUIContent PresetContext2X => _presetcontext2X ??= EditorGUIUtility.IconContent("Preset.Context@2x");

		private static GUIContent _pretexa;
		/// <summary>
		/// PreTexA
		/// </summary>
		public static GUIContent Pretexa => _pretexa ??= EditorGUIUtility.IconContent("PreTexA");

		private static GUIContent _pretexa2X;
		/// <summary>
		/// PreTexA@2x
		/// </summary>
		public static GUIContent Pretexa2X => _pretexa2X ??= EditorGUIUtility.IconContent("PreTexA@2x");

		private static GUIContent _pretexb;
		/// <summary>
		/// PreTexB
		/// </summary>
		public static GUIContent Pretexb => _pretexb ??= EditorGUIUtility.IconContent("PreTexB");

		private static GUIContent _pretexb2X;
		/// <summary>
		/// PreTexB@2x
		/// </summary>
		public static GUIContent Pretexb2X => _pretexb2X ??= EditorGUIUtility.IconContent("PreTexB@2x");

		private static GUIContent _pretexg;
		/// <summary>
		/// PreTexG
		/// </summary>
		public static GUIContent Pretexg => _pretexg ??= EditorGUIUtility.IconContent("PreTexG");

		private static GUIContent _pretexg2X;
		/// <summary>
		/// PreTexG@2x
		/// </summary>
		public static GUIContent Pretexg2X => _pretexg2X ??= EditorGUIUtility.IconContent("PreTexG@2x");

		private static GUIContent _pretexr;
		/// <summary>
		/// PreTexR
		/// </summary>
		public static GUIContent Pretexr => _pretexr ??= EditorGUIUtility.IconContent("PreTexR");

		private static GUIContent _pretexr2X;
		/// <summary>
		/// PreTexR@2x
		/// </summary>
		public static GUIContent Pretexr2X => _pretexr2X ??= EditorGUIUtility.IconContent("PreTexR@2x");

		private static GUIContent _pretexrgb;
		/// <summary>
		/// PreTexRGB
		/// </summary>
		public static GUIContent Pretexrgb => _pretexrgb ??= EditorGUIUtility.IconContent("PreTexRGB");

		private static GUIContent _pretexrgb2X;
		/// <summary>
		/// PreTexRGB@2x
		/// </summary>
		public static GUIContent Pretexrgb2X => _pretexrgb2X ??= EditorGUIUtility.IconContent("PreTexRGB@2x");

		private static GUIContent _pretexturealpha;
		/// <summary>
		/// PreTextureAlpha
		/// </summary>
		public static GUIContent Pretexturealpha => _pretexturealpha ??= EditorGUIUtility.IconContent("PreTextureAlpha");

		private static GUIContent _pretexturearrayfirstslice;
		/// <summary>
		/// PreTextureArrayFirstSlice
		/// </summary>
		public static GUIContent Pretexturearrayfirstslice => _pretexturearrayfirstslice ??= EditorGUIUtility.IconContent("PreTextureArrayFirstSlice");

		private static GUIContent _pretexturearraylastslice;
		/// <summary>
		/// PreTextureArrayLastSlice
		/// </summary>
		public static GUIContent Pretexturearraylastslice => _pretexturearraylastslice ??= EditorGUIUtility.IconContent("PreTextureArrayLastSlice");

		private static GUIContent _pretexturemipmaphigh;
		/// <summary>
		/// PreTextureMipMapHigh
		/// </summary>
		public static GUIContent Pretexturemipmaphigh => _pretexturemipmaphigh ??= EditorGUIUtility.IconContent("PreTextureMipMapHigh");

		private static GUIContent _pretexturemipmaplow;
		/// <summary>
		/// PreTextureMipMapLow
		/// </summary>
		public static GUIContent Pretexturemipmaplow => _pretexturemipmaplow ??= EditorGUIUtility.IconContent("PreTextureMipMapLow");

		private static GUIContent _pretexturergb;
		/// <summary>
		/// PreTextureRGB
		/// </summary>
		public static GUIContent Pretexturergb => _pretexturergb ??= EditorGUIUtility.IconContent("PreTextureRGB");

		private static GUIContent _previewpackageinuse;
		/// <summary>
		/// PreviewPackageInUse
		/// </summary>
		public static GUIContent Previewpackageinuse => _previewpackageinuse ??= EditorGUIUtility.IconContent("PreviewPackageInUse");

		private static GUIContent _previewpackageinuse2X;
		/// <summary>
		/// PreviewPackageInUse@2x
		/// </summary>
		public static GUIContent Previewpackageinuse2X => _previewpackageinuse2X ??= EditorGUIUtility.IconContent("PreviewPackageInUse@2x");

		private static GUIContent _arealightgizmo;
		/// <summary>
		/// AreaLight Gizmo
		/// </summary>
		public static GUIContent ArealightGizmo => _arealightgizmo ??= EditorGUIUtility.IconContent("AreaLight Gizmo");

		private static GUIContent _arealighticon;
		/// <summary>
		/// AreaLight Icon
		/// </summary>
		public static GUIContent ArealightIcon => _arealighticon ??= EditorGUIUtility.IconContent("AreaLight Icon");

		private static GUIContent _assemblyicon;
		/// <summary>
		/// Assembly Icon
		/// </summary>
		public static GUIContent AssemblyIcon => _assemblyicon ??= EditorGUIUtility.IconContent("Assembly Icon");

		private static GUIContent _assetstoreicon;
		/// <summary>
		/// AssetStore Icon
		/// </summary>
		public static GUIContent AssetstoreIcon => _assetstoreicon ??= EditorGUIUtility.IconContent("AssetStore Icon");

		private static GUIContent _audiomixerviewicon;
		/// <summary>
		/// AudioMixerView Icon
		/// </summary>
		public static GUIContent AudiomixerviewIcon => _audiomixerviewicon ??= EditorGUIUtility.IconContent("AudioMixerView Icon");

		private static GUIContent _audiosourcegizmo;
		/// <summary>
		/// AudioSource Gizmo
		/// </summary>
		public static GUIContent AudiosourceGizmo => _audiosourcegizmo ??= EditorGUIUtility.IconContent("AudioSource Gizmo");

		private static GUIContent _booscripticon;
		/// <summary>
		/// boo Script Icon
		/// </summary>
		public static GUIContent BooScriptIcon => _booscripticon ??= EditorGUIUtility.IconContent("boo Script Icon");

		private static GUIContent _cameragizmo;
		/// <summary>
		/// Camera Gizmo
		/// </summary>
		public static GUIContent CameraGizmo => _cameragizmo ??= EditorGUIUtility.IconContent("Camera Gizmo");

		private static GUIContent _cgprogramicon;
		/// <summary>
		/// CGProgram Icon
		/// </summary>
		public static GUIContent CgprogramIcon => _cgprogramicon ??= EditorGUIUtility.IconContent("CGProgram Icon");

		private static GUIContent _chorusfiltericon;
		/// <summary>
		/// ChorusFilter Icon
		/// </summary>
		public static GUIContent ChorusfilterIcon => _chorusfiltericon ??= EditorGUIUtility.IconContent("ChorusFilter Icon");

		private static GUIContent _collabchangesicon;
		/// <summary>
		/// CollabChanges Icon
		/// </summary>
		public static GUIContent CollabchangesIcon => _collabchangesicon ??= EditorGUIUtility.IconContent("CollabChanges Icon");

		private static GUIContent _collabchangesconflicticon;
		/// <summary>
		/// CollabChangesConflict Icon
		/// </summary>
		public static GUIContent CollabchangesconflictIcon => _collabchangesconflicticon ??= EditorGUIUtility.IconContent("CollabChangesConflict Icon");

		private static GUIContent _collabchangesdeletedicon;
		/// <summary>
		/// CollabChangesDeleted Icon
		/// </summary>
		public static GUIContent CollabchangesdeletedIcon => _collabchangesdeletedicon ??= EditorGUIUtility.IconContent("CollabChangesDeleted Icon");

		private static GUIContent _collabconflicticon;
		/// <summary>
		/// CollabConflict Icon
		/// </summary>
		public static GUIContent CollabconflictIcon => _collabconflicticon ??= EditorGUIUtility.IconContent("CollabConflict Icon");

		private static GUIContent _collabcreateicon;
		/// <summary>
		/// CollabCreate Icon
		/// </summary>
		public static GUIContent CollabcreateIcon => _collabcreateicon ??= EditorGUIUtility.IconContent("CollabCreate Icon");

		private static GUIContent _collabdeletedicon;
		/// <summary>
		/// CollabDeleted Icon
		/// </summary>
		public static GUIContent CollabdeletedIcon => _collabdeletedicon ??= EditorGUIUtility.IconContent("CollabDeleted Icon");

		private static GUIContent _collabediticon;
		/// <summary>
		/// CollabEdit Icon
		/// </summary>
		public static GUIContent CollabeditIcon => _collabediticon ??= EditorGUIUtility.IconContent("CollabEdit Icon");

		private static GUIContent _collabexcludeicon;
		/// <summary>
		/// CollabExclude Icon
		/// </summary>
		public static GUIContent CollabexcludeIcon => _collabexcludeicon ??= EditorGUIUtility.IconContent("CollabExclude Icon");

		private static GUIContent _collabmovedicon;
		/// <summary>
		/// CollabMoved Icon
		/// </summary>
		public static GUIContent CollabmovedIcon => _collabmovedicon ??= EditorGUIUtility.IconContent("CollabMoved Icon");

		private static GUIContent _csscripticon;
		/// <summary>
		/// cs Script Icon
		/// </summary>
		public static GUIContent CsScriptIcon => _csscripticon ??= EditorGUIUtility.IconContent("cs Script Icon");

		private static GUIContent _darealighticon;
		/// <summary>
		/// d_AreaLight Icon
		/// </summary>
		public static GUIContent DArealightIcon => _darealighticon ??= EditorGUIUtility.IconContent("d_AreaLight Icon");

		private static GUIContent _dassemblyicon;
		/// <summary>
		/// d_Assembly Icon
		/// </summary>
		public static GUIContent DAssemblyIcon => _dassemblyicon ??= EditorGUIUtility.IconContent("d_Assembly Icon");

		private static GUIContent _dassetstoreicon;
		/// <summary>
		/// d_AssetStore Icon
		/// </summary>
		public static GUIContent DAssetstoreIcon => _dassetstoreicon ??= EditorGUIUtility.IconContent("d_AssetStore Icon");

		private static GUIContent _daudiomixerviewicon;
		/// <summary>
		/// d_AudioMixerView Icon
		/// </summary>
		public static GUIContent DAudiomixerviewIcon => _daudiomixerviewicon ??= EditorGUIUtility.IconContent("d_AudioMixerView Icon");

		private static GUIContent _dbooscripticon;
		/// <summary>
		/// d_boo Script Icon
		/// </summary>
		public static GUIContent DBooScriptIcon => _dbooscripticon ??= EditorGUIUtility.IconContent("d_boo Script Icon");

		private static GUIContent _dcgprogramicon;
		/// <summary>
		/// d_CGProgram Icon
		/// </summary>
		public static GUIContent DCgprogramIcon => _dcgprogramicon ??= EditorGUIUtility.IconContent("d_CGProgram Icon");

		private static GUIContent _dcollabchangesicon;
		/// <summary>
		/// d_CollabChanges Icon
		/// </summary>
		public static GUIContent DCollabchangesIcon => _dcollabchangesicon ??= EditorGUIUtility.IconContent("d_CollabChanges Icon");

		private static GUIContent _dcollabchangesconflicticon;
		/// <summary>
		/// d_CollabChangesConflict Icon
		/// </summary>
		public static GUIContent DCollabchangesconflictIcon => _dcollabchangesconflicticon ??= EditorGUIUtility.IconContent("d_CollabChangesConflict Icon");

		private static GUIContent _dcollabchangesdeletedicon;
		/// <summary>
		/// d_CollabChangesDeleted Icon
		/// </summary>
		public static GUIContent DCollabchangesdeletedIcon => _dcollabchangesdeletedicon ??= EditorGUIUtility.IconContent("d_CollabChangesDeleted Icon");

		private static GUIContent _dcollabconflicticon;
		/// <summary>
		/// d_CollabConflict Icon
		/// </summary>
		public static GUIContent DCollabconflictIcon => _dcollabconflicticon ??= EditorGUIUtility.IconContent("d_CollabConflict Icon");

		private static GUIContent _dcollabcreateicon;
		/// <summary>
		/// d_CollabCreate Icon
		/// </summary>
		public static GUIContent DCollabcreateIcon => _dcollabcreateicon ??= EditorGUIUtility.IconContent("d_CollabCreate Icon");

		private static GUIContent _dcollabdeletedicon;
		/// <summary>
		/// d_CollabDeleted Icon
		/// </summary>
		public static GUIContent DCollabdeletedIcon => _dcollabdeletedicon ??= EditorGUIUtility.IconContent("d_CollabDeleted Icon");

		private static GUIContent _dcollabediticon;
		/// <summary>
		/// d_CollabEdit Icon
		/// </summary>
		public static GUIContent DCollabeditIcon => _dcollabediticon ??= EditorGUIUtility.IconContent("d_CollabEdit Icon");

		private static GUIContent _dcollabexcludeicon;
		/// <summary>
		/// d_CollabExclude Icon
		/// </summary>
		public static GUIContent DCollabexcludeIcon => _dcollabexcludeicon ??= EditorGUIUtility.IconContent("d_CollabExclude Icon");

		private static GUIContent _dcollabmovedicon;
		/// <summary>
		/// d_CollabMoved Icon
		/// </summary>
		public static GUIContent DCollabmovedIcon => _dcollabmovedicon ??= EditorGUIUtility.IconContent("d_CollabMoved Icon");

		private static GUIContent _dcsscripticon;
		/// <summary>
		/// d_cs Script Icon
		/// </summary>
		public static GUIContent DCsScriptIcon => _dcsscripticon ??= EditorGUIUtility.IconContent("d_cs Script Icon");

		private static GUIContent _ddirectionallighticon;
		/// <summary>
		/// d_DirectionalLight Icon
		/// </summary>
		public static GUIContent DDirectionallightIcon => _ddirectionallighticon ??= EditorGUIUtility.IconContent("d_DirectionalLight Icon");

		private static GUIContent _dfavoriteicon;
		/// <summary>
		/// d_Favorite Icon
		/// </summary>
		public static GUIContent DFavoriteIcon => _dfavoriteicon ??= EditorGUIUtility.IconContent("d_Favorite Icon");

		private static GUIContent _dfavoriteonicon;
		/// <summary>
		/// d_Favorite On Icon
		/// </summary>
		public static GUIContent DFavoriteOnIcon => _dfavoriteonicon ??= EditorGUIUtility.IconContent("d_Favorite On Icon");

		private static GUIContent _dfoldericon;
		/// <summary>
		/// d_Folder Icon
		/// </summary>
		public static GUIContent DFolderIcon => _dfoldericon ??= EditorGUIUtility.IconContent("d_Folder Icon");

		private static GUIContent _dfolderemptyicon;
		/// <summary>
		/// d_FolderEmpty Icon
		/// </summary>
		public static GUIContent DFolderemptyIcon => _dfolderemptyicon ??= EditorGUIUtility.IconContent("d_FolderEmpty Icon");

		private static GUIContent _dfolderemptyonicon;
		/// <summary>
		/// d_FolderEmpty On Icon
		/// </summary>
		public static GUIContent DFolderemptyOnIcon => _dfolderemptyonicon ??= EditorGUIUtility.IconContent("d_FolderEmpty On Icon");

		private static GUIContent _dfolderfavoriteicon;
		/// <summary>
		/// d_FolderFavorite Icon
		/// </summary>
		public static GUIContent DFolderfavoriteIcon => _dfolderfavoriteicon ??= EditorGUIUtility.IconContent("d_FolderFavorite Icon");

		private static GUIContent _dfolderfavoriteonicon;
		/// <summary>
		/// d_FolderFavorite On Icon
		/// </summary>
		public static GUIContent DFolderfavoriteOnIcon => _dfolderfavoriteonicon ??= EditorGUIUtility.IconContent("d_FolderFavorite On Icon");

		private static GUIContent _dfolderopenedicon;
		/// <summary>
		/// d_FolderOpened Icon
		/// </summary>
		public static GUIContent DFolderopenedIcon => _dfolderopenedicon ??= EditorGUIUtility.IconContent("d_FolderOpened Icon");

		private static GUIContent _dgridlayoutgroupicon;
		/// <summary>
		/// d_GridLayoutGroup Icon
		/// </summary>
		public static GUIContent DGridlayoutgroupIcon => _dgridlayoutgroupicon ??= EditorGUIUtility.IconContent("d_GridLayoutGroup Icon");

		private static GUIContent _dhorizontallayoutgroupicon;
		/// <summary>
		/// d_HorizontalLayoutGroup Icon
		/// </summary>
		public static GUIContent DHorizontallayoutgroupIcon => _dhorizontallayoutgroupicon ??= EditorGUIUtility.IconContent("d_HorizontalLayoutGroup Icon");

		private static GUIContent _djsscripticon;
		/// <summary>
		/// d_Js Script Icon
		/// </summary>
		public static GUIContent DJsScriptIcon => _djsscripticon ??= EditorGUIUtility.IconContent("d_Js Script Icon");

		private static GUIContent _dlightingdataassetparenticon;
		/// <summary>
		/// d_LightingDataAssetParent Icon
		/// </summary>
		public static GUIContent DLightingdataassetparentIcon => _dlightingdataassetparenticon ??= EditorGUIUtility.IconContent("d_LightingDataAssetParent Icon");

		private static GUIContent _dmicrophoneicon;
		/// <summary>
		/// d_Microphone Icon
		/// </summary>
		public static GUIContent DMicrophoneIcon => _dmicrophoneicon ??= EditorGUIUtility.IconContent("d_Microphone Icon");

		private static GUIContent _dprefabicon;
		/// <summary>
		/// d_Prefab Icon
		/// </summary>
		public static GUIContent DPrefabIcon => _dprefabicon ??= EditorGUIUtility.IconContent("d_Prefab Icon");

		private static GUIContent _dprefabonicon;
		/// <summary>
		/// d_Prefab On Icon
		/// </summary>
		public static GUIContent DPrefabOnIcon => _dprefabonicon ??= EditorGUIUtility.IconContent("d_Prefab On Icon");

		private static GUIContent _dprefabmodelicon;
		/// <summary>
		/// d_PrefabModel Icon
		/// </summary>
		public static GUIContent DPrefabmodelIcon => _dprefabmodelicon ??= EditorGUIUtility.IconContent("d_PrefabModel Icon");

		private static GUIContent _dprefabmodelonicon;
		/// <summary>
		/// d_PrefabModel On Icon
		/// </summary>
		public static GUIContent DPrefabmodelOnIcon => _dprefabmodelonicon ??= EditorGUIUtility.IconContent("d_PrefabModel On Icon");

		private static GUIContent _dprefabvarianticon;
		/// <summary>
		/// d_PrefabVariant Icon
		/// </summary>
		public static GUIContent DPrefabvariantIcon => _dprefabvarianticon ??= EditorGUIUtility.IconContent("d_PrefabVariant Icon");

		private static GUIContent _dprefabvariantonicon;
		/// <summary>
		/// d_PrefabVariant On Icon
		/// </summary>
		public static GUIContent DPrefabvariantOnIcon => _dprefabvariantonicon ??= EditorGUIUtility.IconContent("d_PrefabVariant On Icon");

		private static GUIContent _draycastcollidericon;
		/// <summary>
		/// d_RaycastCollider Icon
		/// </summary>
		public static GUIContent DRaycastcolliderIcon => _draycastcollidericon ??= EditorGUIUtility.IconContent("d_RaycastCollider Icon");

		private static GUIContent _dsearchicon;
		/// <summary>
		/// d_Search Icon
		/// </summary>
		public static GUIContent DSearchIcon => _dsearchicon ??= EditorGUIUtility.IconContent("d_Search Icon");

		private static GUIContent _dspotlighticon;
		/// <summary>
		/// d_Spotlight Icon
		/// </summary>
		public static GUIContent DSpotlightIcon => _dspotlighticon ??= EditorGUIUtility.IconContent("d_Spotlight Icon");

		private static GUIContent _dverticallayoutgroupicon;
		/// <summary>
		/// d_VerticalLayoutGroup Icon
		/// </summary>
		public static GUIContent DVerticallayoutgroupIcon => _dverticallayoutgroupicon ??= EditorGUIUtility.IconContent("d_VerticalLayoutGroup Icon");

		private static GUIContent _defaultslateicon;
		/// <summary>
		/// DefaultSlate Icon
		/// </summary>
		public static GUIContent DefaultslateIcon => _defaultslateicon ??= EditorGUIUtility.IconContent("DefaultSlate Icon");

		private static GUIContent _directionallightgizmo;
		/// <summary>
		/// DirectionalLight Gizmo
		/// </summary>
		public static GUIContent DirectionallightGizmo => _directionallightgizmo ??= EditorGUIUtility.IconContent("DirectionalLight Gizmo");

		private static GUIContent _directionallighticon;
		/// <summary>
		/// DirectionalLight Icon
		/// </summary>
		public static GUIContent DirectionallightIcon => _directionallighticon ??= EditorGUIUtility.IconContent("DirectionalLight Icon");

		private static GUIContent _disclighticon;
		/// <summary>
		/// DiscLight Icon
		/// </summary>
		public static GUIContent DisclightIcon => _disclighticon ??= EditorGUIUtility.IconContent("DiscLight Icon");

		private static GUIContent _dllscripticon;
		/// <summary>
		/// dll Script Icon
		/// </summary>
		public static GUIContent DllScriptIcon => _dllscripticon ??= EditorGUIUtility.IconContent("dll Script Icon");

		private static GUIContent _echofiltericon;
		/// <summary>
		/// EchoFilter Icon
		/// </summary>
		public static GUIContent EchofilterIcon => _echofiltericon ??= EditorGUIUtility.IconContent("EchoFilter Icon");

		private static GUIContent _favoriteicon;
		/// <summary>
		/// Favorite Icon
		/// </summary>
		public static GUIContent FavoriteIcon => _favoriteicon ??= EditorGUIUtility.IconContent("Favorite Icon");

		private static GUIContent _favoriteonicon;
		/// <summary>
		/// Favorite On Icon
		/// </summary>
		public static GUIContent FavoriteOnIcon => _favoriteonicon ??= EditorGUIUtility.IconContent("Favorite On Icon");

		private static GUIContent _foldericon;
		/// <summary>
		/// Folder Icon
		/// </summary>
		public static GUIContent FolderIcon => _foldericon ??= EditorGUIUtility.IconContent("Folder Icon");

		private static GUIContent _folderonicon;
		/// <summary>
		/// Folder On Icon
		/// </summary>
		public static GUIContent FolderOnIcon => _folderonicon ??= EditorGUIUtility.IconContent("Folder On Icon");

		private static GUIContent _folderemptyicon;
		/// <summary>
		/// FolderEmpty Icon
		/// </summary>
		public static GUIContent FolderemptyIcon => _folderemptyicon ??= EditorGUIUtility.IconContent("FolderEmpty Icon");

		private static GUIContent _folderemptyonicon;
		/// <summary>
		/// FolderEmpty On Icon
		/// </summary>
		public static GUIContent FolderemptyOnIcon => _folderemptyonicon ??= EditorGUIUtility.IconContent("FolderEmpty On Icon");

		private static GUIContent _folderfavoriteicon;
		/// <summary>
		/// FolderFavorite Icon
		/// </summary>
		public static GUIContent FolderfavoriteIcon => _folderfavoriteicon ??= EditorGUIUtility.IconContent("FolderFavorite Icon");

		private static GUIContent _folderfavoriteonicon;
		/// <summary>
		/// FolderFavorite On Icon
		/// </summary>
		public static GUIContent FolderfavoriteOnIcon => _folderfavoriteonicon ??= EditorGUIUtility.IconContent("FolderFavorite On Icon");

		private static GUIContent _folderopenedicon;
		/// <summary>
		/// FolderOpened Icon
		/// </summary>
		public static GUIContent FolderopenedIcon => _folderopenedicon ??= EditorGUIUtility.IconContent("FolderOpened Icon");

		private static GUIContent _folderopenedonicon;
		/// <summary>
		/// FolderOpened On Icon
		/// </summary>
		public static GUIContent FolderopenedOnIcon => _folderopenedonicon ??= EditorGUIUtility.IconContent("FolderOpened On Icon");

		private static GUIContent _gamemanagericon;
		/// <summary>
		/// GameManager Icon
		/// </summary>
		public static GUIContent GamemanagerIcon => _gamemanagericon ??= EditorGUIUtility.IconContent("GameManager Icon");

		private static GUIContent _gridbrushicon;
		/// <summary>
		/// GridBrush Icon
		/// </summary>
		public static GUIContent GridbrushIcon => _gridbrushicon ??= EditorGUIUtility.IconContent("GridBrush Icon");

		private static GUIContent _highpassfiltericon;
		/// <summary>
		/// HighPassFilter Icon
		/// </summary>
		public static GUIContent HighpassfilterIcon => _highpassfiltericon ??= EditorGUIUtility.IconContent("HighPassFilter Icon");

		private static GUIContent _horizontallayoutgroupicon;
		/// <summary>
		/// HorizontalLayoutGroup Icon
		/// </summary>
		public static GUIContent HorizontallayoutgroupIcon => _horizontallayoutgroupicon ??= EditorGUIUtility.IconContent("HorizontalLayoutGroup Icon");

		private static GUIContent _jsscripticon;
		/// <summary>
		/// Js Script Icon
		/// </summary>
		public static GUIContent JsScriptIcon => _jsscripticon ??= EditorGUIUtility.IconContent("Js Script Icon");

		private static GUIContent _lensflaregizmo;
		/// <summary>
		/// LensFlare Gizmo
		/// </summary>
		public static GUIContent LensflareGizmo => _lensflaregizmo ??= EditorGUIUtility.IconContent("LensFlare Gizmo");

		private static GUIContent _lightingdataassetparenticon;
		/// <summary>
		/// LightingDataAssetParent Icon
		/// </summary>
		public static GUIContent LightingdataassetparentIcon => _lightingdataassetparenticon ??= EditorGUIUtility.IconContent("LightingDataAssetParent Icon");

		private static GUIContent _lightprobegroupgizmo;
		/// <summary>
		/// LightProbeGroup Gizmo
		/// </summary>
		public static GUIContent LightprobegroupGizmo => _lightprobegroupgizmo ??= EditorGUIUtility.IconContent("LightProbeGroup Gizmo");

		private static GUIContent _lightprobeproxyvolumegizmo;
		/// <summary>
		/// LightProbeProxyVolume Gizmo
		/// </summary>
		public static GUIContent LightprobeproxyvolumeGizmo => _lightprobeproxyvolumegizmo ??= EditorGUIUtility.IconContent("LightProbeProxyVolume Gizmo");

		private static GUIContent _lowpassfiltericon;
		/// <summary>
		/// LowPassFilter Icon
		/// </summary>
		public static GUIContent LowpassfilterIcon => _lowpassfiltericon ??= EditorGUIUtility.IconContent("LowPassFilter Icon");

		private static GUIContent _mainlightgizmo;
		/// <summary>
		/// Main Light Gizmo
		/// </summary>
		public static GUIContent MainLightGizmo => _mainlightgizmo ??= EditorGUIUtility.IconContent("Main Light Gizmo");

		private static GUIContent _metafileicon;
		/// <summary>
		/// MetaFile Icon
		/// </summary>
		public static GUIContent MetafileIcon => _metafileicon ??= EditorGUIUtility.IconContent("MetaFile Icon");

		private static GUIContent _microphoneicon;
		/// <summary>
		/// Microphone Icon
		/// </summary>
		public static GUIContent MicrophoneIcon => _microphoneicon ??= EditorGUIUtility.IconContent("Microphone Icon");

		private static GUIContent _muscleclipicon;
		/// <summary>
		/// MuscleClip Icon
		/// </summary>
		public static GUIContent MuscleclipIcon => _muscleclipicon ??= EditorGUIUtility.IconContent("MuscleClip Icon");

		private static GUIContent _particlesystemgizmo;
		/// <summary>
		/// ParticleSystem Gizmo
		/// </summary>
		public static GUIContent ParticlesystemGizmo => _particlesystemgizmo ??= EditorGUIUtility.IconContent("ParticleSystem Gizmo");

		private static GUIContent _particlesystemforcefieldgizmo;
		/// <summary>
		/// ParticleSystemForceField Gizmo
		/// </summary>
		public static GUIContent ParticlesystemforcefieldGizmo => _particlesystemforcefieldgizmo ??= EditorGUIUtility.IconContent("ParticleSystemForceField Gizmo");

		private static GUIContent _pointlightgizmo;
		/// <summary>
		/// PointLight Gizmo
		/// </summary>
		public static GUIContent PointlightGizmo => _pointlightgizmo ??= EditorGUIUtility.IconContent("PointLight Gizmo");

		private static GUIContent _prefabicon;
		/// <summary>
		/// Prefab Icon
		/// </summary>
		public static GUIContent PrefabIcon => _prefabicon ??= EditorGUIUtility.IconContent("Prefab Icon");

		private static GUIContent _prefabonicon;
		/// <summary>
		/// Prefab On Icon
		/// </summary>
		public static GUIContent PrefabOnIcon => _prefabonicon ??= EditorGUIUtility.IconContent("Prefab On Icon");

		private static GUIContent _prefabmodelicon;
		/// <summary>
		/// PrefabModel Icon
		/// </summary>
		public static GUIContent PrefabmodelIcon => _prefabmodelicon ??= EditorGUIUtility.IconContent("PrefabModel Icon");

		private static GUIContent _prefabmodelonicon;
		/// <summary>
		/// PrefabModel On Icon
		/// </summary>
		public static GUIContent PrefabmodelOnIcon => _prefabmodelonicon ??= EditorGUIUtility.IconContent("PrefabModel On Icon");

		private static GUIContent _prefaboverlayaddedicon;
		/// <summary>
		/// PrefabOverlayAdded Icon
		/// </summary>
		public static GUIContent PrefaboverlayaddedIcon => _prefaboverlayaddedicon ??= EditorGUIUtility.IconContent("PrefabOverlayAdded Icon");

		private static GUIContent _prefaboverlaymodifiedicon;
		/// <summary>
		/// PrefabOverlayModified Icon
		/// </summary>
		public static GUIContent PrefaboverlaymodifiedIcon => _prefaboverlaymodifiedicon ??= EditorGUIUtility.IconContent("PrefabOverlayModified Icon");

		private static GUIContent _prefaboverlayremovedicon;
		/// <summary>
		/// PrefabOverlayRemoved Icon
		/// </summary>
		public static GUIContent PrefaboverlayremovedIcon => _prefaboverlayremovedicon ??= EditorGUIUtility.IconContent("PrefabOverlayRemoved Icon");

		private static GUIContent _prefabvarianticon;
		/// <summary>
		/// PrefabVariant Icon
		/// </summary>
		public static GUIContent PrefabvariantIcon => _prefabvarianticon ??= EditorGUIUtility.IconContent("PrefabVariant Icon");

		private static GUIContent _prefabvariantonicon;
		/// <summary>
		/// PrefabVariant On Icon
		/// </summary>
		public static GUIContent PrefabvariantOnIcon => _prefabvariantonicon ??= EditorGUIUtility.IconContent("PrefabVariant On Icon");

		private static GUIContent _projectorgizmo;
		/// <summary>
		/// Projector Gizmo
		/// </summary>
		public static GUIContent ProjectorGizmo => _projectorgizmo ??= EditorGUIUtility.IconContent("Projector Gizmo");

		private static GUIContent _raycastcollidericon;
		/// <summary>
		/// RaycastCollider Icon
		/// </summary>
		public static GUIContent RaycastcolliderIcon => _raycastcollidericon ??= EditorGUIUtility.IconContent("RaycastCollider Icon");

		private static GUIContent _reflectionprobegizmo;
		/// <summary>
		/// ReflectionProbe Gizmo
		/// </summary>
		public static GUIContent ReflectionprobeGizmo => _reflectionprobegizmo ??= EditorGUIUtility.IconContent("ReflectionProbe Gizmo");

		private static GUIContent _reverbfiltericon;
		/// <summary>
		/// ReverbFilter Icon
		/// </summary>
		public static GUIContent ReverbfilterIcon => _reverbfiltericon ??= EditorGUIUtility.IconContent("ReverbFilter Icon");

		private static GUIContent _sceneseticon;
		/// <summary>
		/// SceneSet Icon
		/// </summary>
		public static GUIContent ScenesetIcon => _sceneseticon ??= EditorGUIUtility.IconContent("SceneSet Icon");

		private static GUIContent _searchicon;
		/// <summary>
		/// Search Icon
		/// </summary>
		public static GUIContent SearchIcon => _searchicon ??= EditorGUIUtility.IconContent("Search Icon");

		private static GUIContent _searchonicon;
		/// <summary>
		/// Search On Icon
		/// </summary>
		public static GUIContent SearchOnIcon => _searchonicon ??= EditorGUIUtility.IconContent("Search On Icon");

		private static GUIContent _softlockprojectbrowsericon;
		/// <summary>
		/// SoftlockProjectBrowser Icon
		/// </summary>
		public static GUIContent SoftlockprojectbrowserIcon => _softlockprojectbrowsericon ??= EditorGUIUtility.IconContent("SoftlockProjectBrowser Icon");

		private static GUIContent _speedtreemodelicon;
		/// <summary>
		/// SpeedTreeModel Icon
		/// </summary>
		public static GUIContent SpeedtreemodelIcon => _speedtreemodelicon ??= EditorGUIUtility.IconContent("SpeedTreeModel Icon");

		private static GUIContent _spotlightgizmo;
		/// <summary>
		/// SpotLight Gizmo
		/// </summary>
		public static GUIContent SpotlightGizmo => _spotlightgizmo ??= EditorGUIUtility.IconContent("SpotLight Gizmo");

		private static GUIContent _spotlighticon;
		/// <summary>
		/// Spotlight Icon
		/// </summary>
		public static GUIContent SpotlightIcon => _spotlighticon ??= EditorGUIUtility.IconContent("Spotlight Icon");

		private static GUIContent _spritecollidericon;
		/// <summary>
		/// SpriteCollider Icon
		/// </summary>
		public static GUIContent SpritecolliderIcon => _spritecollidericon ??= EditorGUIUtility.IconContent("SpriteCollider Icon");

		private static GUIContent _svicondot0PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot0_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot0Pix16Gizmo => _svicondot0PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot0_pix16_gizmo");

		private static GUIContent _svicondot10PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot10_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot10Pix16Gizmo => _svicondot10PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot10_pix16_gizmo");

		private static GUIContent _svicondot11PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot11_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot11Pix16Gizmo => _svicondot11PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot11_pix16_gizmo");

		private static GUIContent _svicondot12PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot12_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot12Pix16Gizmo => _svicondot12PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot12_pix16_gizmo");

		private static GUIContent _svicondot13PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot13_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot13Pix16Gizmo => _svicondot13PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot13_pix16_gizmo");

		private static GUIContent _svicondot14PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot14_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot14Pix16Gizmo => _svicondot14PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot14_pix16_gizmo");

		private static GUIContent _svicondot15PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot15_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot15Pix16Gizmo => _svicondot15PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot15_pix16_gizmo");

		private static GUIContent _svicondot1PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot1_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot1Pix16Gizmo => _svicondot1PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot1_pix16_gizmo");

		private static GUIContent _svicondot2PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot2_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot2Pix16Gizmo => _svicondot2PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot2_pix16_gizmo");

		private static GUIContent _svicondot3PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot3_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot3Pix16Gizmo => _svicondot3PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot3_pix16_gizmo");

		private static GUIContent _svicondot4PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot4_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot4Pix16Gizmo => _svicondot4PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot4_pix16_gizmo");

		private static GUIContent _svicondot5PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot5_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot5Pix16Gizmo => _svicondot5PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot5_pix16_gizmo");

		private static GUIContent _svicondot6PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot6_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot6Pix16Gizmo => _svicondot6PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot6_pix16_gizmo");

		private static GUIContent _svicondot7PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot7_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot7Pix16Gizmo => _svicondot7PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot7_pix16_gizmo");

		private static GUIContent _svicondot8PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot8_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot8Pix16Gizmo => _svicondot8PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot8_pix16_gizmo");

		private static GUIContent _svicondot9PIX16Gizmo;
		/// <summary>
		/// sv_icon_dot9_pix16_gizmo
		/// </summary>
		public static GUIContent SvIconDot9Pix16Gizmo => _svicondot9PIX16Gizmo ??= EditorGUIUtility.IconContent("sv_icon_dot9_pix16_gizmo");

		private static GUIContent _animatorcontrollericon;
		/// <summary>
		/// AnimatorController Icon
		/// </summary>
		public static GUIContent AnimatorcontrollerIcon => _animatorcontrollericon ??= EditorGUIUtility.IconContent("AnimatorController Icon");

		private static GUIContent _animatorcontrolleronicon;
		/// <summary>
		/// AnimatorController On Icon
		/// </summary>
		public static GUIContent AnimatorcontrollerOnIcon => _animatorcontrolleronicon ??= EditorGUIUtility.IconContent("AnimatorController On Icon");

		private static GUIContent _animatorstateicon;
		/// <summary>
		/// AnimatorState Icon
		/// </summary>
		public static GUIContent AnimatorstateIcon => _animatorstateicon ??= EditorGUIUtility.IconContent("AnimatorState Icon");

		private static GUIContent _animatorstatemachineicon;
		/// <summary>
		/// AnimatorStateMachine Icon
		/// </summary>
		public static GUIContent AnimatorstatemachineIcon => _animatorstatemachineicon ??= EditorGUIUtility.IconContent("AnimatorStateMachine Icon");

		private static GUIContent _animatorstatetransitionicon;
		/// <summary>
		/// AnimatorStateTransition Icon
		/// </summary>
		public static GUIContent AnimatorstatetransitionIcon => _animatorstatetransitionicon ??= EditorGUIUtility.IconContent("AnimatorStateTransition Icon");

		private static GUIContent _blendtreeicon;
		/// <summary>
		/// BlendTree Icon
		/// </summary>
		public static GUIContent BlendtreeIcon => _blendtreeicon ??= EditorGUIUtility.IconContent("BlendTree Icon");

		private static GUIContent _danimatorcontrollericon;
		/// <summary>
		/// d_AnimatorController Icon
		/// </summary>
		public static GUIContent DAnimatorcontrollerIcon => _danimatorcontrollericon ??= EditorGUIUtility.IconContent("d_AnimatorController Icon");

		private static GUIContent _danimatorcontrolleronicon;
		/// <summary>
		/// d_AnimatorController On Icon
		/// </summary>
		public static GUIContent DAnimatorcontrollerOnIcon => _danimatorcontrolleronicon ??= EditorGUIUtility.IconContent("d_AnimatorController On Icon");

		private static GUIContent _danimatorstateicon;
		/// <summary>
		/// d_AnimatorState Icon
		/// </summary>
		public static GUIContent DAnimatorstateIcon => _danimatorstateicon ??= EditorGUIUtility.IconContent("d_AnimatorState Icon");

		private static GUIContent _danimatorstatemachineicon;
		/// <summary>
		/// d_AnimatorStateMachine Icon
		/// </summary>
		public static GUIContent DAnimatorstatemachineIcon => _danimatorstatemachineicon ??= EditorGUIUtility.IconContent("d_AnimatorStateMachine Icon");

		private static GUIContent _danimatorstatetransitionicon;
		/// <summary>
		/// d_AnimatorStateTransition Icon
		/// </summary>
		public static GUIContent DAnimatorstatetransitionIcon => _danimatorstatetransitionicon ??= EditorGUIUtility.IconContent("d_AnimatorStateTransition Icon");

		private static GUIContent _dblendtreeicon;
		/// <summary>
		/// d_BlendTree Icon
		/// </summary>
		public static GUIContent DBlendtreeIcon => _dblendtreeicon ??= EditorGUIUtility.IconContent("d_BlendTree Icon");

		private static GUIContent _animationwindoweventicon;
		/// <summary>
		/// AnimationWindowEvent Icon
		/// </summary>
		public static GUIContent AnimationwindoweventIcon => _animationwindoweventicon ??= EditorGUIUtility.IconContent("AnimationWindowEvent Icon");

		private static GUIContent _audiomixercontrollericon;
		/// <summary>
		/// AudioMixerController Icon
		/// </summary>
		public static GUIContent AudiomixercontrollerIcon => _audiomixercontrollericon ??= EditorGUIUtility.IconContent("AudioMixerController Icon");

		private static GUIContent _audiomixercontrolleronicon;
		/// <summary>
		/// AudioMixerController On Icon
		/// </summary>
		public static GUIContent AudiomixercontrollerOnIcon => _audiomixercontrolleronicon ??= EditorGUIUtility.IconContent("AudioMixerController On Icon");

		private static GUIContent _daudiomixercontrollericon;
		/// <summary>
		/// d_AudioMixerController Icon
		/// </summary>
		public static GUIContent DAudiomixercontrollerIcon => _daudiomixercontrollericon ??= EditorGUIUtility.IconContent("d_AudioMixerController Icon");

		private static GUIContent _daudiomixercontrolleronicon;
		/// <summary>
		/// d_AudioMixerController On Icon
		/// </summary>
		public static GUIContent DAudiomixercontrollerOnIcon => _daudiomixercontrolleronicon ??= EditorGUIUtility.IconContent("d_AudioMixerController On Icon");

		private static GUIContent _audioimportericon;
		/// <summary>
		/// AudioImporter Icon
		/// </summary>
		public static GUIContent AudioimporterIcon => _audioimportericon ??= EditorGUIUtility.IconContent("AudioImporter Icon");

		private static GUIContent _daudioimportericon;
		/// <summary>
		/// d_AudioImporter Icon
		/// </summary>
		public static GUIContent DAudioimporterIcon => _daudioimportericon ??= EditorGUIUtility.IconContent("d_AudioImporter Icon");

		private static GUIContent _ddefaultasseticon;
		/// <summary>
		/// d_DefaultAsset Icon
		/// </summary>
		public static GUIContent DDefaultassetIcon => _ddefaultasseticon ??= EditorGUIUtility.IconContent("d_DefaultAsset Icon");

		private static GUIContent _dihvimageformatimportericon;
		/// <summary>
		/// d_IHVImageFormatImporter Icon
		/// </summary>
		public static GUIContent DIhvimageformatimporterIcon => _dihvimageformatimportericon ??= EditorGUIUtility.IconContent("d_IHVImageFormatImporter Icon");

		private static GUIContent _dlightingdataasseticon;
		/// <summary>
		/// d_LightingDataAsset Icon
		/// </summary>
		public static GUIContent DLightingdataassetIcon => _dlightingdataasseticon ??= EditorGUIUtility.IconContent("d_LightingDataAsset Icon");

		private static GUIContent _dlightmapparametersicon;
		/// <summary>
		/// d_LightmapParameters Icon
		/// </summary>
		public static GUIContent DLightmapparametersIcon => _dlightmapparametersicon ??= EditorGUIUtility.IconContent("d_LightmapParameters Icon");

		private static GUIContent _dlightmapparametersonicon;
		/// <summary>
		/// d_LightmapParameters On Icon
		/// </summary>
		public static GUIContent DLightmapparametersOnIcon => _dlightmapparametersonicon ??= EditorGUIUtility.IconContent("d_LightmapParameters On Icon");

		private static GUIContent _dmodelimportericon;
		/// <summary>
		/// d_ModelImporter Icon
		/// </summary>
		public static GUIContent DModelimporterIcon => _dmodelimportericon ??= EditorGUIUtility.IconContent("d_ModelImporter Icon");

		private static GUIContent _dsceneasseticon;
		/// <summary>
		/// d_SceneAsset Icon
		/// </summary>
		public static GUIContent DSceneassetIcon => _dsceneasseticon ??= EditorGUIUtility.IconContent("d_SceneAsset Icon");

		private static GUIContent _dshaderimportericon;
		/// <summary>
		/// d_ShaderImporter Icon
		/// </summary>
		public static GUIContent DShaderimporterIcon => _dshaderimportericon ??= EditorGUIUtility.IconContent("d_ShaderImporter Icon");

		private static GUIContent _dtextscriptimportericon;
		/// <summary>
		/// d_TextScriptImporter Icon
		/// </summary>
		public static GUIContent DTextscriptimporterIcon => _dtextscriptimportericon ??= EditorGUIUtility.IconContent("d_TextScriptImporter Icon");

		private static GUIContent _dtextureimportericon;
		/// <summary>
		/// d_TextureImporter Icon
		/// </summary>
		public static GUIContent DTextureimporterIcon => _dtextureimportericon ??= EditorGUIUtility.IconContent("d_TextureImporter Icon");

		private static GUIContent _dtruetypefontimportericon;
		/// <summary>
		/// d_TrueTypeFontImporter Icon
		/// </summary>
		public static GUIContent DTruetypefontimporterIcon => _dtruetypefontimportericon ??= EditorGUIUtility.IconContent("d_TrueTypeFontImporter Icon");

		private static GUIContent _defaultasseticon;
		/// <summary>
		/// DefaultAsset Icon
		/// </summary>
		public static GUIContent DefaultassetIcon => _defaultasseticon ??= EditorGUIUtility.IconContent("DefaultAsset Icon");

		private static GUIContent _editorsettingsicon;
		/// <summary>
		/// EditorSettings Icon
		/// </summary>
		public static GUIContent EditorsettingsIcon => _editorsettingsicon ??= EditorGUIUtility.IconContent("EditorSettings Icon");

		private static GUIContent _anystatenodeicon;
		/// <summary>
		/// AnyStateNode Icon
		/// </summary>
		public static GUIContent AnystatenodeIcon => _anystatenodeicon ??= EditorGUIUtility.IconContent("AnyStateNode Icon");

		private static GUIContent _danystatenodeicon;
		/// <summary>
		/// d_AnyStateNode Icon
		/// </summary>
		public static GUIContent DAnystatenodeIcon => _danystatenodeicon ??= EditorGUIUtility.IconContent("d_AnyStateNode Icon");

		private static GUIContent _humantemplateicon;
		/// <summary>
		/// HumanTemplate Icon
		/// </summary>
		public static GUIContent HumantemplateIcon => _humantemplateicon ??= EditorGUIUtility.IconContent("HumanTemplate Icon");

		private static GUIContent _ihvimageformatimportericon;
		/// <summary>
		/// IHVImageFormatImporter Icon
		/// </summary>
		public static GUIContent IhvimageformatimporterIcon => _ihvimageformatimportericon ??= EditorGUIUtility.IconContent("IHVImageFormatImporter Icon");

		private static GUIContent _lightingdataasseticon;
		/// <summary>
		/// LightingDataAsset Icon
		/// </summary>
		public static GUIContent LightingdataassetIcon => _lightingdataasseticon ??= EditorGUIUtility.IconContent("LightingDataAsset Icon");

		private static GUIContent _lightmapparametersicon;
		/// <summary>
		/// LightmapParameters Icon
		/// </summary>
		public static GUIContent LightmapparametersIcon => _lightmapparametersicon ??= EditorGUIUtility.IconContent("LightmapParameters Icon");

		private static GUIContent _lightmapparametersonicon;
		/// <summary>
		/// LightmapParameters On Icon
		/// </summary>
		public static GUIContent LightmapparametersOnIcon => _lightmapparametersonicon ??= EditorGUIUtility.IconContent("LightmapParameters On Icon");

		private static GUIContent _modelimportericon;
		/// <summary>
		/// ModelImporter Icon
		/// </summary>
		public static GUIContent ModelimporterIcon => _modelimportericon ??= EditorGUIUtility.IconContent("ModelImporter Icon");

		private static GUIContent _preseticon;
		/// <summary>
		/// Preset Icon
		/// </summary>
		public static GUIContent PresetIcon => _preseticon ??= EditorGUIUtility.IconContent("Preset Icon");

		private static GUIContent _sceneasseticon;
		/// <summary>
		/// SceneAsset Icon
		/// </summary>
		public static GUIContent SceneassetIcon => _sceneasseticon ??= EditorGUIUtility.IconContent("SceneAsset Icon");

		private static GUIContent _sceneassetonicon;
		/// <summary>
		/// SceneAsset On Icon
		/// </summary>
		public static GUIContent SceneassetOnIcon => _sceneassetonicon ??= EditorGUIUtility.IconContent("SceneAsset On Icon");

		private static GUIContent _shaderimportericon;
		/// <summary>
		/// ShaderImporter Icon
		/// </summary>
		public static GUIContent ShaderimporterIcon => _shaderimportericon ??= EditorGUIUtility.IconContent("ShaderImporter Icon");

		private static GUIContent _speedtreeimportericon;
		/// <summary>
		/// SpeedTreeImporter Icon
		/// </summary>
		public static GUIContent SpeedtreeimporterIcon => _speedtreeimportericon ??= EditorGUIUtility.IconContent("SpeedTreeImporter Icon");

		private static GUIContent _substancearchiveicon;
		/// <summary>
		/// SubstanceArchive Icon
		/// </summary>
		public static GUIContent SubstancearchiveIcon => _substancearchiveicon ??= EditorGUIUtility.IconContent("SubstanceArchive Icon");

		private static GUIContent _textscriptimportericon;
		/// <summary>
		/// TextScriptImporter Icon
		/// </summary>
		public static GUIContent TextscriptimporterIcon => _textscriptimportericon ??= EditorGUIUtility.IconContent("TextScriptImporter Icon");

		private static GUIContent _textureimportericon;
		/// <summary>
		/// TextureImporter Icon
		/// </summary>
		public static GUIContent TextureimporterIcon => _textureimportericon ??= EditorGUIUtility.IconContent("TextureImporter Icon");

		private static GUIContent _truetypefontimportericon;
		/// <summary>
		/// TrueTypeFontImporter Icon
		/// </summary>
		public static GUIContent TruetypefontimporterIcon => _truetypefontimportericon ??= EditorGUIUtility.IconContent("TrueTypeFontImporter Icon");

		private static GUIContent _dspriteatlasasseticon;
		/// <summary>
		/// d_SpriteAtlasAsset Icon
		/// </summary>
		public static GUIContent DSpriteatlasassetIcon => _dspriteatlasasseticon ??= EditorGUIUtility.IconContent("d_SpriteAtlasAsset Icon");

		private static GUIContent _dspriteatlasimportericon;
		/// <summary>
		/// d_SpriteAtlasImporter Icon
		/// </summary>
		public static GUIContent DSpriteatlasimporterIcon => _dspriteatlasimportericon ??= EditorGUIUtility.IconContent("d_SpriteAtlasImporter Icon");

		private static GUIContent _spriteatlasasseticon;
		/// <summary>
		/// SpriteAtlasAsset Icon
		/// </summary>
		public static GUIContent SpriteatlasassetIcon => _spriteatlasasseticon ??= EditorGUIUtility.IconContent("SpriteAtlasAsset Icon");

		private static GUIContent _spriteatlasimportericon;
		/// <summary>
		/// SpriteAtlasImporter Icon
		/// </summary>
		public static GUIContent SpriteatlasimporterIcon => _spriteatlasimportericon ??= EditorGUIUtility.IconContent("SpriteAtlasImporter Icon");

		private static GUIContent _dvisualeffectsubgraphblockicon;
		/// <summary>
		/// d_VisualEffectSubgraphBlock Icon
		/// </summary>
		public static GUIContent DVisualeffectsubgraphblockIcon => _dvisualeffectsubgraphblockicon ??= EditorGUIUtility.IconContent("d_VisualEffectSubgraphBlock Icon");

		private static GUIContent _dvisualeffectsubgraphoperatoricon;
		/// <summary>
		/// d_VisualEffectSubgraphOperator Icon
		/// </summary>
		public static GUIContent DVisualeffectsubgraphoperatorIcon => _dvisualeffectsubgraphoperatoricon ??= EditorGUIUtility.IconContent("d_VisualEffectSubgraphOperator Icon");

		private static GUIContent _visualeffectsubgraphblockicon;
		/// <summary>
		/// VisualEffectSubgraphBlock Icon
		/// </summary>
		public static GUIContent VisualeffectsubgraphblockIcon => _visualeffectsubgraphblockicon ??= EditorGUIUtility.IconContent("VisualEffectSubgraphBlock Icon");

		private static GUIContent _visualeffectsubgraphoperatoricon;
		/// <summary>
		/// VisualEffectSubgraphOperator Icon
		/// </summary>
		public static GUIContent VisualeffectsubgraphoperatorIcon => _visualeffectsubgraphoperatoricon ??= EditorGUIUtility.IconContent("VisualEffectSubgraphOperator Icon");

		private static GUIContent _videoclipimportericon;
		/// <summary>
		/// VideoClipImporter Icon
		/// </summary>
		public static GUIContent VideoclipimporterIcon => _videoclipimportericon ??= EditorGUIUtility.IconContent("VideoClipImporter Icon");

		private static GUIContent _assemblydefinitionasseticon;
		/// <summary>
		/// AssemblyDefinitionAsset Icon
		/// </summary>
		public static GUIContent AssemblydefinitionassetIcon => _assemblydefinitionasseticon ??= EditorGUIUtility.IconContent("AssemblyDefinitionAsset Icon");

		private static GUIContent _assemblydefinitionreferenceasseticon;
		/// <summary>
		/// AssemblyDefinitionReferenceAsset Icon
		/// </summary>
		public static GUIContent AssemblydefinitionreferenceassetIcon => _assemblydefinitionreferenceasseticon ??= EditorGUIUtility.IconContent("AssemblyDefinitionReferenceAsset Icon");

		private static GUIContent _dassemblydefinitionasseticon;
		/// <summary>
		/// d_AssemblyDefinitionAsset Icon
		/// </summary>
		public static GUIContent DAssemblydefinitionassetIcon => _dassemblydefinitionasseticon ??= EditorGUIUtility.IconContent("d_AssemblyDefinitionAsset Icon");

		private static GUIContent _dassemblydefinitionreferenceasseticon;
		/// <summary>
		/// d_AssemblyDefinitionReferenceAsset Icon
		/// </summary>
		public static GUIContent DAssemblydefinitionreferenceassetIcon => _dassemblydefinitionreferenceasseticon ??= EditorGUIUtility.IconContent("d_AssemblyDefinitionReferenceAsset Icon");

		private static GUIContent _dnavmeshagenticon;
		/// <summary>
		/// d_NavMeshAgent Icon
		/// </summary>
		public static GUIContent DNavmeshagentIcon => _dnavmeshagenticon ??= EditorGUIUtility.IconContent("d_NavMeshAgent Icon");

		private static GUIContent _dnavmeshdataicon;
		/// <summary>
		/// d_NavMeshData Icon
		/// </summary>
		public static GUIContent DNavmeshdataIcon => _dnavmeshdataicon ??= EditorGUIUtility.IconContent("d_NavMeshData Icon");

		private static GUIContent _dnavmeshobstacleicon;
		/// <summary>
		/// d_NavMeshObstacle Icon
		/// </summary>
		public static GUIContent DNavmeshobstacleIcon => _dnavmeshobstacleicon ??= EditorGUIUtility.IconContent("d_NavMeshObstacle Icon");

		private static GUIContent _doffmeshlinkicon;
		/// <summary>
		/// d_OffMeshLink Icon
		/// </summary>
		public static GUIContent DOffmeshlinkIcon => _doffmeshlinkicon ??= EditorGUIUtility.IconContent("d_OffMeshLink Icon");

		private static GUIContent _navmeshagenticon;
		/// <summary>
		/// NavMeshAgent Icon
		/// </summary>
		public static GUIContent NavmeshagentIcon => _navmeshagenticon ??= EditorGUIUtility.IconContent("NavMeshAgent Icon");

		private static GUIContent _navmeshdataicon;
		/// <summary>
		/// NavMeshData Icon
		/// </summary>
		public static GUIContent NavmeshdataIcon => _navmeshdataicon ??= EditorGUIUtility.IconContent("NavMeshData Icon");

		private static GUIContent _navmeshobstacleicon;
		/// <summary>
		/// NavMeshObstacle Icon
		/// </summary>
		public static GUIContent NavmeshobstacleIcon => _navmeshobstacleicon ??= EditorGUIUtility.IconContent("NavMeshObstacle Icon");

		private static GUIContent _offmeshlinkicon;
		/// <summary>
		/// OffMeshLink Icon
		/// </summary>
		public static GUIContent OffmeshlinkIcon => _offmeshlinkicon ??= EditorGUIUtility.IconContent("OffMeshLink Icon");

		private static GUIContent _analyticstrackericon;
		/// <summary>
		/// AnalyticsTracker Icon
		/// </summary>
		public static GUIContent AnalyticstrackerIcon => _analyticstrackericon ??= EditorGUIUtility.IconContent("AnalyticsTracker Icon");

		private static GUIContent _danalyticstrackericon;
		/// <summary>
		/// d_AnalyticsTracker Icon
		/// </summary>
		public static GUIContent DAnalyticstrackerIcon => _danalyticstrackericon ??= EditorGUIUtility.IconContent("d_AnalyticsTracker Icon");

		private static GUIContent _animationicon;
		/// <summary>
		/// Animation Icon
		/// </summary>
		public static GUIContent AnimationIcon => _animationicon ??= EditorGUIUtility.IconContent("Animation Icon");

		private static GUIContent _animationclipicon;
		/// <summary>
		/// AnimationClip Icon
		/// </summary>
		public static GUIContent AnimationclipIcon => _animationclipicon ??= EditorGUIUtility.IconContent("AnimationClip Icon");

		private static GUIContent _animationcliponicon;
		/// <summary>
		/// AnimationClip On Icon
		/// </summary>
		public static GUIContent AnimationclipOnIcon => _animationcliponicon ??= EditorGUIUtility.IconContent("AnimationClip On Icon");

		private static GUIContent _aimconstrainticon;
		/// <summary>
		/// AimConstraint Icon
		/// </summary>
		public static GUIContent AimconstraintIcon => _aimconstrainticon ??= EditorGUIUtility.IconContent("AimConstraint Icon");

		private static GUIContent _daimconstrainticon;
		/// <summary>
		/// d_AimConstraint Icon
		/// </summary>
		public static GUIContent DAimconstraintIcon => _daimconstrainticon ??= EditorGUIUtility.IconContent("d_AimConstraint Icon");

		private static GUIContent _dlookatconstrainticon;
		/// <summary>
		/// d_LookAtConstraint Icon
		/// </summary>
		public static GUIContent DLookatconstraintIcon => _dlookatconstrainticon ??= EditorGUIUtility.IconContent("d_LookAtConstraint Icon");

		private static GUIContent _dparentconstrainticon;
		/// <summary>
		/// d_ParentConstraint Icon
		/// </summary>
		public static GUIContent DParentconstraintIcon => _dparentconstrainticon ??= EditorGUIUtility.IconContent("d_ParentConstraint Icon");

		private static GUIContent _dpositionconstrainticon;
		/// <summary>
		/// d_PositionConstraint Icon
		/// </summary>
		public static GUIContent DPositionconstraintIcon => _dpositionconstrainticon ??= EditorGUIUtility.IconContent("d_PositionConstraint Icon");

		private static GUIContent _drotationconstrainticon;
		/// <summary>
		/// d_RotationConstraint Icon
		/// </summary>
		public static GUIContent DRotationconstraintIcon => _drotationconstrainticon ??= EditorGUIUtility.IconContent("d_RotationConstraint Icon");

		private static GUIContent _dscaleconstrainticon;
		/// <summary>
		/// d_ScaleConstraint Icon
		/// </summary>
		public static GUIContent DScaleconstraintIcon => _dscaleconstrainticon ??= EditorGUIUtility.IconContent("d_ScaleConstraint Icon");

		private static GUIContent _lookatconstrainticon;
		/// <summary>
		/// LookAtConstraint Icon
		/// </summary>
		public static GUIContent LookatconstraintIcon => _lookatconstrainticon ??= EditorGUIUtility.IconContent("LookAtConstraint Icon");

		private static GUIContent _parentconstrainticon;
		/// <summary>
		/// ParentConstraint Icon
		/// </summary>
		public static GUIContent ParentconstraintIcon => _parentconstrainticon ??= EditorGUIUtility.IconContent("ParentConstraint Icon");

		private static GUIContent _positionconstrainticon;
		/// <summary>
		/// PositionConstraint Icon
		/// </summary>
		public static GUIContent PositionconstraintIcon => _positionconstrainticon ??= EditorGUIUtility.IconContent("PositionConstraint Icon");

		private static GUIContent _rotationconstrainticon;
		/// <summary>
		/// RotationConstraint Icon
		/// </summary>
		public static GUIContent RotationconstraintIcon => _rotationconstrainticon ??= EditorGUIUtility.IconContent("RotationConstraint Icon");

		private static GUIContent _scaleconstrainticon;
		/// <summary>
		/// ScaleConstraint Icon
		/// </summary>
		public static GUIContent ScaleconstraintIcon => _scaleconstrainticon ??= EditorGUIUtility.IconContent("ScaleConstraint Icon");

		private static GUIContent _animatoricon;
		/// <summary>
		/// Animator Icon
		/// </summary>
		public static GUIContent AnimatorIcon => _animatoricon ??= EditorGUIUtility.IconContent("Animator Icon");

		private static GUIContent _animatoroverridecontrollericon;
		/// <summary>
		/// AnimatorOverrideController Icon
		/// </summary>
		public static GUIContent AnimatoroverridecontrollerIcon => _animatoroverridecontrollericon ??= EditorGUIUtility.IconContent("AnimatorOverrideController Icon");

		private static GUIContent _animatoroverridecontrolleronicon;
		/// <summary>
		/// AnimatorOverrideController On Icon
		/// </summary>
		public static GUIContent AnimatoroverridecontrollerOnIcon => _animatoroverridecontrolleronicon ??= EditorGUIUtility.IconContent("AnimatorOverrideController On Icon");

		private static GUIContent _areaeffector2dicon;
		/// <summary>
		/// AreaEffector2D Icon
		/// </summary>
		public static GUIContent Areaeffector2dIcon => _areaeffector2dicon ??= EditorGUIUtility.IconContent("AreaEffector2D Icon");

		private static GUIContent _audiomixergroupicon;
		/// <summary>
		/// AudioMixerGroup Icon
		/// </summary>
		public static GUIContent AudiomixergroupIcon => _audiomixergroupicon ??= EditorGUIUtility.IconContent("AudioMixerGroup Icon");

		private static GUIContent _audiomixersnapshoticon;
		/// <summary>
		/// AudioMixerSnapshot Icon
		/// </summary>
		public static GUIContent AudiomixersnapshotIcon => _audiomixersnapshoticon ??= EditorGUIUtility.IconContent("AudioMixerSnapshot Icon");

		private static GUIContent _audiospatializermicrosofticon;
		/// <summary>
		/// AudioSpatializerMicrosoft Icon
		/// </summary>
		public static GUIContent AudiospatializermicrosoftIcon => _audiospatializermicrosofticon ??= EditorGUIUtility.IconContent("AudioSpatializerMicrosoft Icon");

		private static GUIContent _daudiomixergroupicon;
		/// <summary>
		/// d_AudioMixerGroup Icon
		/// </summary>
		public static GUIContent DAudiomixergroupIcon => _daudiomixergroupicon ??= EditorGUIUtility.IconContent("d_AudioMixerGroup Icon");

		private static GUIContent _daudiomixersnapshoticon;
		/// <summary>
		/// d_AudioMixerSnapshot Icon
		/// </summary>
		public static GUIContent DAudiomixersnapshotIcon => _daudiomixersnapshoticon ??= EditorGUIUtility.IconContent("d_AudioMixerSnapshot Icon");

		private static GUIContent _daudiospatializermicrosofticon;
		/// <summary>
		/// d_AudioSpatializerMicrosoft Icon
		/// </summary>
		public static GUIContent DAudiospatializermicrosoftIcon => _daudiospatializermicrosofticon ??= EditorGUIUtility.IconContent("d_AudioSpatializerMicrosoft Icon");

		private static GUIContent _audiochorusfiltericon;
		/// <summary>
		/// AudioChorusFilter Icon
		/// </summary>
		public static GUIContent AudiochorusfilterIcon => _audiochorusfiltericon ??= EditorGUIUtility.IconContent("AudioChorusFilter Icon");

		private static GUIContent _audioclipicon;
		/// <summary>
		/// AudioClip Icon
		/// </summary>
		public static GUIContent AudioclipIcon => _audioclipicon ??= EditorGUIUtility.IconContent("AudioClip Icon");

		private static GUIContent _audiocliponicon;
		/// <summary>
		/// AudioClip On Icon
		/// </summary>
		public static GUIContent AudioclipOnIcon => _audiocliponicon ??= EditorGUIUtility.IconContent("AudioClip On Icon");

		private static GUIContent _audiodistortionfiltericon;
		/// <summary>
		/// AudioDistortionFilter Icon
		/// </summary>
		public static GUIContent AudiodistortionfilterIcon => _audiodistortionfiltericon ??= EditorGUIUtility.IconContent("AudioDistortionFilter Icon");

		private static GUIContent _audioechofiltericon;
		/// <summary>
		/// AudioEchoFilter Icon
		/// </summary>
		public static GUIContent AudioechofilterIcon => _audioechofiltericon ??= EditorGUIUtility.IconContent("AudioEchoFilter Icon");

		private static GUIContent _audiohighpassfiltericon;
		/// <summary>
		/// AudioHighPassFilter Icon
		/// </summary>
		public static GUIContent AudiohighpassfilterIcon => _audiohighpassfiltericon ??= EditorGUIUtility.IconContent("AudioHighPassFilter Icon");

		private static GUIContent _audiolistenericon;
		/// <summary>
		/// AudioListener Icon
		/// </summary>
		public static GUIContent AudiolistenerIcon => _audiolistenericon ??= EditorGUIUtility.IconContent("AudioListener Icon");

		private static GUIContent _audiolowpassfiltericon;
		/// <summary>
		/// AudioLowPassFilter Icon
		/// </summary>
		public static GUIContent AudiolowpassfilterIcon => _audiolowpassfiltericon ??= EditorGUIUtility.IconContent("AudioLowPassFilter Icon");

		private static GUIContent _audioreverbfiltericon;
		/// <summary>
		/// AudioReverbFilter Icon
		/// </summary>
		public static GUIContent AudioreverbfilterIcon => _audioreverbfiltericon ??= EditorGUIUtility.IconContent("AudioReverbFilter Icon");

		private static GUIContent _audioreverbzoneicon;
		/// <summary>
		/// AudioReverbZone Icon
		/// </summary>
		public static GUIContent AudioreverbzoneIcon => _audioreverbzoneicon ??= EditorGUIUtility.IconContent("AudioReverbZone Icon");

		private static GUIContent _audiosourceicon;
		/// <summary>
		/// AudioSource Icon
		/// </summary>
		public static GUIContent AudiosourceIcon => _audiosourceicon ??= EditorGUIUtility.IconContent("AudioSource Icon");

		private static GUIContent _avataricon;
		/// <summary>
		/// Avatar Icon
		/// </summary>
		public static GUIContent AvatarIcon => _avataricon ??= EditorGUIUtility.IconContent("Avatar Icon");

		private static GUIContent _avatarmaskicon;
		/// <summary>
		/// AvatarMask Icon
		/// </summary>
		public static GUIContent AvatarmaskIcon => _avatarmaskicon ??= EditorGUIUtility.IconContent("AvatarMask Icon");

		private static GUIContent _avatarmaskonicon;
		/// <summary>
		/// AvatarMask On Icon
		/// </summary>
		public static GUIContent AvatarmaskOnIcon => _avatarmaskonicon ??= EditorGUIUtility.IconContent("AvatarMask On Icon");

		private static GUIContent _billboardasseticon;
		/// <summary>
		/// BillboardAsset Icon
		/// </summary>
		public static GUIContent BillboardassetIcon => _billboardasseticon ??= EditorGUIUtility.IconContent("BillboardAsset Icon");

		private static GUIContent _billboardrenderericon;
		/// <summary>
		/// BillboardRenderer Icon
		/// </summary>
		public static GUIContent BillboardrendererIcon => _billboardrenderericon ??= EditorGUIUtility.IconContent("BillboardRenderer Icon");

		private static GUIContent _boxcollidericon;
		/// <summary>
		/// BoxCollider Icon
		/// </summary>
		public static GUIContent BoxcolliderIcon => _boxcollidericon ??= EditorGUIUtility.IconContent("BoxCollider Icon");

		private static GUIContent _boxcollider2dicon;
		/// <summary>
		/// BoxCollider2D Icon
		/// </summary>
		public static GUIContent Boxcollider2dIcon => _boxcollider2dicon ??= EditorGUIUtility.IconContent("BoxCollider2D Icon");

		private static GUIContent _buoyancyeffector2dicon;
		/// <summary>
		/// BuoyancyEffector2D Icon
		/// </summary>
		public static GUIContent Buoyancyeffector2dIcon => _buoyancyeffector2dicon ??= EditorGUIUtility.IconContent("BuoyancyEffector2D Icon");

		private static GUIContent _cameraicon;
		/// <summary>
		/// Camera Icon
		/// </summary>
		public static GUIContent CameraIcon => _cameraicon ??= EditorGUIUtility.IconContent("Camera Icon");

		private static GUIContent _canvasicon;
		/// <summary>
		/// Canvas Icon
		/// </summary>
		public static GUIContent CanvasIcon => _canvasicon ??= EditorGUIUtility.IconContent("Canvas Icon");

		private static GUIContent _canvasgroupicon;
		/// <summary>
		/// CanvasGroup Icon
		/// </summary>
		public static GUIContent CanvasgroupIcon => _canvasgroupicon ??= EditorGUIUtility.IconContent("CanvasGroup Icon");

		private static GUIContent _canvasrenderericon;
		/// <summary>
		/// CanvasRenderer Icon
		/// </summary>
		public static GUIContent CanvasrendererIcon => _canvasrenderericon ??= EditorGUIUtility.IconContent("CanvasRenderer Icon");

		private static GUIContent _capsulecollidericon;
		/// <summary>
		/// CapsuleCollider Icon
		/// </summary>
		public static GUIContent CapsulecolliderIcon => _capsulecollidericon ??= EditorGUIUtility.IconContent("CapsuleCollider Icon");

		private static GUIContent _capsulecollider2dicon;
		/// <summary>
		/// CapsuleCollider2D Icon
		/// </summary>
		public static GUIContent Capsulecollider2dIcon => _capsulecollider2dicon ??= EditorGUIUtility.IconContent("CapsuleCollider2D Icon");

		private static GUIContent _charactercontrollericon;
		/// <summary>
		/// CharacterController Icon
		/// </summary>
		public static GUIContent CharactercontrollerIcon => _charactercontrollericon ??= EditorGUIUtility.IconContent("CharacterController Icon");

		private static GUIContent _characterjointicon;
		/// <summary>
		/// CharacterJoint Icon
		/// </summary>
		public static GUIContent CharacterjointIcon => _characterjointicon ??= EditorGUIUtility.IconContent("CharacterJoint Icon");

		private static GUIContent _circlecollider2dicon;
		/// <summary>
		/// CircleCollider2D Icon
		/// </summary>
		public static GUIContent Circlecollider2dIcon => _circlecollider2dicon ??= EditorGUIUtility.IconContent("CircleCollider2D Icon");

		private static GUIContent _clothicon;
		/// <summary>
		/// Cloth Icon
		/// </summary>
		public static GUIContent ClothIcon => _clothicon ??= EditorGUIUtility.IconContent("Cloth Icon");

		private static GUIContent _compositecollider2dicon;
		/// <summary>
		/// CompositeCollider2D Icon
		/// </summary>
		public static GUIContent Compositecollider2dIcon => _compositecollider2dicon ??= EditorGUIUtility.IconContent("CompositeCollider2D Icon");

		private static GUIContent _computeshadericon;
		/// <summary>
		/// ComputeShader Icon
		/// </summary>
		public static GUIContent ComputeshaderIcon => _computeshadericon ??= EditorGUIUtility.IconContent("ComputeShader Icon");

		private static GUIContent _configurablejointicon;
		/// <summary>
		/// ConfigurableJoint Icon
		/// </summary>
		public static GUIContent ConfigurablejointIcon => _configurablejointicon ??= EditorGUIUtility.IconContent("ConfigurableJoint Icon");

		private static GUIContent _constantforceicon;
		/// <summary>
		/// ConstantForce Icon
		/// </summary>
		public static GUIContent ConstantforceIcon => _constantforceicon ??= EditorGUIUtility.IconContent("ConstantForce Icon");

		private static GUIContent _constantforce2dicon;
		/// <summary>
		/// ConstantForce2D Icon
		/// </summary>
		public static GUIContent Constantforce2dIcon => _constantforce2dicon ??= EditorGUIUtility.IconContent("ConstantForce2D Icon");

		private static GUIContent _cubemapicon;
		/// <summary>
		/// Cubemap Icon
		/// </summary>
		public static GUIContent CubemapIcon => _cubemapicon ??= EditorGUIUtility.IconContent("Cubemap Icon");

		private static GUIContent _danimationicon;
		/// <summary>
		/// d_Animation Icon
		/// </summary>
		public static GUIContent DAnimationIcon => _danimationicon ??= EditorGUIUtility.IconContent("d_Animation Icon");

		private static GUIContent _danimationclipicon;
		/// <summary>
		/// d_AnimationClip Icon
		/// </summary>
		public static GUIContent DAnimationclipIcon => _danimationclipicon ??= EditorGUIUtility.IconContent("d_AnimationClip Icon");

		private static GUIContent _danimationcliponicon;
		/// <summary>
		/// d_AnimationClip On Icon
		/// </summary>
		public static GUIContent DAnimationclipOnIcon => _danimationcliponicon ??= EditorGUIUtility.IconContent("d_AnimationClip On Icon");

		private static GUIContent _danimatoricon;
		/// <summary>
		/// d_Animator Icon
		/// </summary>
		public static GUIContent DAnimatorIcon => _danimatoricon ??= EditorGUIUtility.IconContent("d_Animator Icon");

		private static GUIContent _danimatoroverridecontrollericon;
		/// <summary>
		/// d_AnimatorOverrideController Icon
		/// </summary>
		public static GUIContent DAnimatoroverridecontrollerIcon => _danimatoroverridecontrollericon ??= EditorGUIUtility.IconContent("d_AnimatorOverrideController Icon");

		private static GUIContent _danimatoroverridecontrolleronicon;
		/// <summary>
		/// d_AnimatorOverrideController On Icon
		/// </summary>
		public static GUIContent DAnimatoroverridecontrollerOnIcon => _danimatoroverridecontrolleronicon ??= EditorGUIUtility.IconContent("d_AnimatorOverrideController On Icon");

		private static GUIContent _dareaeffector2dicon;
		/// <summary>
		/// d_AreaEffector2D Icon
		/// </summary>
		public static GUIContent DAreaeffector2dIcon => _dareaeffector2dicon ??= EditorGUIUtility.IconContent("d_AreaEffector2D Icon");

		private static GUIContent _daudiochorusfiltericon;
		/// <summary>
		/// d_AudioChorusFilter Icon
		/// </summary>
		public static GUIContent DAudiochorusfilterIcon => _daudiochorusfiltericon ??= EditorGUIUtility.IconContent("d_AudioChorusFilter Icon");

		private static GUIContent _daudioclipicon;
		/// <summary>
		/// d_AudioClip Icon
		/// </summary>
		public static GUIContent DAudioclipIcon => _daudioclipicon ??= EditorGUIUtility.IconContent("d_AudioClip Icon");

		private static GUIContent _daudiocliponicon;
		/// <summary>
		/// d_AudioClip On Icon
		/// </summary>
		public static GUIContent DAudioclipOnIcon => _daudiocliponicon ??= EditorGUIUtility.IconContent("d_AudioClip On Icon");

		private static GUIContent _daudiodistortionfiltericon;
		/// <summary>
		/// d_AudioDistortionFilter Icon
		/// </summary>
		public static GUIContent DAudiodistortionfilterIcon => _daudiodistortionfiltericon ??= EditorGUIUtility.IconContent("d_AudioDistortionFilter Icon");

		private static GUIContent _daudioechofiltericon;
		/// <summary>
		/// d_AudioEchoFilter Icon
		/// </summary>
		public static GUIContent DAudioechofilterIcon => _daudioechofiltericon ??= EditorGUIUtility.IconContent("d_AudioEchoFilter Icon");

		private static GUIContent _daudiohighpassfiltericon;
		/// <summary>
		/// d_AudioHighPassFilter Icon
		/// </summary>
		public static GUIContent DAudiohighpassfilterIcon => _daudiohighpassfiltericon ??= EditorGUIUtility.IconContent("d_AudioHighPassFilter Icon");

		private static GUIContent _daudiolistenericon;
		/// <summary>
		/// d_AudioListener Icon
		/// </summary>
		public static GUIContent DAudiolistenerIcon => _daudiolistenericon ??= EditorGUIUtility.IconContent("d_AudioListener Icon");

		private static GUIContent _daudiolowpassfiltericon;
		/// <summary>
		/// d_AudioLowPassFilter Icon
		/// </summary>
		public static GUIContent DAudiolowpassfilterIcon => _daudiolowpassfiltericon ??= EditorGUIUtility.IconContent("d_AudioLowPassFilter Icon");

		private static GUIContent _daudioreverbfiltericon;
		/// <summary>
		/// d_AudioReverbFilter Icon
		/// </summary>
		public static GUIContent DAudioreverbfilterIcon => _daudioreverbfiltericon ??= EditorGUIUtility.IconContent("d_AudioReverbFilter Icon");

		private static GUIContent _daudioreverbzoneicon;
		/// <summary>
		/// d_AudioReverbZone Icon
		/// </summary>
		public static GUIContent DAudioreverbzoneIcon => _daudioreverbzoneicon ??= EditorGUIUtility.IconContent("d_AudioReverbZone Icon");

		private static GUIContent _daudiosourceicon;
		/// <summary>
		/// d_AudioSource Icon
		/// </summary>
		public static GUIContent DAudiosourceIcon => _daudiosourceicon ??= EditorGUIUtility.IconContent("d_AudioSource Icon");

		private static GUIContent _davataricon;
		/// <summary>
		/// d_Avatar Icon
		/// </summary>
		public static GUIContent DAvatarIcon => _davataricon ??= EditorGUIUtility.IconContent("d_Avatar Icon");

		private static GUIContent _davatarmaskicon;
		/// <summary>
		/// d_AvatarMask Icon
		/// </summary>
		public static GUIContent DAvatarmaskIcon => _davatarmaskicon ??= EditorGUIUtility.IconContent("d_AvatarMask Icon");

		private static GUIContent _davatarmaskonicon;
		/// <summary>
		/// d_AvatarMask On Icon
		/// </summary>
		public static GUIContent DAvatarmaskOnIcon => _davatarmaskonicon ??= EditorGUIUtility.IconContent("d_AvatarMask On Icon");

		private static GUIContent _dbillboardasseticon;
		/// <summary>
		/// d_BillboardAsset Icon
		/// </summary>
		public static GUIContent DBillboardassetIcon => _dbillboardasseticon ??= EditorGUIUtility.IconContent("d_BillboardAsset Icon");

		private static GUIContent _dbillboardrenderericon;
		/// <summary>
		/// d_BillboardRenderer Icon
		/// </summary>
		public static GUIContent DBillboardrendererIcon => _dbillboardrenderericon ??= EditorGUIUtility.IconContent("d_BillboardRenderer Icon");

		private static GUIContent _dboxcollidericon;
		/// <summary>
		/// d_BoxCollider Icon
		/// </summary>
		public static GUIContent DBoxcolliderIcon => _dboxcollidericon ??= EditorGUIUtility.IconContent("d_BoxCollider Icon");

		private static GUIContent _dboxcollider2dicon;
		/// <summary>
		/// d_BoxCollider2D Icon
		/// </summary>
		public static GUIContent DBoxcollider2dIcon => _dboxcollider2dicon ??= EditorGUIUtility.IconContent("d_BoxCollider2D Icon");

		private static GUIContent _dbuoyancyeffector2dicon;
		/// <summary>
		/// d_BuoyancyEffector2D Icon
		/// </summary>
		public static GUIContent DBuoyancyeffector2dIcon => _dbuoyancyeffector2dicon ??= EditorGUIUtility.IconContent("d_BuoyancyEffector2D Icon");

		private static GUIContent _dcameraicon;
		/// <summary>
		/// d_Camera Icon
		/// </summary>
		public static GUIContent DCameraIcon => _dcameraicon ??= EditorGUIUtility.IconContent("d_Camera Icon");

		private static GUIContent _dcanvasicon;
		/// <summary>
		/// d_Canvas Icon
		/// </summary>
		public static GUIContent DCanvasIcon => _dcanvasicon ??= EditorGUIUtility.IconContent("d_Canvas Icon");

		private static GUIContent _dcanvasgroupicon;
		/// <summary>
		/// d_CanvasGroup Icon
		/// </summary>
		public static GUIContent DCanvasgroupIcon => _dcanvasgroupicon ??= EditorGUIUtility.IconContent("d_CanvasGroup Icon");

		private static GUIContent _dcanvasrenderericon;
		/// <summary>
		/// d_CanvasRenderer Icon
		/// </summary>
		public static GUIContent DCanvasrendererIcon => _dcanvasrenderericon ??= EditorGUIUtility.IconContent("d_CanvasRenderer Icon");

		private static GUIContent _dcapsulecollidericon;
		/// <summary>
		/// d_CapsuleCollider Icon
		/// </summary>
		public static GUIContent DCapsulecolliderIcon => _dcapsulecollidericon ??= EditorGUIUtility.IconContent("d_CapsuleCollider Icon");

		private static GUIContent _dcapsulecollider2dicon;
		/// <summary>
		/// d_CapsuleCollider2D Icon
		/// </summary>
		public static GUIContent DCapsulecollider2dIcon => _dcapsulecollider2dicon ??= EditorGUIUtility.IconContent("d_CapsuleCollider2D Icon");

		private static GUIContent _dcharactercontrollericon;
		/// <summary>
		/// d_CharacterController Icon
		/// </summary>
		public static GUIContent DCharactercontrollerIcon => _dcharactercontrollericon ??= EditorGUIUtility.IconContent("d_CharacterController Icon");

		private static GUIContent _dcharacterjointicon;
		/// <summary>
		/// d_CharacterJoint Icon
		/// </summary>
		public static GUIContent DCharacterjointIcon => _dcharacterjointicon ??= EditorGUIUtility.IconContent("d_CharacterJoint Icon");

		private static GUIContent _dcirclecollider2dicon;
		/// <summary>
		/// d_CircleCollider2D Icon
		/// </summary>
		public static GUIContent DCirclecollider2dIcon => _dcirclecollider2dicon ??= EditorGUIUtility.IconContent("d_CircleCollider2D Icon");

		private static GUIContent _dclothicon;
		/// <summary>
		/// d_Cloth Icon
		/// </summary>
		public static GUIContent DClothIcon => _dclothicon ??= EditorGUIUtility.IconContent("d_Cloth Icon");

		private static GUIContent _dcompositecollider2dicon;
		/// <summary>
		/// d_CompositeCollider2D Icon
		/// </summary>
		public static GUIContent DCompositecollider2dIcon => _dcompositecollider2dicon ??= EditorGUIUtility.IconContent("d_CompositeCollider2D Icon");

		private static GUIContent _dcomputeshadericon;
		/// <summary>
		/// d_ComputeShader Icon
		/// </summary>
		public static GUIContent DComputeshaderIcon => _dcomputeshadericon ??= EditorGUIUtility.IconContent("d_ComputeShader Icon");

		private static GUIContent _dconfigurablejointicon;
		/// <summary>
		/// d_ConfigurableJoint Icon
		/// </summary>
		public static GUIContent DConfigurablejointIcon => _dconfigurablejointicon ??= EditorGUIUtility.IconContent("d_ConfigurableJoint Icon");

		private static GUIContent _dconstantforceicon;
		/// <summary>
		/// d_ConstantForce Icon
		/// </summary>
		public static GUIContent DConstantforceIcon => _dconstantforceicon ??= EditorGUIUtility.IconContent("d_ConstantForce Icon");

		private static GUIContent _dconstantforce2dicon;
		/// <summary>
		/// d_ConstantForce2D Icon
		/// </summary>
		public static GUIContent DConstantforce2dIcon => _dconstantforce2dicon ??= EditorGUIUtility.IconContent("d_ConstantForce2D Icon");

		private static GUIContent _dcubemapicon;
		/// <summary>
		/// d_Cubemap Icon
		/// </summary>
		public static GUIContent DCubemapIcon => _dcubemapicon ??= EditorGUIUtility.IconContent("d_Cubemap Icon");

		private static GUIContent _ddistancejoint2dicon;
		/// <summary>
		/// d_DistanceJoint2D Icon
		/// </summary>
		public static GUIContent DDistancejoint2dIcon => _ddistancejoint2dicon ??= EditorGUIUtility.IconContent("d_DistanceJoint2D Icon");

		private static GUIContent _dedgecollider2dicon;
		/// <summary>
		/// d_EdgeCollider2D Icon
		/// </summary>
		public static GUIContent DEdgecollider2dIcon => _dedgecollider2dicon ??= EditorGUIUtility.IconContent("d_EdgeCollider2D Icon");

		private static GUIContent _dfixedjointicon;
		/// <summary>
		/// d_FixedJoint Icon
		/// </summary>
		public static GUIContent DFixedjointIcon => _dfixedjointicon ??= EditorGUIUtility.IconContent("d_FixedJoint Icon");

		private static GUIContent _dflareicon;
		/// <summary>
		/// d_Flare Icon
		/// </summary>
		public static GUIContent DFlareIcon => _dflareicon ??= EditorGUIUtility.IconContent("d_Flare Icon");

		private static GUIContent _dflareonicon;
		/// <summary>
		/// d_Flare On Icon
		/// </summary>
		public static GUIContent DFlareOnIcon => _dflareonicon ??= EditorGUIUtility.IconContent("d_Flare On Icon");

		private static GUIContent _dflarelayericon;
		/// <summary>
		/// d_FlareLayer Icon
		/// </summary>
		public static GUIContent DFlarelayerIcon => _dflarelayericon ??= EditorGUIUtility.IconContent("d_FlareLayer Icon");

		private static GUIContent _dfonticon;
		/// <summary>
		/// d_Font Icon
		/// </summary>
		public static GUIContent DFontIcon => _dfonticon ??= EditorGUIUtility.IconContent("d_Font Icon");

		private static GUIContent _dfrictionjoint2dicon;
		/// <summary>
		/// d_FrictionJoint2D Icon
		/// </summary>
		public static GUIContent DFrictionjoint2dIcon => _dfrictionjoint2dicon ??= EditorGUIUtility.IconContent("d_FrictionJoint2D Icon");

		private static GUIContent _dgameobjecticon;
		/// <summary>
		/// d_GameObject Icon
		/// </summary>
		public static GUIContent DGameobjectIcon => _dgameobjecticon ??= EditorGUIUtility.IconContent("d_GameObject Icon");

		private static GUIContent _dgridicon;
		/// <summary>
		/// d_Grid Icon
		/// </summary>
		public static GUIContent DGridIcon => _dgridicon ??= EditorGUIUtility.IconContent("d_Grid Icon");

		private static GUIContent _dguiskinicon;
		/// <summary>
		/// d_GUISkin Icon
		/// </summary>
		public static GUIContent DGuiskinIcon => _dguiskinicon ??= EditorGUIUtility.IconContent("d_GUISkin Icon");

		private static GUIContent _dguiskinonicon;
		/// <summary>
		/// d_GUISkin On Icon
		/// </summary>
		public static GUIContent DGuiskinOnIcon => _dguiskinonicon ??= EditorGUIUtility.IconContent("d_GUISkin On Icon");

		private static GUIContent _dhaloicon;
		/// <summary>
		/// d_Halo Icon
		/// </summary>
		public static GUIContent DHaloIcon => _dhaloicon ??= EditorGUIUtility.IconContent("d_Halo Icon");

		private static GUIContent _dhingejointicon;
		/// <summary>
		/// d_HingeJoint Icon
		/// </summary>
		public static GUIContent DHingejointIcon => _dhingejointicon ??= EditorGUIUtility.IconContent("d_HingeJoint Icon");

		private static GUIContent _dhingejoint2dicon;
		/// <summary>
		/// d_HingeJoint2D Icon
		/// </summary>
		public static GUIContent DHingejoint2dIcon => _dhingejoint2dicon ??= EditorGUIUtility.IconContent("d_HingeJoint2D Icon");

		private static GUIContent _dlighticon;
		/// <summary>
		/// d_Light Icon
		/// </summary>
		public static GUIContent DLightIcon => _dlighticon ??= EditorGUIUtility.IconContent("d_Light Icon");

		private static GUIContent _dlightingsettingsicon;
		/// <summary>
		/// d_LightingSettings Icon
		/// </summary>
		public static GUIContent DLightingsettingsIcon => _dlightingsettingsicon ??= EditorGUIUtility.IconContent("d_LightingSettings Icon");

		private static GUIContent _dlightprobegroupicon;
		/// <summary>
		/// d_LightProbeGroup Icon
		/// </summary>
		public static GUIContent DLightprobegroupIcon => _dlightprobegroupicon ??= EditorGUIUtility.IconContent("d_LightProbeGroup Icon");

		private static GUIContent _dlightprobeproxyvolumeicon;
		/// <summary>
		/// d_LightProbeProxyVolume Icon
		/// </summary>
		public static GUIContent DLightprobeproxyvolumeIcon => _dlightprobeproxyvolumeicon ??= EditorGUIUtility.IconContent("d_LightProbeProxyVolume Icon");

		private static GUIContent _dlightprobesicon;
		/// <summary>
		/// d_LightProbes Icon
		/// </summary>
		public static GUIContent DLightprobesIcon => _dlightprobesicon ??= EditorGUIUtility.IconContent("d_LightProbes Icon");

		private static GUIContent _dlinerenderericon;
		/// <summary>
		/// d_LineRenderer Icon
		/// </summary>
		public static GUIContent DLinerendererIcon => _dlinerenderericon ??= EditorGUIUtility.IconContent("d_LineRenderer Icon");

		private static GUIContent _dlodgroupicon;
		/// <summary>
		/// d_LODGroup Icon
		/// </summary>
		public static GUIContent DLodgroupIcon => _dlodgroupicon ??= EditorGUIUtility.IconContent("d_LODGroup Icon");

		private static GUIContent _dmaterialicon;
		/// <summary>
		/// d_Material Icon
		/// </summary>
		public static GUIContent DMaterialIcon => _dmaterialicon ??= EditorGUIUtility.IconContent("d_Material Icon");

		private static GUIContent _dmaterialonicon;
		/// <summary>
		/// d_Material On Icon
		/// </summary>
		public static GUIContent DMaterialOnIcon => _dmaterialonicon ??= EditorGUIUtility.IconContent("d_Material On Icon");

		private static GUIContent _dmeshicon;
		/// <summary>
		/// d_Mesh Icon
		/// </summary>
		public static GUIContent DMeshIcon => _dmeshicon ??= EditorGUIUtility.IconContent("d_Mesh Icon");

		private static GUIContent _dmeshcollidericon;
		/// <summary>
		/// d_MeshCollider Icon
		/// </summary>
		public static GUIContent DMeshcolliderIcon => _dmeshcollidericon ??= EditorGUIUtility.IconContent("d_MeshCollider Icon");

		private static GUIContent _dmeshfiltericon;
		/// <summary>
		/// d_MeshFilter Icon
		/// </summary>
		public static GUIContent DMeshfilterIcon => _dmeshfiltericon ??= EditorGUIUtility.IconContent("d_MeshFilter Icon");

		private static GUIContent _dmeshrenderericon;
		/// <summary>
		/// d_MeshRenderer Icon
		/// </summary>
		public static GUIContent DMeshrendererIcon => _dmeshrenderericon ??= EditorGUIUtility.IconContent("d_MeshRenderer Icon");

		private static GUIContent _dmotionicon;
		/// <summary>
		/// d_Motion Icon
		/// </summary>
		public static GUIContent DMotionIcon => _dmotionicon ??= EditorGUIUtility.IconContent("d_Motion Icon");

		private static GUIContent _docclusionareaicon;
		/// <summary>
		/// d_OcclusionArea Icon
		/// </summary>
		public static GUIContent DOcclusionareaIcon => _docclusionareaicon ??= EditorGUIUtility.IconContent("d_OcclusionArea Icon");

		private static GUIContent _docclusionportalicon;
		/// <summary>
		/// d_OcclusionPortal Icon
		/// </summary>
		public static GUIContent DOcclusionportalIcon => _docclusionportalicon ??= EditorGUIUtility.IconContent("d_OcclusionPortal Icon");

		private static GUIContent _dparticlesystemicon;
		/// <summary>
		/// d_ParticleSystem Icon
		/// </summary>
		public static GUIContent DParticlesystemIcon => _dparticlesystemicon ??= EditorGUIUtility.IconContent("d_ParticleSystem Icon");

		private static GUIContent _dparticlesystemforcefieldicon;
		/// <summary>
		/// d_ParticleSystemForceField Icon
		/// </summary>
		public static GUIContent DParticlesystemforcefieldIcon => _dparticlesystemforcefieldicon ??= EditorGUIUtility.IconContent("d_ParticleSystemForceField Icon");

		private static GUIContent _dphysicmaterialicon;
		/// <summary>
		/// d_PhysicMaterial Icon
		/// </summary>
		public static GUIContent DPhysicmaterialIcon => _dphysicmaterialicon ??= EditorGUIUtility.IconContent("d_PhysicMaterial Icon");

		private static GUIContent _dphysicmaterialonicon;
		/// <summary>
		/// d_PhysicMaterial On Icon
		/// </summary>
		public static GUIContent DPhysicmaterialOnIcon => _dphysicmaterialonicon ??= EditorGUIUtility.IconContent("d_PhysicMaterial On Icon");

		private static GUIContent _dphysicsmaterial2dicon;
		/// <summary>
		/// d_PhysicsMaterial2D Icon
		/// </summary>
		public static GUIContent DPhysicsmaterial2dIcon => _dphysicsmaterial2dicon ??= EditorGUIUtility.IconContent("d_PhysicsMaterial2D Icon");

		private static GUIContent _dphysicsmaterial2donicon;
		/// <summary>
		/// d_PhysicsMaterial2D On Icon
		/// </summary>
		public static GUIContent DPhysicsmaterial2dOnIcon => _dphysicsmaterial2donicon ??= EditorGUIUtility.IconContent("d_PhysicsMaterial2D On Icon");

		private static GUIContent _dplatformeffector2dicon;
		/// <summary>
		/// d_PlatformEffector2D Icon
		/// </summary>
		public static GUIContent DPlatformeffector2dIcon => _dplatformeffector2dicon ??= EditorGUIUtility.IconContent("d_PlatformEffector2D Icon");

		private static GUIContent _dpointeffector2dicon;
		/// <summary>
		/// d_PointEffector2D Icon
		/// </summary>
		public static GUIContent DPointeffector2dIcon => _dpointeffector2dicon ??= EditorGUIUtility.IconContent("d_PointEffector2D Icon");

		private static GUIContent _dpolygoncollider2dicon;
		/// <summary>
		/// d_PolygonCollider2D Icon
		/// </summary>
		public static GUIContent DPolygoncollider2dIcon => _dpolygoncollider2dicon ??= EditorGUIUtility.IconContent("d_PolygonCollider2D Icon");

		private static GUIContent _dproceduralmaterialicon;
		/// <summary>
		/// d_ProceduralMaterial Icon
		/// </summary>
		public static GUIContent DProceduralmaterialIcon => _dproceduralmaterialicon ??= EditorGUIUtility.IconContent("d_ProceduralMaterial Icon");

		private static GUIContent _dprojectoricon;
		/// <summary>
		/// d_Projector Icon
		/// </summary>
		public static GUIContent DProjectorIcon => _dprojectoricon ??= EditorGUIUtility.IconContent("d_Projector Icon");

		private static GUIContent _draytracingshadericon;
		/// <summary>
		/// d_RayTracingShader Icon
		/// </summary>
		public static GUIContent DRaytracingshaderIcon => _draytracingshadericon ??= EditorGUIUtility.IconContent("d_RayTracingShader Icon");

		private static GUIContent _drecttransformicon;
		/// <summary>
		/// d_RectTransform Icon
		/// </summary>
		public static GUIContent DRecttransformIcon => _drecttransformicon ??= EditorGUIUtility.IconContent("d_RectTransform Icon");

		private static GUIContent _dreflectionprobeicon;
		/// <summary>
		/// d_ReflectionProbe Icon
		/// </summary>
		public static GUIContent DReflectionprobeIcon => _dreflectionprobeicon ??= EditorGUIUtility.IconContent("d_ReflectionProbe Icon");

		private static GUIContent _drelativejoint2dicon;
		/// <summary>
		/// d_RelativeJoint2D Icon
		/// </summary>
		public static GUIContent DRelativejoint2dIcon => _drelativejoint2dicon ??= EditorGUIUtility.IconContent("d_RelativeJoint2D Icon");

		private static GUIContent _drendertextureicon;
		/// <summary>
		/// d_RenderTexture Icon
		/// </summary>
		public static GUIContent DRendertextureIcon => _drendertextureicon ??= EditorGUIUtility.IconContent("d_RenderTexture Icon");

		private static GUIContent _drendertextureonicon;
		/// <summary>
		/// d_RenderTexture On Icon
		/// </summary>
		public static GUIContent DRendertextureOnIcon => _drendertextureonicon ??= EditorGUIUtility.IconContent("d_RenderTexture On Icon");

		private static GUIContent _drigidbodyicon;
		/// <summary>
		/// d_Rigidbody Icon
		/// </summary>
		public static GUIContent DRigidbodyIcon => _drigidbodyicon ??= EditorGUIUtility.IconContent("d_Rigidbody Icon");

		private static GUIContent _drigidbody2dicon;
		/// <summary>
		/// d_Rigidbody2D Icon
		/// </summary>
		public static GUIContent DRigidbody2dIcon => _drigidbody2dicon ??= EditorGUIUtility.IconContent("d_Rigidbody2D Icon");

		private static GUIContent _dscriptableobjecticon;
		/// <summary>
		/// d_ScriptableObject Icon
		/// </summary>
		public static GUIContent DScriptableobjectIcon => _dscriptableobjecticon ??= EditorGUIUtility.IconContent("d_ScriptableObject Icon");

		private static GUIContent _dscriptableobjectonicon;
		/// <summary>
		/// d_ScriptableObject On Icon
		/// </summary>
		public static GUIContent DScriptableobjectOnIcon => _dscriptableobjectonicon ??= EditorGUIUtility.IconContent("d_ScriptableObject On Icon");

		private static GUIContent _dshadericon;
		/// <summary>
		/// d_Shader Icon
		/// </summary>
		public static GUIContent DShaderIcon => _dshadericon ??= EditorGUIUtility.IconContent("d_Shader Icon");

		private static GUIContent _dshadervariantcollectionicon;
		/// <summary>
		/// d_ShaderVariantCollection Icon
		/// </summary>
		public static GUIContent DShadervariantcollectionIcon => _dshadervariantcollectionicon ??= EditorGUIUtility.IconContent("d_ShaderVariantCollection Icon");

		private static GUIContent _dskinnedmeshrenderericon;
		/// <summary>
		/// d_SkinnedMeshRenderer Icon
		/// </summary>
		public static GUIContent DSkinnedmeshrendererIcon => _dskinnedmeshrenderericon ??= EditorGUIUtility.IconContent("d_SkinnedMeshRenderer Icon");

		private static GUIContent _dskyboxicon;
		/// <summary>
		/// d_Skybox Icon
		/// </summary>
		public static GUIContent DSkyboxIcon => _dskyboxicon ??= EditorGUIUtility.IconContent("d_Skybox Icon");

		private static GUIContent _dsliderjoint2dicon;
		/// <summary>
		/// d_SliderJoint2D Icon
		/// </summary>
		public static GUIContent DSliderjoint2dIcon => _dsliderjoint2dicon ??= EditorGUIUtility.IconContent("d_SliderJoint2D Icon");

		private static GUIContent _dspherecollidericon;
		/// <summary>
		/// d_SphereCollider Icon
		/// </summary>
		public static GUIContent DSpherecolliderIcon => _dspherecollidericon ??= EditorGUIUtility.IconContent("d_SphereCollider Icon");

		private static GUIContent _dspringjointicon;
		/// <summary>
		/// d_SpringJoint Icon
		/// </summary>
		public static GUIContent DSpringjointIcon => _dspringjointicon ??= EditorGUIUtility.IconContent("d_SpringJoint Icon");

		private static GUIContent _dspringjoint2dicon;
		/// <summary>
		/// d_SpringJoint2D Icon
		/// </summary>
		public static GUIContent DSpringjoint2dIcon => _dspringjoint2dicon ??= EditorGUIUtility.IconContent("d_SpringJoint2D Icon");

		private static GUIContent _dspriteicon;
		/// <summary>
		/// d_Sprite Icon
		/// </summary>
		public static GUIContent DSpriteIcon => _dspriteicon ??= EditorGUIUtility.IconContent("d_Sprite Icon");

		private static GUIContent _dspritemaskicon;
		/// <summary>
		/// d_SpriteMask Icon
		/// </summary>
		public static GUIContent DSpritemaskIcon => _dspritemaskicon ??= EditorGUIUtility.IconContent("d_SpriteMask Icon");

		private static GUIContent _dspriterenderericon;
		/// <summary>
		/// d_SpriteRenderer Icon
		/// </summary>
		public static GUIContent DSpriterendererIcon => _dspriterenderericon ??= EditorGUIUtility.IconContent("d_SpriteRenderer Icon");

		private static GUIContent _dstreamingcontrollericon;
		/// <summary>
		/// d_StreamingController Icon
		/// </summary>
		public static GUIContent DStreamingcontrollerIcon => _dstreamingcontrollericon ??= EditorGUIUtility.IconContent("d_StreamingController Icon");

		private static GUIContent _dsurfaceeffector2dicon;
		/// <summary>
		/// d_SurfaceEffector2D Icon
		/// </summary>
		public static GUIContent DSurfaceeffector2dIcon => _dsurfaceeffector2dicon ??= EditorGUIUtility.IconContent("d_SurfaceEffector2D Icon");

		private static GUIContent _dtargetjoint2dicon;
		/// <summary>
		/// d_TargetJoint2D Icon
		/// </summary>
		public static GUIContent DTargetjoint2dIcon => _dtargetjoint2dicon ??= EditorGUIUtility.IconContent("d_TargetJoint2D Icon");

		private static GUIContent _dterrainicon;
		/// <summary>
		/// d_Terrain Icon
		/// </summary>
		public static GUIContent DTerrainIcon => _dterrainicon ??= EditorGUIUtility.IconContent("d_Terrain Icon");

		private static GUIContent _dterraincollidericon;
		/// <summary>
		/// d_TerrainCollider Icon
		/// </summary>
		public static GUIContent DTerraincolliderIcon => _dterraincollidericon ??= EditorGUIUtility.IconContent("d_TerrainCollider Icon");

		private static GUIContent _dterraindataicon;
		/// <summary>
		/// d_TerrainData Icon
		/// </summary>
		public static GUIContent DTerraindataIcon => _dterraindataicon ??= EditorGUIUtility.IconContent("d_TerrainData Icon");

		private static GUIContent _dtextasseticon;
		/// <summary>
		/// d_TextAsset Icon
		/// </summary>
		public static GUIContent DTextassetIcon => _dtextasseticon ??= EditorGUIUtility.IconContent("d_TextAsset Icon");

		private static GUIContent _dtextureicon;
		/// <summary>
		/// d_Texture Icon
		/// </summary>
		public static GUIContent DTextureIcon => _dtextureicon ??= EditorGUIUtility.IconContent("d_Texture Icon");

		private static GUIContent _dtexture2dicon;
		/// <summary>
		/// d_Texture2D Icon
		/// </summary>
		public static GUIContent DTexture2dIcon => _dtexture2dicon ??= EditorGUIUtility.IconContent("d_Texture2D Icon");

		private static GUIContent _dtrailrenderericon;
		/// <summary>
		/// d_TrailRenderer Icon
		/// </summary>
		public static GUIContent DTrailrendererIcon => _dtrailrenderericon ??= EditorGUIUtility.IconContent("d_TrailRenderer Icon");

		private static GUIContent _dtransformicon;
		/// <summary>
		/// d_Transform Icon
		/// </summary>
		public static GUIContent DTransformIcon => _dtransformicon ??= EditorGUIUtility.IconContent("d_Transform Icon");

		private static GUIContent _dwheelcollidericon;
		/// <summary>
		/// d_WheelCollider Icon
		/// </summary>
		public static GUIContent DWheelcolliderIcon => _dwheelcollidericon ??= EditorGUIUtility.IconContent("d_WheelCollider Icon");

		private static GUIContent _dwheeljoint2dicon;
		/// <summary>
		/// d_WheelJoint2D Icon
		/// </summary>
		public static GUIContent DWheeljoint2dIcon => _dwheeljoint2dicon ??= EditorGUIUtility.IconContent("d_WheelJoint2D Icon");

		private static GUIContent _dwindzoneicon;
		/// <summary>
		/// d_WindZone Icon
		/// </summary>
		public static GUIContent DWindzoneIcon => _dwindzoneicon ??= EditorGUIUtility.IconContent("d_WindZone Icon");

		private static GUIContent _distancejoint2dicon;
		/// <summary>
		/// DistanceJoint2D Icon
		/// </summary>
		public static GUIContent Distancejoint2dIcon => _distancejoint2dicon ??= EditorGUIUtility.IconContent("DistanceJoint2D Icon");

		private static GUIContent _edgecollider2dicon;
		/// <summary>
		/// EdgeCollider2D Icon
		/// </summary>
		public static GUIContent Edgecollider2dIcon => _edgecollider2dicon ??= EditorGUIUtility.IconContent("EdgeCollider2D Icon");

		private static GUIContent _deventsystemicon;
		/// <summary>
		/// d_EventSystem Icon
		/// </summary>
		public static GUIContent DEventsystemIcon => _deventsystemicon ??= EditorGUIUtility.IconContent("d_EventSystem Icon");

		private static GUIContent _deventtriggericon;
		/// <summary>
		/// d_EventTrigger Icon
		/// </summary>
		public static GUIContent DEventtriggerIcon => _deventtriggericon ??= EditorGUIUtility.IconContent("d_EventTrigger Icon");

		private static GUIContent _dhololensinputmoduleicon;
		/// <summary>
		/// d_HoloLensInputModule Icon
		/// </summary>
		public static GUIContent DHololensinputmoduleIcon => _dhololensinputmoduleicon ??= EditorGUIUtility.IconContent("d_HoloLensInputModule Icon");

		private static GUIContent _dphysics2draycastericon;
		/// <summary>
		/// d_Physics2DRaycaster Icon
		/// </summary>
		public static GUIContent DPhysics2draycasterIcon => _dphysics2draycastericon ??= EditorGUIUtility.IconContent("d_Physics2DRaycaster Icon");

		private static GUIContent _dphysicsraycastericon;
		/// <summary>
		/// d_PhysicsRaycaster Icon
		/// </summary>
		public static GUIContent DPhysicsraycasterIcon => _dphysicsraycastericon ??= EditorGUIUtility.IconContent("d_PhysicsRaycaster Icon");

		private static GUIContent _dstandaloneinputmoduleicon;
		/// <summary>
		/// d_StandaloneInputModule Icon
		/// </summary>
		public static GUIContent DStandaloneinputmoduleIcon => _dstandaloneinputmoduleicon ??= EditorGUIUtility.IconContent("d_StandaloneInputModule Icon");

		private static GUIContent _dtouchinputmoduleicon;
		/// <summary>
		/// d_TouchInputModule Icon
		/// </summary>
		public static GUIContent DTouchinputmoduleIcon => _dtouchinputmoduleicon ??= EditorGUIUtility.IconContent("d_TouchInputModule Icon");

		private static GUIContent _eventsystemicon;
		/// <summary>
		/// EventSystem Icon
		/// </summary>
		public static GUIContent EventsystemIcon => _eventsystemicon ??= EditorGUIUtility.IconContent("EventSystem Icon");

		private static GUIContent _eventtriggericon;
		/// <summary>
		/// EventTrigger Icon
		/// </summary>
		public static GUIContent EventtriggerIcon => _eventtriggericon ??= EditorGUIUtility.IconContent("EventTrigger Icon");

		private static GUIContent _hololensinputmoduleicon;
		/// <summary>
		/// HoloLensInputModule Icon
		/// </summary>
		public static GUIContent HololensinputmoduleIcon => _hololensinputmoduleicon ??= EditorGUIUtility.IconContent("HoloLensInputModule Icon");

		private static GUIContent _physics2draycastericon;
		/// <summary>
		/// Physics2DRaycaster Icon
		/// </summary>
		public static GUIContent Physics2draycasterIcon => _physics2draycastericon ??= EditorGUIUtility.IconContent("Physics2DRaycaster Icon");

		private static GUIContent _physicsraycastericon;
		/// <summary>
		/// PhysicsRaycaster Icon
		/// </summary>
		public static GUIContent PhysicsraycasterIcon => _physicsraycastericon ??= EditorGUIUtility.IconContent("PhysicsRaycaster Icon");

		private static GUIContent _standaloneinputmoduleicon;
		/// <summary>
		/// StandaloneInputModule Icon
		/// </summary>
		public static GUIContent StandaloneinputmoduleIcon => _standaloneinputmoduleicon ??= EditorGUIUtility.IconContent("StandaloneInputModule Icon");

		private static GUIContent _touchinputmoduleicon;
		/// <summary>
		/// TouchInputModule Icon
		/// </summary>
		public static GUIContent TouchinputmoduleIcon => _touchinputmoduleicon ??= EditorGUIUtility.IconContent("TouchInputModule Icon");

		private static GUIContent _draytracingshadericon1;
		/// <summary>
		/// d_RaytracingShader Icon
		/// </summary>
		public static GUIContent DRaytracingshaderIcon1 => _draytracingshadericon1 ??= EditorGUIUtility.IconContent("d_RaytracingShader Icon");

		private static GUIContent _raytracingshadericon;
		/// <summary>
		/// RayTracingShader Icon
		/// </summary>
		public static GUIContent RaytracingshaderIcon => _raytracingshadericon ??= EditorGUIUtility.IconContent("RayTracingShader Icon");

		private static GUIContent _fixedjointicon;
		/// <summary>
		/// FixedJoint Icon
		/// </summary>
		public static GUIContent FixedjointIcon => _fixedjointicon ??= EditorGUIUtility.IconContent("FixedJoint Icon");

		private static GUIContent _fixedjoint2dicon;
		/// <summary>
		/// FixedJoint2D Icon
		/// </summary>
		public static GUIContent Fixedjoint2dIcon => _fixedjoint2dicon ??= EditorGUIUtility.IconContent("FixedJoint2D Icon");

		private static GUIContent _flareicon;
		/// <summary>
		/// Flare Icon
		/// </summary>
		public static GUIContent FlareIcon => _flareicon ??= EditorGUIUtility.IconContent("Flare Icon");

		private static GUIContent _flareonicon;
		/// <summary>
		/// Flare On Icon
		/// </summary>
		public static GUIContent FlareOnIcon => _flareonicon ??= EditorGUIUtility.IconContent("Flare On Icon");

		private static GUIContent _flarelayericon;
		/// <summary>
		/// FlareLayer Icon
		/// </summary>
		public static GUIContent FlarelayerIcon => _flarelayericon ??= EditorGUIUtility.IconContent("FlareLayer Icon");

		private static GUIContent _fonticon;
		/// <summary>
		/// Font Icon
		/// </summary>
		public static GUIContent FontIcon => _fonticon ??= EditorGUIUtility.IconContent("Font Icon");

		private static GUIContent _fontonicon;
		/// <summary>
		/// Font On Icon
		/// </summary>
		public static GUIContent FontOnIcon => _fontonicon ??= EditorGUIUtility.IconContent("Font On Icon");

		private static GUIContent _frictionjoint2dicon;
		/// <summary>
		/// FrictionJoint2D Icon
		/// </summary>
		public static GUIContent Frictionjoint2dIcon => _frictionjoint2dicon ??= EditorGUIUtility.IconContent("FrictionJoint2D Icon");

		private static GUIContent _gameobjecticon;
		/// <summary>
		/// GameObject Icon
		/// </summary>
		public static GUIContent GameobjectIcon => _gameobjecticon ??= EditorGUIUtility.IconContent("GameObject Icon");

		private static GUIContent _gameobjectonicon;
		/// <summary>
		/// GameObject On Icon
		/// </summary>
		public static GUIContent GameobjectOnIcon => _gameobjectonicon ??= EditorGUIUtility.IconContent("GameObject On Icon");

		private static GUIContent _gridicon;
		/// <summary>
		/// Grid Icon
		/// </summary>
		public static GUIContent GridIcon => _gridicon ??= EditorGUIUtility.IconContent("Grid Icon");

		private static GUIContent _guilayericon;
		/// <summary>
		/// GUILayer Icon
		/// </summary>
		public static GUIContent GuilayerIcon => _guilayericon ??= EditorGUIUtility.IconContent("GUILayer Icon");

		private static GUIContent _guiskinicon;
		/// <summary>
		/// GUISkin Icon
		/// </summary>
		public static GUIContent GuiskinIcon => _guiskinicon ??= EditorGUIUtility.IconContent("GUISkin Icon");

		private static GUIContent _guiskinonicon;
		/// <summary>
		/// GUISkin On Icon
		/// </summary>
		public static GUIContent GuiskinOnIcon => _guiskinonicon ??= EditorGUIUtility.IconContent("GUISkin On Icon");

		private static GUIContent _guitexticon;
		/// <summary>
		/// GUIText Icon
		/// </summary>
		public static GUIContent GuitextIcon => _guitexticon ??= EditorGUIUtility.IconContent("GUIText Icon");

		private static GUIContent _guitextureicon;
		/// <summary>
		/// GUITexture Icon
		/// </summary>
		public static GUIContent GuitextureIcon => _guitextureicon ??= EditorGUIUtility.IconContent("GUITexture Icon");

		private static GUIContent _haloicon;
		/// <summary>
		/// Halo Icon
		/// </summary>
		public static GUIContent HaloIcon => _haloicon ??= EditorGUIUtility.IconContent("Halo Icon");

		private static GUIContent _hingejointicon;
		/// <summary>
		/// HingeJoint Icon
		/// </summary>
		public static GUIContent HingejointIcon => _hingejointicon ??= EditorGUIUtility.IconContent("HingeJoint Icon");

		private static GUIContent _hingejoint2dicon;
		/// <summary>
		/// HingeJoint2D Icon
		/// </summary>
		public static GUIContent Hingejoint2dIcon => _hingejoint2dicon ??= EditorGUIUtility.IconContent("HingeJoint2D Icon");

		private static GUIContent _lensflareicon;
		/// <summary>
		/// LensFlare Icon
		/// </summary>
		public static GUIContent LensflareIcon => _lensflareicon ??= EditorGUIUtility.IconContent("LensFlare Icon");

		private static GUIContent _lighticon;
		/// <summary>
		/// Light Icon
		/// </summary>
		public static GUIContent LightIcon => _lighticon ??= EditorGUIUtility.IconContent("Light Icon");

		private static GUIContent _lightingsettingsicon;
		/// <summary>
		/// LightingSettings Icon
		/// </summary>
		public static GUIContent LightingsettingsIcon => _lightingsettingsicon ??= EditorGUIUtility.IconContent("LightingSettings Icon");

		private static GUIContent _lightprobegroupicon;
		/// <summary>
		/// LightProbeGroup Icon
		/// </summary>
		public static GUIContent LightprobegroupIcon => _lightprobegroupicon ??= EditorGUIUtility.IconContent("LightProbeGroup Icon");

		private static GUIContent _lightprobeproxyvolumeicon;
		/// <summary>
		/// LightProbeProxyVolume Icon
		/// </summary>
		public static GUIContent LightprobeproxyvolumeIcon => _lightprobeproxyvolumeicon ??= EditorGUIUtility.IconContent("LightProbeProxyVolume Icon");

		private static GUIContent _lightprobesicon;
		/// <summary>
		/// LightProbes Icon
		/// </summary>
		public static GUIContent LightprobesIcon => _lightprobesicon ??= EditorGUIUtility.IconContent("LightProbes Icon");

		private static GUIContent _linerenderericon;
		/// <summary>
		/// LineRenderer Icon
		/// </summary>
		public static GUIContent LinerendererIcon => _linerenderericon ??= EditorGUIUtility.IconContent("LineRenderer Icon");

		private static GUIContent _lodgroupicon;
		/// <summary>
		/// LODGroup Icon
		/// </summary>
		public static GUIContent LodgroupIcon => _lodgroupicon ??= EditorGUIUtility.IconContent("LODGroup Icon");

		private static GUIContent _materialicon;
		/// <summary>
		/// Material Icon
		/// </summary>
		public static GUIContent MaterialIcon => _materialicon ??= EditorGUIUtility.IconContent("Material Icon");

		private static GUIContent _materialonicon;
		/// <summary>
		/// Material On Icon
		/// </summary>
		public static GUIContent MaterialOnIcon => _materialonicon ??= EditorGUIUtility.IconContent("Material On Icon");

		private static GUIContent _meshicon;
		/// <summary>
		/// Mesh Icon
		/// </summary>
		public static GUIContent MeshIcon => _meshicon ??= EditorGUIUtility.IconContent("Mesh Icon");

		private static GUIContent _meshcollidericon;
		/// <summary>
		/// MeshCollider Icon
		/// </summary>
		public static GUIContent MeshcolliderIcon => _meshcollidericon ??= EditorGUIUtility.IconContent("MeshCollider Icon");

		private static GUIContent _meshfiltericon;
		/// <summary>
		/// MeshFilter Icon
		/// </summary>
		public static GUIContent MeshfilterIcon => _meshfiltericon ??= EditorGUIUtility.IconContent("MeshFilter Icon");

		private static GUIContent _meshrenderericon;
		/// <summary>
		/// MeshRenderer Icon
		/// </summary>
		public static GUIContent MeshrendererIcon => _meshrenderericon ??= EditorGUIUtility.IconContent("MeshRenderer Icon");

		private static GUIContent _motionicon;
		/// <summary>
		/// Motion Icon
		/// </summary>
		public static GUIContent MotionIcon => _motionicon ??= EditorGUIUtility.IconContent("Motion Icon");

		private static GUIContent _movietextureicon;
		/// <summary>
		/// MovieTexture Icon
		/// </summary>
		public static GUIContent MovietextureIcon => _movietextureicon ??= EditorGUIUtility.IconContent("MovieTexture Icon");

		private static GUIContent _dnetworkanimatoricon;
		/// <summary>
		/// d_NetworkAnimator Icon
		/// </summary>
		public static GUIContent DNetworkanimatorIcon => _dnetworkanimatoricon ??= EditorGUIUtility.IconContent("d_NetworkAnimator Icon");

		private static GUIContent _dnetworkdiscoveryicon;
		/// <summary>
		/// d_NetworkDiscovery Icon
		/// </summary>
		public static GUIContent DNetworkdiscoveryIcon => _dnetworkdiscoveryicon ??= EditorGUIUtility.IconContent("d_NetworkDiscovery Icon");

		private static GUIContent _dnetworkidentityicon;
		/// <summary>
		/// d_NetworkIdentity Icon
		/// </summary>
		public static GUIContent DNetworkidentityIcon => _dnetworkidentityicon ??= EditorGUIUtility.IconContent("d_NetworkIdentity Icon");

		private static GUIContent _dnetworklobbymanagericon;
		/// <summary>
		/// d_NetworkLobbyManager Icon
		/// </summary>
		public static GUIContent DNetworklobbymanagerIcon => _dnetworklobbymanagericon ??= EditorGUIUtility.IconContent("d_NetworkLobbyManager Icon");

		private static GUIContent _dnetworklobbyplayericon;
		/// <summary>
		/// d_NetworkLobbyPlayer Icon
		/// </summary>
		public static GUIContent DNetworklobbyplayerIcon => _dnetworklobbyplayericon ??= EditorGUIUtility.IconContent("d_NetworkLobbyPlayer Icon");

		private static GUIContent _dnetworkmanagericon;
		/// <summary>
		/// d_NetworkManager Icon
		/// </summary>
		public static GUIContent DNetworkmanagerIcon => _dnetworkmanagericon ??= EditorGUIUtility.IconContent("d_NetworkManager Icon");

		private static GUIContent _dnetworkmanagerhudicon;
		/// <summary>
		/// d_NetworkManagerHUD Icon
		/// </summary>
		public static GUIContent DNetworkmanagerhudIcon => _dnetworkmanagerhudicon ??= EditorGUIUtility.IconContent("d_NetworkManagerHUD Icon");

		private static GUIContent _dnetworkmigrationmanagericon;
		/// <summary>
		/// d_NetworkMigrationManager Icon
		/// </summary>
		public static GUIContent DNetworkmigrationmanagerIcon => _dnetworkmigrationmanagericon ??= EditorGUIUtility.IconContent("d_NetworkMigrationManager Icon");

		private static GUIContent _dnetworkproximitycheckericon;
		/// <summary>
		/// d_NetworkProximityChecker Icon
		/// </summary>
		public static GUIContent DNetworkproximitycheckerIcon => _dnetworkproximitycheckericon ??= EditorGUIUtility.IconContent("d_NetworkProximityChecker Icon");

		private static GUIContent _dnetworkstartpositionicon;
		/// <summary>
		/// d_NetworkStartPosition Icon
		/// </summary>
		public static GUIContent DNetworkstartpositionIcon => _dnetworkstartpositionicon ??= EditorGUIUtility.IconContent("d_NetworkStartPosition Icon");

		private static GUIContent _dnetworktransformicon;
		/// <summary>
		/// d_NetworkTransform Icon
		/// </summary>
		public static GUIContent DNetworktransformIcon => _dnetworktransformicon ??= EditorGUIUtility.IconContent("d_NetworkTransform Icon");

		private static GUIContent _dnetworktransformchildicon;
		/// <summary>
		/// d_NetworkTransformChild Icon
		/// </summary>
		public static GUIContent DNetworktransformchildIcon => _dnetworktransformchildicon ??= EditorGUIUtility.IconContent("d_NetworkTransformChild Icon");

		private static GUIContent _dnetworktransformvisualizericon;
		/// <summary>
		/// d_NetworkTransformVisualizer Icon
		/// </summary>
		public static GUIContent DNetworktransformvisualizerIcon => _dnetworktransformvisualizericon ??= EditorGUIUtility.IconContent("d_NetworkTransformVisualizer Icon");

		private static GUIContent _networkanimatoricon;
		/// <summary>
		/// NetworkAnimator Icon
		/// </summary>
		public static GUIContent NetworkanimatorIcon => _networkanimatoricon ??= EditorGUIUtility.IconContent("NetworkAnimator Icon");

		private static GUIContent _networkdiscoveryicon;
		/// <summary>
		/// NetworkDiscovery Icon
		/// </summary>
		public static GUIContent NetworkdiscoveryIcon => _networkdiscoveryicon ??= EditorGUIUtility.IconContent("NetworkDiscovery Icon");

		private static GUIContent _networkidentityicon;
		/// <summary>
		/// NetworkIdentity Icon
		/// </summary>
		public static GUIContent NetworkidentityIcon => _networkidentityicon ??= EditorGUIUtility.IconContent("NetworkIdentity Icon");

		private static GUIContent _networklobbymanagericon;
		/// <summary>
		/// NetworkLobbyManager Icon
		/// </summary>
		public static GUIContent NetworklobbymanagerIcon => _networklobbymanagericon ??= EditorGUIUtility.IconContent("NetworkLobbyManager Icon");

		private static GUIContent _networklobbyplayericon;
		/// <summary>
		/// NetworkLobbyPlayer Icon
		/// </summary>
		public static GUIContent NetworklobbyplayerIcon => _networklobbyplayericon ??= EditorGUIUtility.IconContent("NetworkLobbyPlayer Icon");

		private static GUIContent _networkmanagericon;
		/// <summary>
		/// NetworkManager Icon
		/// </summary>
		public static GUIContent NetworkmanagerIcon => _networkmanagericon ??= EditorGUIUtility.IconContent("NetworkManager Icon");

		private static GUIContent _networkmanagerhudicon;
		/// <summary>
		/// NetworkManagerHUD Icon
		/// </summary>
		public static GUIContent NetworkmanagerhudIcon => _networkmanagerhudicon ??= EditorGUIUtility.IconContent("NetworkManagerHUD Icon");

		private static GUIContent _networkmigrationmanagericon;
		/// <summary>
		/// NetworkMigrationManager Icon
		/// </summary>
		public static GUIContent NetworkmigrationmanagerIcon => _networkmigrationmanagericon ??= EditorGUIUtility.IconContent("NetworkMigrationManager Icon");

		private static GUIContent _networkproximitycheckericon;
		/// <summary>
		/// NetworkProximityChecker Icon
		/// </summary>
		public static GUIContent NetworkproximitycheckerIcon => _networkproximitycheckericon ??= EditorGUIUtility.IconContent("NetworkProximityChecker Icon");

		private static GUIContent _networkstartpositionicon;
		/// <summary>
		/// NetworkStartPosition Icon
		/// </summary>
		public static GUIContent NetworkstartpositionIcon => _networkstartpositionicon ??= EditorGUIUtility.IconContent("NetworkStartPosition Icon");

		private static GUIContent _networktransformicon;
		/// <summary>
		/// NetworkTransform Icon
		/// </summary>
		public static GUIContent NetworktransformIcon => _networktransformicon ??= EditorGUIUtility.IconContent("NetworkTransform Icon");

		private static GUIContent _networktransformchildicon;
		/// <summary>
		/// NetworkTransformChild Icon
		/// </summary>
		public static GUIContent NetworktransformchildIcon => _networktransformchildicon ??= EditorGUIUtility.IconContent("NetworkTransformChild Icon");

		private static GUIContent _networktransformvisualizericon;
		/// <summary>
		/// NetworkTransformVisualizer Icon
		/// </summary>
		public static GUIContent NetworktransformvisualizerIcon => _networktransformvisualizericon ??= EditorGUIUtility.IconContent("NetworkTransformVisualizer Icon");

		private static GUIContent _networkviewicon;
		/// <summary>
		/// NetworkView Icon
		/// </summary>
		public static GUIContent NetworkviewIcon => _networkviewicon ??= EditorGUIUtility.IconContent("NetworkView Icon");

		private static GUIContent _occlusionareaicon;
		/// <summary>
		/// OcclusionArea Icon
		/// </summary>
		public static GUIContent OcclusionareaIcon => _occlusionareaicon ??= EditorGUIUtility.IconContent("OcclusionArea Icon");

		private static GUIContent _occlusionportalicon;
		/// <summary>
		/// OcclusionPortal Icon
		/// </summary>
		public static GUIContent OcclusionportalIcon => _occlusionportalicon ??= EditorGUIUtility.IconContent("OcclusionPortal Icon");

		private static GUIContent _particlesystemicon;
		/// <summary>
		/// ParticleSystem Icon
		/// </summary>
		public static GUIContent ParticlesystemIcon => _particlesystemicon ??= EditorGUIUtility.IconContent("ParticleSystem Icon");

		private static GUIContent _particlesystemforcefieldicon;
		/// <summary>
		/// ParticleSystemForceField Icon
		/// </summary>
		public static GUIContent ParticlesystemforcefieldIcon => _particlesystemforcefieldicon ??= EditorGUIUtility.IconContent("ParticleSystemForceField Icon");

		private static GUIContent _physicmaterialicon;
		/// <summary>
		/// PhysicMaterial Icon
		/// </summary>
		public static GUIContent PhysicmaterialIcon => _physicmaterialicon ??= EditorGUIUtility.IconContent("PhysicMaterial Icon");

		private static GUIContent _physicmaterialonicon;
		/// <summary>
		/// PhysicMaterial On Icon
		/// </summary>
		public static GUIContent PhysicmaterialOnIcon => _physicmaterialonicon ??= EditorGUIUtility.IconContent("PhysicMaterial On Icon");

		private static GUIContent _physicsmaterial2dicon;
		/// <summary>
		/// PhysicsMaterial2D Icon
		/// </summary>
		public static GUIContent Physicsmaterial2dIcon => _physicsmaterial2dicon ??= EditorGUIUtility.IconContent("PhysicsMaterial2D Icon");

		private static GUIContent _physicsmaterial2donicon;
		/// <summary>
		/// PhysicsMaterial2D On Icon
		/// </summary>
		public static GUIContent Physicsmaterial2dOnIcon => _physicsmaterial2donicon ??= EditorGUIUtility.IconContent("PhysicsMaterial2D On Icon");

		private static GUIContent _platformeffector2dicon;
		/// <summary>
		/// PlatformEffector2D Icon
		/// </summary>
		public static GUIContent Platformeffector2dIcon => _platformeffector2dicon ??= EditorGUIUtility.IconContent("PlatformEffector2D Icon");

		private static GUIContent _dplayabledirectoricon;
		/// <summary>
		/// d_PlayableDirector Icon
		/// </summary>
		public static GUIContent DPlayabledirectorIcon => _dplayabledirectoricon ??= EditorGUIUtility.IconContent("d_PlayableDirector Icon");

		private static GUIContent _playabledirectoricon;
		/// <summary>
		/// PlayableDirector Icon
		/// </summary>
		public static GUIContent PlayabledirectorIcon => _playabledirectoricon ??= EditorGUIUtility.IconContent("PlayableDirector Icon");

		private static GUIContent _pointeffector2dicon;
		/// <summary>
		/// PointEffector2D Icon
		/// </summary>
		public static GUIContent Pointeffector2dIcon => _pointeffector2dicon ??= EditorGUIUtility.IconContent("PointEffector2D Icon");

		private static GUIContent _polygoncollider2dicon;
		/// <summary>
		/// PolygonCollider2D Icon
		/// </summary>
		public static GUIContent Polygoncollider2dIcon => _polygoncollider2dicon ??= EditorGUIUtility.IconContent("PolygonCollider2D Icon");

		private static GUIContent _proceduralmaterialicon;
		/// <summary>
		/// ProceduralMaterial Icon
		/// </summary>
		public static GUIContent ProceduralmaterialIcon => _proceduralmaterialicon ??= EditorGUIUtility.IconContent("ProceduralMaterial Icon");

		private static GUIContent _projectoricon;
		/// <summary>
		/// Projector Icon
		/// </summary>
		public static GUIContent ProjectorIcon => _projectoricon ??= EditorGUIUtility.IconContent("Projector Icon");

		private static GUIContent _raytracingshadericon1;
		/// <summary>
		/// RayTracingShader Icon
		/// </summary>
		public static GUIContent RaytracingshaderIcon1 => _raytracingshadericon1 ??= EditorGUIUtility.IconContent("RayTracingShader Icon");

		private static GUIContent _recttransformicon;
		/// <summary>
		/// RectTransform Icon
		/// </summary>
		public static GUIContent RecttransformIcon => _recttransformicon ??= EditorGUIUtility.IconContent("RectTransform Icon");

		private static GUIContent _reflectionprobeicon;
		/// <summary>
		/// ReflectionProbe Icon
		/// </summary>
		public static GUIContent ReflectionprobeIcon => _reflectionprobeicon ??= EditorGUIUtility.IconContent("ReflectionProbe Icon");

		private static GUIContent _relativejoint2dicon;
		/// <summary>
		/// RelativeJoint2D Icon
		/// </summary>
		public static GUIContent Relativejoint2dIcon => _relativejoint2dicon ??= EditorGUIUtility.IconContent("RelativeJoint2D Icon");

		private static GUIContent _dsortinggroupicon;
		/// <summary>
		/// d_SortingGroup Icon
		/// </summary>
		public static GUIContent DSortinggroupIcon => _dsortinggroupicon ??= EditorGUIUtility.IconContent("d_SortingGroup Icon");

		private static GUIContent _sortinggroupicon;
		/// <summary>
		/// SortingGroup Icon
		/// </summary>
		public static GUIContent SortinggroupIcon => _sortinggroupicon ??= EditorGUIUtility.IconContent("SortingGroup Icon");

		private static GUIContent _rendertextureicon;
		/// <summary>
		/// RenderTexture Icon
		/// </summary>
		public static GUIContent RendertextureIcon => _rendertextureicon ??= EditorGUIUtility.IconContent("RenderTexture Icon");

		private static GUIContent _rendertextureonicon;
		/// <summary>
		/// RenderTexture On Icon
		/// </summary>
		public static GUIContent RendertextureOnIcon => _rendertextureonicon ??= EditorGUIUtility.IconContent("RenderTexture On Icon");

		private static GUIContent _rigidbodyicon;
		/// <summary>
		/// Rigidbody Icon
		/// </summary>
		public static GUIContent RigidbodyIcon => _rigidbodyicon ??= EditorGUIUtility.IconContent("Rigidbody Icon");

		private static GUIContent _rigidbody2dicon;
		/// <summary>
		/// Rigidbody2D Icon
		/// </summary>
		public static GUIContent Rigidbody2dIcon => _rigidbody2dicon ??= EditorGUIUtility.IconContent("Rigidbody2D Icon");

		private static GUIContent _scriptableobjecticon;
		/// <summary>
		/// ScriptableObject Icon
		/// </summary>
		public static GUIContent ScriptableobjectIcon => _scriptableobjecticon ??= EditorGUIUtility.IconContent("ScriptableObject Icon");

		private static GUIContent _scriptableobjectonicon;
		/// <summary>
		/// ScriptableObject On Icon
		/// </summary>
		public static GUIContent ScriptableobjectOnIcon => _scriptableobjectonicon ??= EditorGUIUtility.IconContent("ScriptableObject On Icon");

		private static GUIContent _shadericon;
		/// <summary>
		/// Shader Icon
		/// </summary>
		public static GUIContent ShaderIcon => _shadericon ??= EditorGUIUtility.IconContent("Shader Icon");

		private static GUIContent _shadervariantcollectionicon;
		/// <summary>
		/// ShaderVariantCollection Icon
		/// </summary>
		public static GUIContent ShadervariantcollectionIcon => _shadervariantcollectionicon ??= EditorGUIUtility.IconContent("ShaderVariantCollection Icon");

		private static GUIContent _skinnedmeshrenderericon;
		/// <summary>
		/// SkinnedMeshRenderer Icon
		/// </summary>
		public static GUIContent SkinnedmeshrendererIcon => _skinnedmeshrenderericon ??= EditorGUIUtility.IconContent("SkinnedMeshRenderer Icon");

		private static GUIContent _skyboxicon;
		/// <summary>
		/// Skybox Icon
		/// </summary>
		public static GUIContent SkyboxIcon => _skyboxicon ??= EditorGUIUtility.IconContent("Skybox Icon");

		private static GUIContent _sliderjoint2dicon;
		/// <summary>
		/// SliderJoint2D Icon
		/// </summary>
		public static GUIContent Sliderjoint2dIcon => _sliderjoint2dicon ??= EditorGUIUtility.IconContent("SliderJoint2D Icon");

		private static GUIContent _trackedposedrivericon;
		/// <summary>
		/// TrackedPoseDriver Icon
		/// </summary>
		public static GUIContent TrackedposedriverIcon => _trackedposedrivericon ??= EditorGUIUtility.IconContent("TrackedPoseDriver Icon");

		private static GUIContent _spherecollidericon;
		/// <summary>
		/// SphereCollider Icon
		/// </summary>
		public static GUIContent SpherecolliderIcon => _spherecollidericon ??= EditorGUIUtility.IconContent("SphereCollider Icon");

		private static GUIContent _springjointicon;
		/// <summary>
		/// SpringJoint Icon
		/// </summary>
		public static GUIContent SpringjointIcon => _springjointicon ??= EditorGUIUtility.IconContent("SpringJoint Icon");

		private static GUIContent _springjoint2dicon;
		/// <summary>
		/// SpringJoint2D Icon
		/// </summary>
		public static GUIContent Springjoint2dIcon => _springjoint2dicon ??= EditorGUIUtility.IconContent("SpringJoint2D Icon");

		private static GUIContent _spriteicon;
		/// <summary>
		/// Sprite Icon
		/// </summary>
		public static GUIContent SpriteIcon => _spriteicon ??= EditorGUIUtility.IconContent("Sprite Icon");

		private static GUIContent _spritemaskicon;
		/// <summary>
		/// SpriteMask Icon
		/// </summary>
		public static GUIContent SpritemaskIcon => _spritemaskicon ??= EditorGUIUtility.IconContent("SpriteMask Icon");

		private static GUIContent _spriterenderericon;
		/// <summary>
		/// SpriteRenderer Icon
		/// </summary>
		public static GUIContent SpriterendererIcon => _spriterenderericon ??= EditorGUIUtility.IconContent("SpriteRenderer Icon");

		private static GUIContent _streamingcontrollericon;
		/// <summary>
		/// StreamingController Icon
		/// </summary>
		public static GUIContent StreamingcontrollerIcon => _streamingcontrollericon ??= EditorGUIUtility.IconContent("StreamingController Icon");

		private static GUIContent _surfaceeffector2dicon;
		/// <summary>
		/// SurfaceEffector2D Icon
		/// </summary>
		public static GUIContent Surfaceeffector2dIcon => _surfaceeffector2dicon ??= EditorGUIUtility.IconContent("SurfaceEffector2D Icon");

		private static GUIContent _targetjoint2dicon;
		/// <summary>
		/// TargetJoint2D Icon
		/// </summary>
		public static GUIContent Targetjoint2dIcon => _targetjoint2dicon ??= EditorGUIUtility.IconContent("TargetJoint2D Icon");

		private static GUIContent _terrainicon;
		/// <summary>
		/// Terrain Icon
		/// </summary>
		public static GUIContent TerrainIcon => _terrainicon ??= EditorGUIUtility.IconContent("Terrain Icon");

		private static GUIContent _terraincollidericon;
		/// <summary>
		/// TerrainCollider Icon
		/// </summary>
		public static GUIContent TerraincolliderIcon => _terraincollidericon ??= EditorGUIUtility.IconContent("TerrainCollider Icon");

		private static GUIContent _terraindataicon;
		/// <summary>
		/// TerrainData Icon
		/// </summary>
		public static GUIContent TerraindataIcon => _terraindataicon ??= EditorGUIUtility.IconContent("TerrainData Icon");

		private static GUIContent _textasseticon;
		/// <summary>
		/// TextAsset Icon
		/// </summary>
		public static GUIContent TextassetIcon => _textasseticon ??= EditorGUIUtility.IconContent("TextAsset Icon");

		private static GUIContent _textmeshicon;
		/// <summary>
		/// TextMesh Icon
		/// </summary>
		public static GUIContent TextmeshIcon => _textmeshicon ??= EditorGUIUtility.IconContent("TextMesh Icon");

		private static GUIContent _textureicon;
		/// <summary>
		/// Texture Icon
		/// </summary>
		public static GUIContent TextureIcon => _textureicon ??= EditorGUIUtility.IconContent("Texture Icon");

		private static GUIContent _texture2dicon;
		/// <summary>
		/// Texture2D Icon
		/// </summary>
		public static GUIContent Texture2dIcon => _texture2dicon ??= EditorGUIUtility.IconContent("Texture2D Icon");

		private static GUIContent _dtileicon;
		/// <summary>
		/// d_Tile Icon
		/// </summary>
		public static GUIContent DTileIcon => _dtileicon ??= EditorGUIUtility.IconContent("d_Tile Icon");

		private static GUIContent _dtilemapicon;
		/// <summary>
		/// d_Tilemap Icon
		/// </summary>
		public static GUIContent DTilemapIcon => _dtilemapicon ??= EditorGUIUtility.IconContent("d_Tilemap Icon");

		private static GUIContent _dtilemapcollider2dicon;
		/// <summary>
		/// d_TilemapCollider2D Icon
		/// </summary>
		public static GUIContent DTilemapcollider2dIcon => _dtilemapcollider2dicon ??= EditorGUIUtility.IconContent("d_TilemapCollider2D Icon");

		private static GUIContent _dtilemaprenderericon;
		/// <summary>
		/// d_TilemapRenderer Icon
		/// </summary>
		public static GUIContent DTilemaprendererIcon => _dtilemaprenderericon ??= EditorGUIUtility.IconContent("d_TilemapRenderer Icon");

		private static GUIContent _tileicon;
		/// <summary>
		/// Tile Icon
		/// </summary>
		public static GUIContent TileIcon => _tileicon ??= EditorGUIUtility.IconContent("Tile Icon");

		private static GUIContent _tilemapicon;
		/// <summary>
		/// Tilemap Icon
		/// </summary>
		public static GUIContent TilemapIcon => _tilemapicon ??= EditorGUIUtility.IconContent("Tilemap Icon");

		private static GUIContent _tilemapcollider2dicon;
		/// <summary>
		/// TilemapCollider2D Icon
		/// </summary>
		public static GUIContent Tilemapcollider2dIcon => _tilemapcollider2dicon ??= EditorGUIUtility.IconContent("TilemapCollider2D Icon");

		private static GUIContent _tilemaprenderericon;
		/// <summary>
		/// TilemapRenderer Icon
		/// </summary>
		public static GUIContent TilemaprendererIcon => _tilemaprenderericon ??= EditorGUIUtility.IconContent("TilemapRenderer Icon");

		private static GUIContent _dsignalasseticon;
		/// <summary>
		/// d_SignalAsset Icon
		/// </summary>
		public static GUIContent DSignalassetIcon => _dsignalasseticon ??= EditorGUIUtility.IconContent("d_SignalAsset Icon");

		private static GUIContent _dsignalemittericon;
		/// <summary>
		/// d_SignalEmitter Icon
		/// </summary>
		public static GUIContent DSignalemitterIcon => _dsignalemittericon ??= EditorGUIUtility.IconContent("d_SignalEmitter Icon");

		private static GUIContent _dsignalreceivericon;
		/// <summary>
		/// d_SignalReceiver Icon
		/// </summary>
		public static GUIContent DSignalreceiverIcon => _dsignalreceivericon ??= EditorGUIUtility.IconContent("d_SignalReceiver Icon");

		private static GUIContent _dtimelineasseticon;
		/// <summary>
		/// d_TimelineAsset Icon
		/// </summary>
		public static GUIContent DTimelineassetIcon => _dtimelineasseticon ??= EditorGUIUtility.IconContent("d_TimelineAsset Icon");

		private static GUIContent _dtimelineassetonicon;
		/// <summary>
		/// d_TimelineAsset On Icon
		/// </summary>
		public static GUIContent DTimelineassetOnIcon => _dtimelineassetonicon ??= EditorGUIUtility.IconContent("d_TimelineAsset On Icon");

		private static GUIContent _signalasseticon;
		/// <summary>
		/// SignalAsset Icon
		/// </summary>
		public static GUIContent SignalassetIcon => _signalasseticon ??= EditorGUIUtility.IconContent("SignalAsset Icon");

		private static GUIContent _signalemittericon;
		/// <summary>
		/// SignalEmitter Icon
		/// </summary>
		public static GUIContent SignalemitterIcon => _signalemittericon ??= EditorGUIUtility.IconContent("SignalEmitter Icon");

		private static GUIContent _signalreceivericon;
		/// <summary>
		/// SignalReceiver Icon
		/// </summary>
		public static GUIContent SignalreceiverIcon => _signalreceivericon ??= EditorGUIUtility.IconContent("SignalReceiver Icon");

		private static GUIContent _timelineasseticon;
		/// <summary>
		/// TimelineAsset Icon
		/// </summary>
		public static GUIContent TimelineassetIcon => _timelineasseticon ??= EditorGUIUtility.IconContent("TimelineAsset Icon");

		private static GUIContent _timelineassetonicon;
		/// <summary>
		/// TimelineAsset On Icon
		/// </summary>
		public static GUIContent TimelineassetOnIcon => _timelineassetonicon ??= EditorGUIUtility.IconContent("TimelineAsset On Icon");

		private static GUIContent _trailrenderericon;
		/// <summary>
		/// TrailRenderer Icon
		/// </summary>
		public static GUIContent TrailrendererIcon => _trailrenderericon ??= EditorGUIUtility.IconContent("TrailRenderer Icon");

		private static GUIContent _transformicon;
		/// <summary>
		/// Transform Icon
		/// </summary>
		public static GUIContent TransformIcon => _transformicon ??= EditorGUIUtility.IconContent("Transform Icon");

		private static GUIContent _dspriteatlasicon;
		/// <summary>
		/// d_SpriteAtlas Icon
		/// </summary>
		public static GUIContent DSpriteatlasIcon => _dspriteatlasicon ??= EditorGUIUtility.IconContent("d_SpriteAtlas Icon");

		private static GUIContent _dspriteatlasonicon;
		/// <summary>
		/// d_SpriteAtlas On Icon
		/// </summary>
		public static GUIContent DSpriteatlasOnIcon => _dspriteatlasonicon ??= EditorGUIUtility.IconContent("d_SpriteAtlas On Icon");

		private static GUIContent _dspriteshaperenderericon;
		/// <summary>
		/// d_SpriteShapeRenderer Icon
		/// </summary>
		public static GUIContent DSpriteshaperendererIcon => _dspriteshaperenderericon ??= EditorGUIUtility.IconContent("d_SpriteShapeRenderer Icon");

		private static GUIContent _spriteatlasicon;
		/// <summary>
		/// SpriteAtlas Icon
		/// </summary>
		public static GUIContent SpriteatlasIcon => _spriteatlasicon ??= EditorGUIUtility.IconContent("SpriteAtlas Icon");

		private static GUIContent _spriteatlasonicon;
		/// <summary>
		/// SpriteAtlas On Icon
		/// </summary>
		public static GUIContent SpriteatlasOnIcon => _spriteatlasonicon ??= EditorGUIUtility.IconContent("SpriteAtlas On Icon");

		private static GUIContent _spriteshaperenderericon;
		/// <summary>
		/// SpriteShapeRenderer Icon
		/// </summary>
		public static GUIContent SpriteshaperendererIcon => _spriteshaperenderericon ??= EditorGUIUtility.IconContent("SpriteShapeRenderer Icon");

		private static GUIContent _aspectratiofittericon;
		/// <summary>
		/// AspectRatioFitter Icon
		/// </summary>
		public static GUIContent AspectratiofitterIcon => _aspectratiofittericon ??= EditorGUIUtility.IconContent("AspectRatioFitter Icon");

		private static GUIContent _buttonicon;
		/// <summary>
		/// Button Icon
		/// </summary>
		public static GUIContent ButtonIcon => _buttonicon ??= EditorGUIUtility.IconContent("Button Icon");

		private static GUIContent _canvasscalericon;
		/// <summary>
		/// CanvasScaler Icon
		/// </summary>
		public static GUIContent CanvasscalerIcon => _canvasscalericon ??= EditorGUIUtility.IconContent("CanvasScaler Icon");

		private static GUIContent _contentsizefittericon;
		/// <summary>
		/// ContentSizeFitter Icon
		/// </summary>
		public static GUIContent ContentsizefitterIcon => _contentsizefittericon ??= EditorGUIUtility.IconContent("ContentSizeFitter Icon");

		private static GUIContent _daspectratiofittericon;
		/// <summary>
		/// d_AspectRatioFitter Icon
		/// </summary>
		public static GUIContent DAspectratiofitterIcon => _daspectratiofittericon ??= EditorGUIUtility.IconContent("d_AspectRatioFitter Icon");

		private static GUIContent _dbuttonicon;
		/// <summary>
		/// d_Button Icon
		/// </summary>
		public static GUIContent DButtonIcon => _dbuttonicon ??= EditorGUIUtility.IconContent("d_Button Icon");

		private static GUIContent _dcanvasscalericon;
		/// <summary>
		/// d_CanvasScaler Icon
		/// </summary>
		public static GUIContent DCanvasscalerIcon => _dcanvasscalericon ??= EditorGUIUtility.IconContent("d_CanvasScaler Icon");

		private static GUIContent _dcontentsizefittericon;
		/// <summary>
		/// d_ContentSizeFitter Icon
		/// </summary>
		public static GUIContent DContentsizefitterIcon => _dcontentsizefittericon ??= EditorGUIUtility.IconContent("d_ContentSizeFitter Icon");

		private static GUIContent _ddropdownicon;
		/// <summary>
		/// d_Dropdown Icon
		/// </summary>
		public static GUIContent DDropdownIcon => _ddropdownicon ??= EditorGUIUtility.IconContent("d_Dropdown Icon");

		private static GUIContent _dfreeformlayoutgroupicon;
		/// <summary>
		/// d_FreeformLayoutGroup Icon
		/// </summary>
		public static GUIContent DFreeformlayoutgroupIcon => _dfreeformlayoutgroupicon ??= EditorGUIUtility.IconContent("d_FreeformLayoutGroup Icon");

		private static GUIContent _dgraphicraycastericon;
		/// <summary>
		/// d_GraphicRaycaster Icon
		/// </summary>
		public static GUIContent DGraphicraycasterIcon => _dgraphicraycastericon ??= EditorGUIUtility.IconContent("d_GraphicRaycaster Icon");

		private static GUIContent _dgridlayoutgroupicon1;
		/// <summary>
		/// d_GridLayoutGroup Icon
		/// </summary>
		public static GUIContent DGridlayoutgroupIcon1 => _dgridlayoutgroupicon1 ??= EditorGUIUtility.IconContent("d_GridLayoutGroup Icon");

		private static GUIContent _dhorizontallayoutgroupicon1;
		/// <summary>
		/// d_HorizontalLayoutGroup Icon
		/// </summary>
		public static GUIContent DHorizontallayoutgroupIcon1 => _dhorizontallayoutgroupicon1 ??= EditorGUIUtility.IconContent("d_HorizontalLayoutGroup Icon");

		private static GUIContent _dimageicon;
		/// <summary>
		/// d_Image Icon
		/// </summary>
		public static GUIContent DImageIcon => _dimageicon ??= EditorGUIUtility.IconContent("d_Image Icon");

		private static GUIContent _dinputfieldicon;
		/// <summary>
		/// d_InputField Icon
		/// </summary>
		public static GUIContent DInputfieldIcon => _dinputfieldicon ??= EditorGUIUtility.IconContent("d_InputField Icon");

		private static GUIContent _dlayoutelementicon;
		/// <summary>
		/// d_LayoutElement Icon
		/// </summary>
		public static GUIContent DLayoutelementIcon => _dlayoutelementicon ??= EditorGUIUtility.IconContent("d_LayoutElement Icon");

		private static GUIContent _dmaskicon;
		/// <summary>
		/// d_Mask Icon
		/// </summary>
		public static GUIContent DMaskIcon => _dmaskicon ??= EditorGUIUtility.IconContent("d_Mask Icon");

		private static GUIContent _doutlineicon;
		/// <summary>
		/// d_Outline Icon
		/// </summary>
		public static GUIContent DOutlineIcon => _doutlineicon ??= EditorGUIUtility.IconContent("d_Outline Icon");

		private static GUIContent _dphysicalresolutionicon;
		/// <summary>
		/// d_PhysicalResolution Icon
		/// </summary>
		public static GUIContent DPhysicalresolutionIcon => _dphysicalresolutionicon ??= EditorGUIUtility.IconContent("d_PhysicalResolution Icon");

		private static GUIContent _dpositionasuv1Icon;
		/// <summary>
		/// d_PositionAsUV1 Icon
		/// </summary>
		public static GUIContent DPositionasuv1Icon => _dpositionasuv1Icon ??= EditorGUIUtility.IconContent("d_PositionAsUV1 Icon");

		private static GUIContent _drawimageicon;
		/// <summary>
		/// d_RawImage Icon
		/// </summary>
		public static GUIContent DRawimageIcon => _drawimageicon ??= EditorGUIUtility.IconContent("d_RawImage Icon");

		private static GUIContent _drectmask2dicon;
		/// <summary>
		/// d_RectMask2D Icon
		/// </summary>
		public static GUIContent DRectmask2dIcon => _drectmask2dicon ??= EditorGUIUtility.IconContent("d_RectMask2D Icon");

		private static GUIContent _dscrollbaricon;
		/// <summary>
		/// d_Scrollbar Icon
		/// </summary>
		public static GUIContent DScrollbarIcon => _dscrollbaricon ??= EditorGUIUtility.IconContent("d_Scrollbar Icon");

		private static GUIContent _dscrollrecticon;
		/// <summary>
		/// d_ScrollRect Icon
		/// </summary>
		public static GUIContent DScrollrectIcon => _dscrollrecticon ??= EditorGUIUtility.IconContent("d_ScrollRect Icon");

		private static GUIContent _dscrollviewareaicon;
		/// <summary>
		/// d_ScrollViewArea Icon
		/// </summary>
		public static GUIContent DScrollviewareaIcon => _dscrollviewareaicon ??= EditorGUIUtility.IconContent("d_ScrollViewArea Icon");

		private static GUIContent _dselectableicon;
		/// <summary>
		/// d_Selectable Icon
		/// </summary>
		public static GUIContent DSelectableIcon => _dselectableicon ??= EditorGUIUtility.IconContent("d_Selectable Icon");

		private static GUIContent _dselectionlisticon;
		/// <summary>
		/// d_SelectionList Icon
		/// </summary>
		public static GUIContent DSelectionlistIcon => _dselectionlisticon ??= EditorGUIUtility.IconContent("d_SelectionList Icon");

		private static GUIContent _dselectionlistitemicon;
		/// <summary>
		/// d_SelectionListItem Icon
		/// </summary>
		public static GUIContent DSelectionlistitemIcon => _dselectionlistitemicon ??= EditorGUIUtility.IconContent("d_SelectionListItem Icon");

		private static GUIContent _dselectionlisttemplateicon;
		/// <summary>
		/// d_SelectionListTemplate Icon
		/// </summary>
		public static GUIContent DSelectionlisttemplateIcon => _dselectionlisttemplateicon ??= EditorGUIUtility.IconContent("d_SelectionListTemplate Icon");

		private static GUIContent _dshadowicon;
		/// <summary>
		/// d_Shadow Icon
		/// </summary>
		public static GUIContent DShadowIcon => _dshadowicon ??= EditorGUIUtility.IconContent("d_Shadow Icon");

		private static GUIContent _dslidericon;
		/// <summary>
		/// d_Slider Icon
		/// </summary>
		public static GUIContent DSliderIcon => _dslidericon ??= EditorGUIUtility.IconContent("d_Slider Icon");

		private static GUIContent _dtexticon;
		/// <summary>
		/// d_Text Icon
		/// </summary>
		public static GUIContent DTextIcon => _dtexticon ??= EditorGUIUtility.IconContent("d_Text Icon");

		private static GUIContent _dtoggleicon;
		/// <summary>
		/// d_Toggle Icon
		/// </summary>
		public static GUIContent DToggleIcon => _dtoggleicon ??= EditorGUIUtility.IconContent("d_Toggle Icon");

		private static GUIContent _dtogglegroupicon;
		/// <summary>
		/// d_ToggleGroup Icon
		/// </summary>
		public static GUIContent DTogglegroupIcon => _dtogglegroupicon ??= EditorGUIUtility.IconContent("d_ToggleGroup Icon");

		private static GUIContent _dverticallayoutgroupicon1;
		/// <summary>
		/// d_VerticalLayoutGroup Icon
		/// </summary>
		public static GUIContent DVerticallayoutgroupIcon1 => _dverticallayoutgroupicon1 ??= EditorGUIUtility.IconContent("d_VerticalLayoutGroup Icon");

		private static GUIContent _dropdownicon;
		/// <summary>
		/// Dropdown Icon
		/// </summary>
		public static GUIContent DropdownIcon => _dropdownicon ??= EditorGUIUtility.IconContent("Dropdown Icon");

		private static GUIContent _freeformlayoutgroupicon;
		/// <summary>
		/// FreeformLayoutGroup Icon
		/// </summary>
		public static GUIContent FreeformlayoutgroupIcon => _freeformlayoutgroupicon ??= EditorGUIUtility.IconContent("FreeformLayoutGroup Icon");

		private static GUIContent _graphicraycastericon;
		/// <summary>
		/// GraphicRaycaster Icon
		/// </summary>
		public static GUIContent GraphicraycasterIcon => _graphicraycastericon ??= EditorGUIUtility.IconContent("GraphicRaycaster Icon");

		private static GUIContent _gridlayoutgroupicon;
		/// <summary>
		/// GridLayoutGroup Icon
		/// </summary>
		public static GUIContent GridlayoutgroupIcon => _gridlayoutgroupicon ??= EditorGUIUtility.IconContent("GridLayoutGroup Icon");

		private static GUIContent _horizontallayoutgroupicon1;
		/// <summary>
		/// HorizontalLayoutGroup Icon
		/// </summary>
		public static GUIContent HorizontallayoutgroupIcon1 => _horizontallayoutgroupicon1 ??= EditorGUIUtility.IconContent("HorizontalLayoutGroup Icon");

		private static GUIContent _imageicon;
		/// <summary>
		/// Image Icon
		/// </summary>
		public static GUIContent ImageIcon => _imageicon ??= EditorGUIUtility.IconContent("Image Icon");

		private static GUIContent _inputfieldicon;
		/// <summary>
		/// InputField Icon
		/// </summary>
		public static GUIContent InputfieldIcon => _inputfieldicon ??= EditorGUIUtility.IconContent("InputField Icon");

		private static GUIContent _layoutelementicon;
		/// <summary>
		/// LayoutElement Icon
		/// </summary>
		public static GUIContent LayoutelementIcon => _layoutelementicon ??= EditorGUIUtility.IconContent("LayoutElement Icon");

		private static GUIContent _maskicon;
		/// <summary>
		/// Mask Icon
		/// </summary>
		public static GUIContent MaskIcon => _maskicon ??= EditorGUIUtility.IconContent("Mask Icon");

		private static GUIContent _outlineicon;
		/// <summary>
		/// Outline Icon
		/// </summary>
		public static GUIContent OutlineIcon => _outlineicon ??= EditorGUIUtility.IconContent("Outline Icon");

		private static GUIContent _positionasuv1Icon;
		/// <summary>
		/// PositionAsUV1 Icon
		/// </summary>
		public static GUIContent Positionasuv1Icon => _positionasuv1Icon ??= EditorGUIUtility.IconContent("PositionAsUV1 Icon");

		private static GUIContent _rawimageicon;
		/// <summary>
		/// RawImage Icon
		/// </summary>
		public static GUIContent RawimageIcon => _rawimageicon ??= EditorGUIUtility.IconContent("RawImage Icon");

		private static GUIContent _rectmask2dicon;
		/// <summary>
		/// RectMask2D Icon
		/// </summary>
		public static GUIContent Rectmask2dIcon => _rectmask2dicon ??= EditorGUIUtility.IconContent("RectMask2D Icon");

		private static GUIContent _scrollbaricon;
		/// <summary>
		/// Scrollbar Icon
		/// </summary>
		public static GUIContent ScrollbarIcon => _scrollbaricon ??= EditorGUIUtility.IconContent("Scrollbar Icon");

		private static GUIContent _scrollrecticon;
		/// <summary>
		/// ScrollRect Icon
		/// </summary>
		public static GUIContent ScrollrectIcon => _scrollrecticon ??= EditorGUIUtility.IconContent("ScrollRect Icon");

		private static GUIContent _selectableicon;
		/// <summary>
		/// Selectable Icon
		/// </summary>
		public static GUIContent SelectableIcon => _selectableicon ??= EditorGUIUtility.IconContent("Selectable Icon");

		private static GUIContent _shadowicon;
		/// <summary>
		/// Shadow Icon
		/// </summary>
		public static GUIContent ShadowIcon => _shadowicon ??= EditorGUIUtility.IconContent("Shadow Icon");

		private static GUIContent _slidericon;
		/// <summary>
		/// Slider Icon
		/// </summary>
		public static GUIContent SliderIcon => _slidericon ??= EditorGUIUtility.IconContent("Slider Icon");

		private static GUIContent _texticon;
		/// <summary>
		/// Text Icon
		/// </summary>
		public static GUIContent TextIcon => _texticon ??= EditorGUIUtility.IconContent("Text Icon");

		private static GUIContent _toggleicon;
		/// <summary>
		/// Toggle Icon
		/// </summary>
		public static GUIContent ToggleIcon => _toggleicon ??= EditorGUIUtility.IconContent("Toggle Icon");

		private static GUIContent _togglegroupicon;
		/// <summary>
		/// ToggleGroup Icon
		/// </summary>
		public static GUIContent TogglegroupIcon => _togglegroupicon ??= EditorGUIUtility.IconContent("ToggleGroup Icon");

		private static GUIContent _verticallayoutgroupicon;
		/// <summary>
		/// VerticalLayoutGroup Icon
		/// </summary>
		public static GUIContent VerticallayoutgroupIcon => _verticallayoutgroupicon ??= EditorGUIUtility.IconContent("VerticalLayoutGroup Icon");

		private static GUIContent _dstylesheeticon;
		/// <summary>
		/// d_StyleSheet Icon
		/// </summary>
		public static GUIContent DStylesheetIcon => _dstylesheeticon ??= EditorGUIUtility.IconContent("d_StyleSheet Icon");

		private static GUIContent _dvisualtreeasseticon;
		/// <summary>
		/// d_VisualTreeAsset Icon
		/// </summary>
		public static GUIContent DVisualtreeassetIcon => _dvisualtreeasseticon ??= EditorGUIUtility.IconContent("d_VisualTreeAsset Icon");

		private static GUIContent _stylesheeticon;
		/// <summary>
		/// StyleSheet Icon
		/// </summary>
		public static GUIContent StylesheetIcon => _stylesheeticon ??= EditorGUIUtility.IconContent("StyleSheet Icon");

		private static GUIContent _visualtreeasseticon;
		/// <summary>
		/// VisualTreeAsset Icon
		/// </summary>
		public static GUIContent VisualtreeassetIcon => _visualtreeasseticon ??= EditorGUIUtility.IconContent("VisualTreeAsset Icon");

		private static GUIContent _dvisualeffecticon;
		/// <summary>
		/// d_VisualEffect Icon
		/// </summary>
		public static GUIContent DVisualeffectIcon => _dvisualeffecticon ??= EditorGUIUtility.IconContent("d_VisualEffect Icon");

		private static GUIContent _dvisualeffectasseticon;
		/// <summary>
		/// d_VisualEffectAsset Icon
		/// </summary>
		public static GUIContent DVisualeffectassetIcon => _dvisualeffectasseticon ??= EditorGUIUtility.IconContent("d_VisualEffectAsset Icon");

		private static GUIContent _visualeffecticon;
		/// <summary>
		/// VisualEffect Icon
		/// </summary>
		public static GUIContent VisualeffectIcon => _visualeffecticon ??= EditorGUIUtility.IconContent("VisualEffect Icon");

		private static GUIContent _visualeffectasseticon;
		/// <summary>
		/// VisualEffectAsset Icon
		/// </summary>
		public static GUIContent VisualeffectassetIcon => _visualeffectasseticon ??= EditorGUIUtility.IconContent("VisualEffectAsset Icon");

		private static GUIContent _dvideoplayericon;
		/// <summary>
		/// d_VideoPlayer Icon
		/// </summary>
		public static GUIContent DVideoplayerIcon => _dvideoplayericon ??= EditorGUIUtility.IconContent("d_VideoPlayer Icon");

		private static GUIContent _videoclipicon;
		/// <summary>
		/// VideoClip Icon
		/// </summary>
		public static GUIContent VideoclipIcon => _videoclipicon ??= EditorGUIUtility.IconContent("VideoClip Icon");

		private static GUIContent _videoplayericon;
		/// <summary>
		/// VideoPlayer Icon
		/// </summary>
		public static GUIContent VideoplayerIcon => _videoplayericon ??= EditorGUIUtility.IconContent("VideoPlayer Icon");

		private static GUIContent _visualeffecticon1;
		/// <summary>
		/// VisualEffect Icon
		/// </summary>
		public static GUIContent VisualeffectIcon1 => _visualeffecticon1 ??= EditorGUIUtility.IconContent("VisualEffect Icon");

		private static GUIContent _visualeffectasseticon1;
		/// <summary>
		/// VisualEffectAsset Icon
		/// </summary>
		public static GUIContent VisualeffectassetIcon1 => _visualeffectasseticon1 ??= EditorGUIUtility.IconContent("VisualEffectAsset Icon");

		private static GUIContent _wheelcollidericon;
		/// <summary>
		/// WheelCollider Icon
		/// </summary>
		public static GUIContent WheelcolliderIcon => _wheelcollidericon ??= EditorGUIUtility.IconContent("WheelCollider Icon");

		private static GUIContent _wheeljoint2dicon;
		/// <summary>
		/// WheelJoint2D Icon
		/// </summary>
		public static GUIContent Wheeljoint2dIcon => _wheeljoint2dicon ??= EditorGUIUtility.IconContent("WheelJoint2D Icon");

		private static GUIContent _windzoneicon;
		/// <summary>
		/// WindZone Icon
		/// </summary>
		public static GUIContent WindzoneIcon => _windzoneicon ??= EditorGUIUtility.IconContent("WindZone Icon");

		private static GUIContent _dspatialmappingcollidericon;
		/// <summary>
		/// d_SpatialMappingCollider Icon
		/// </summary>
		public static GUIContent DSpatialmappingcolliderIcon => _dspatialmappingcollidericon ??= EditorGUIUtility.IconContent("d_SpatialMappingCollider Icon");

		private static GUIContent _spatialmappingcollidericon;
		/// <summary>
		/// SpatialMappingCollider Icon
		/// </summary>
		public static GUIContent SpatialmappingcolliderIcon => _spatialmappingcollidericon ??= EditorGUIUtility.IconContent("SpatialMappingCollider Icon");

		private static GUIContent _spatialmappingrenderericon;
		/// <summary>
		/// SpatialMappingRenderer Icon
		/// </summary>
		public static GUIContent SpatialmappingrendererIcon => _spatialmappingrenderericon ??= EditorGUIUtility.IconContent("SpatialMappingRenderer Icon");

		private static GUIContent _worldanchoricon;
		/// <summary>
		/// WorldAnchor Icon
		/// </summary>
		public static GUIContent WorldanchorIcon => _worldanchoricon ??= EditorGUIUtility.IconContent("WorldAnchor Icon");

		private static GUIContent _ussscripticon;
		/// <summary>
		/// UssScript Icon
		/// </summary>
		public static GUIContent UssscriptIcon => _ussscripticon ??= EditorGUIUtility.IconContent("UssScript Icon");

		private static GUIContent _uxmlscripticon;
		/// <summary>
		/// UxmlScript Icon
		/// </summary>
		public static GUIContent UxmlscriptIcon => _uxmlscripticon ??= EditorGUIUtility.IconContent("UxmlScript Icon");

		private static GUIContent _verticallayoutgroupicon1;
		/// <summary>
		/// VerticalLayoutGroup Icon
		/// </summary>
		public static GUIContent VerticallayoutgroupIcon1 => _verticallayoutgroupicon1 ??= EditorGUIUtility.IconContent("VerticalLayoutGroup Icon");

		private static GUIContent _videoeffecticon;
		/// <summary>
		/// VideoEffect Icon
		/// </summary>
		public static GUIContent VideoeffectIcon => _videoeffecticon ??= EditorGUIUtility.IconContent("VideoEffect Icon");

		private static GUIContent _visualeffectgizmo;
		/// <summary>
		/// VisualEffect Gizmo
		/// </summary>
		public static GUIContent VisualeffectGizmo => _visualeffectgizmo ??= EditorGUIUtility.IconContent("VisualEffect Gizmo");

		private static GUIContent _visualeffectasseticon2;
		/// <summary>
		/// VisualEffectAsset Icon
		/// </summary>
		public static GUIContent VisualeffectassetIcon2 => _visualeffectasseticon2 ??= EditorGUIUtility.IconContent("VisualEffectAsset Icon");

		private static GUIContent _windzonegizmo;
		/// <summary>
		/// WindZone Gizmo
		/// </summary>
		public static GUIContent WindzoneGizmo => _windzonegizmo ??= EditorGUIUtility.IconContent("WindZone Gizmo");

		private static GUIContent _profileraudio;
		/// <summary>
		/// Profiler.Audio
		/// </summary>
		public static GUIContent ProfilerAudio => _profileraudio ??= EditorGUIUtility.IconContent("Profiler.Audio");

		private static GUIContent _profileraudio2X;
		/// <summary>
		/// Profiler.Audio@2x
		/// </summary>
		public static GUIContent ProfilerAudio2X => _profileraudio2X ??= EditorGUIUtility.IconContent("Profiler.Audio@2x");

		private static GUIContent _profilercpu;
		/// <summary>
		/// Profiler.CPU
		/// </summary>
		public static GUIContent ProfilerCpu => _profilercpu ??= EditorGUIUtility.IconContent("Profiler.CPU");

		private static GUIContent _profilercpu2X;
		/// <summary>
		/// Profiler.CPU@2x
		/// </summary>
		public static GUIContent ProfilerCpu2X => _profilercpu2X ??= EditorGUIUtility.IconContent("Profiler.CPU@2x");

		private static GUIContent _profilerfirstframe;
		/// <summary>
		/// Profiler.FirstFrame
		/// </summary>
		public static GUIContent ProfilerFirstframe => _profilerfirstframe ??= EditorGUIUtility.IconContent("Profiler.FirstFrame");

		private static GUIContent _profilerglobalillumination;
		/// <summary>
		/// Profiler.GlobalIllumination
		/// </summary>
		public static GUIContent ProfilerGlobalillumination => _profilerglobalillumination ??= EditorGUIUtility.IconContent("Profiler.GlobalIllumination");

		private static GUIContent _profilerglobalillumination2X;
		/// <summary>
		/// Profiler.GlobalIllumination@2x
		/// </summary>
		public static GUIContent ProfilerGlobalillumination2X => _profilerglobalillumination2X ??= EditorGUIUtility.IconContent("Profiler.GlobalIllumination@2x");

		private static GUIContent _profilergpu;
		/// <summary>
		/// Profiler.GPU
		/// </summary>
		public static GUIContent ProfilerGpu => _profilergpu ??= EditorGUIUtility.IconContent("Profiler.GPU");

		private static GUIContent _profilergpu2X;
		/// <summary>
		/// Profiler.GPU@2x
		/// </summary>
		public static GUIContent ProfilerGpu2X => _profilergpu2X ??= EditorGUIUtility.IconContent("Profiler.GPU@2x");

		private static GUIContent _profilerinstrumentation;
		/// <summary>
		/// Profiler.Instrumentation
		/// </summary>
		public static GUIContent ProfilerInstrumentation => _profilerinstrumentation ??= EditorGUIUtility.IconContent("Profiler.Instrumentation");

		private static GUIContent _profilerlastframe;
		/// <summary>
		/// Profiler.LastFrame
		/// </summary>
		public static GUIContent ProfilerLastframe => _profilerlastframe ??= EditorGUIUtility.IconContent("Profiler.LastFrame");

		private static GUIContent _profilermemory;
		/// <summary>
		/// Profiler.Memory
		/// </summary>
		public static GUIContent ProfilerMemory => _profilermemory ??= EditorGUIUtility.IconContent("Profiler.Memory");

		private static GUIContent _profilermemory2X;
		/// <summary>
		/// Profiler.Memory@2x
		/// </summary>
		public static GUIContent ProfilerMemory2X => _profilermemory2X ??= EditorGUIUtility.IconContent("Profiler.Memory@2x");

		private static GUIContent _profilernetworkmessages;
		/// <summary>
		/// Profiler.NetworkMessages
		/// </summary>
		public static GUIContent ProfilerNetworkmessages => _profilernetworkmessages ??= EditorGUIUtility.IconContent("Profiler.NetworkMessages");

		private static GUIContent _profilernetworkmessages2X;
		/// <summary>
		/// Profiler.NetworkMessages@2x
		/// </summary>
		public static GUIContent ProfilerNetworkmessages2X => _profilernetworkmessages2X ??= EditorGUIUtility.IconContent("Profiler.NetworkMessages@2x");

		private static GUIContent _profilernetworkoperations;
		/// <summary>
		/// Profiler.NetworkOperations
		/// </summary>
		public static GUIContent ProfilerNetworkoperations => _profilernetworkoperations ??= EditorGUIUtility.IconContent("Profiler.NetworkOperations");

		private static GUIContent _profilernetworkoperations2X;
		/// <summary>
		/// Profiler.NetworkOperations@2x
		/// </summary>
		public static GUIContent ProfilerNetworkoperations2X => _profilernetworkoperations2X ??= EditorGUIUtility.IconContent("Profiler.NetworkOperations@2x");

		private static GUIContent _profilernextframe;
		/// <summary>
		/// Profiler.NextFrame
		/// </summary>
		public static GUIContent ProfilerNextframe => _profilernextframe ??= EditorGUIUtility.IconContent("Profiler.NextFrame");

		private static GUIContent _profilerphysics;
		/// <summary>
		/// Profiler.Physics
		/// </summary>
		public static GUIContent ProfilerPhysics => _profilerphysics ??= EditorGUIUtility.IconContent("Profiler.Physics");

		private static GUIContent _profilerphysics2d;
		/// <summary>
		/// Profiler.Physics2D
		/// </summary>
		public static GUIContent ProfilerPhysics2d => _profilerphysics2d ??= EditorGUIUtility.IconContent("Profiler.Physics2D");

		private static GUIContent _profilerphysics2d2X;
		/// <summary>
		/// Profiler.Physics2D@2x
		/// </summary>
		public static GUIContent ProfilerPhysics2d2X => _profilerphysics2d2X ??= EditorGUIUtility.IconContent("Profiler.Physics2D@2x");

		private static GUIContent _profilerphysics2X;
		/// <summary>
		/// Profiler.Physics@2x
		/// </summary>
		public static GUIContent ProfilerPhysics2X => _profilerphysics2X ??= EditorGUIUtility.IconContent("Profiler.Physics@2x");

		private static GUIContent _profilerprevframe;
		/// <summary>
		/// Profiler.PrevFrame
		/// </summary>
		public static GUIContent ProfilerPrevframe => _profilerprevframe ??= EditorGUIUtility.IconContent("Profiler.PrevFrame");

		private static GUIContent _profilerrecord;
		/// <summary>
		/// Profiler.Record
		/// </summary>
		public static GUIContent ProfilerRecord => _profilerrecord ??= EditorGUIUtility.IconContent("Profiler.Record");

		private static GUIContent _profilerrendering;
		/// <summary>
		/// Profiler.Rendering
		/// </summary>
		public static GUIContent ProfilerRendering => _profilerrendering ??= EditorGUIUtility.IconContent("Profiler.Rendering");

		private static GUIContent _profilerrendering2X;
		/// <summary>
		/// Profiler.Rendering@2x
		/// </summary>
		public static GUIContent ProfilerRendering2X => _profilerrendering2X ??= EditorGUIUtility.IconContent("Profiler.Rendering@2x");

		private static GUIContent _profilerui;
		/// <summary>
		/// Profiler.UI
		/// </summary>
		public static GUIContent ProfilerUi => _profilerui ??= EditorGUIUtility.IconContent("Profiler.UI");

		private static GUIContent _profilerui2X;
		/// <summary>
		/// Profiler.UI@2x
		/// </summary>
		public static GUIContent ProfilerUi2X => _profilerui2X ??= EditorGUIUtility.IconContent("Profiler.UI@2x");

		private static GUIContent _profileruidetails;
		/// <summary>
		/// Profiler.UIDetails
		/// </summary>
		public static GUIContent ProfilerUidetails => _profileruidetails ??= EditorGUIUtility.IconContent("Profiler.UIDetails");

		private static GUIContent _profileruidetails2X;
		/// <summary>
		/// Profiler.UIDetails@2x
		/// </summary>
		public static GUIContent ProfilerUidetails2X => _profileruidetails2X ??= EditorGUIUtility.IconContent("Profiler.UIDetails@2x");

		private static GUIContent _profilervideo;
		/// <summary>
		/// Profiler.Video
		/// </summary>
		public static GUIContent ProfilerVideo => _profilervideo ??= EditorGUIUtility.IconContent("Profiler.Video");

		private static GUIContent _profilervideo2X;
		/// <summary>
		/// Profiler.Video@2x
		/// </summary>
		public static GUIContent ProfilerVideo2X => _profilervideo2X ??= EditorGUIUtility.IconContent("Profiler.Video@2x");

		private static GUIContent _profilercolumnwarningcount;
		/// <summary>
		/// ProfilerColumn.WarningCount
		/// </summary>
		public static GUIContent ProfilercolumnWarningcount => _profilercolumnwarningcount ??= EditorGUIUtility.IconContent("ProfilerColumn.WarningCount");

		private static GUIContent _progress;
		/// <summary>
		/// Progress
		/// </summary>
		public static GUIContent Progress => _progress ??= EditorGUIUtility.IconContent("Progress");

		private static GUIContent _progress2X;
		/// <summary>
		/// Progress@2x
		/// </summary>
		public static GUIContent Progress2X => _progress2X ??= EditorGUIUtility.IconContent("Progress@2x");

		private static GUIContent _project;
		/// <summary>
		/// Project
		/// </summary>
		public static GUIContent Project => _project ??= EditorGUIUtility.IconContent("Project");

		private static GUIContent _project2X;
		/// <summary>
		/// Project@2x
		/// </summary>
		public static GUIContent Project2X => _project2X ??= EditorGUIUtility.IconContent("Project@2x");

		private static GUIContent _recordoff;
		/// <summary>
		/// Record Off
		/// </summary>
		public static GUIContent RecordOff => _recordoff ??= EditorGUIUtility.IconContent("Record Off");

		private static GUIContent _recordoff2X;
		/// <summary>
		/// Record Off@2x
		/// </summary>
		public static GUIContent RecordOff2X => _recordoff2X ??= EditorGUIUtility.IconContent("Record Off@2x");

		private static GUIContent _recordon;
		/// <summary>
		/// Record On
		/// </summary>
		public static GUIContent RecordOn => _recordon ??= EditorGUIUtility.IconContent("Record On");

		private static GUIContent _recordon2X;
		/// <summary>
		/// Record On@2x
		/// </summary>
		public static GUIContent RecordOn2X => _recordon2X ??= EditorGUIUtility.IconContent("Record On@2x");

		private static GUIContent _recttoolon;
		/// <summary>
		/// RectTool On
		/// </summary>
		public static GUIContent RecttoolOn => _recttoolon ??= EditorGUIUtility.IconContent("RectTool On");

		private static GUIContent _recttoolon2X;
		/// <summary>
		/// RectTool On@2x
		/// </summary>
		public static GUIContent RecttoolOn2X => _recttoolon2X ??= EditorGUIUtility.IconContent("RectTool On@2x");

		private static GUIContent _recttool;
		/// <summary>
		/// RectTool
		/// </summary>
		public static GUIContent Recttool => _recttool ??= EditorGUIUtility.IconContent("RectTool");

		private static GUIContent _recttool2X;
		/// <summary>
		/// RectTool@2x
		/// </summary>
		public static GUIContent Recttool2X => _recttool2X ??= EditorGUIUtility.IconContent("RectTool@2x");

		private static GUIContent _recttransformblueprint;
		/// <summary>
		/// RectTransformBlueprint
		/// </summary>
		public static GUIContent Recttransformblueprint => _recttransformblueprint ??= EditorGUIUtility.IconContent("RectTransformBlueprint");

		private static GUIContent _recttransformraw;
		/// <summary>
		/// RectTransformRaw
		/// </summary>
		public static GUIContent Recttransformraw => _recttransformraw ??= EditorGUIUtility.IconContent("RectTransformRaw");

		private static GUIContent _redgroove;
		/// <summary>
		/// redGroove
		/// </summary>
		public static GUIContent Redgroove => _redgroove ??= EditorGUIUtility.IconContent("redGroove");

		private static GUIContent _reflectionprobeselector;
		/// <summary>
		/// ReflectionProbeSelector
		/// </summary>
		public static GUIContent Reflectionprobeselector => _reflectionprobeselector ??= EditorGUIUtility.IconContent("ReflectionProbeSelector");

		private static GUIContent _reflectionprobeselector2X;
		/// <summary>
		/// ReflectionProbeSelector@2x
		/// </summary>
		public static GUIContent Reflectionprobeselector2X => _reflectionprobeselector2X ??= EditorGUIUtility.IconContent("ReflectionProbeSelector@2x");

		private static GUIContent _refresh2;
		/// <summary>
		/// Refresh
		/// </summary>
		public static GUIContent Refresh2 => _refresh2 ??= EditorGUIUtility.IconContent("Refresh");

		private static GUIContent _refresh2X2;
		/// <summary>
		/// Refresh@2x
		/// </summary>
		public static GUIContent Refresh2X2 => _refresh2X2 ??= EditorGUIUtility.IconContent("Refresh@2x");

		private static GUIContent _rightbracket;
		/// <summary>
		/// rightBracket
		/// </summary>
		public static GUIContent Rightbracket => _rightbracket ??= EditorGUIUtility.IconContent("rightBracket");

		private static GUIContent _rotatetoolon;
		/// <summary>
		/// RotateTool On
		/// </summary>
		public static GUIContent RotatetoolOn => _rotatetoolon ??= EditorGUIUtility.IconContent("RotateTool On");

		private static GUIContent _rotatetoolon2X;
		/// <summary>
		/// RotateTool On@2x
		/// </summary>
		public static GUIContent RotatetoolOn2X => _rotatetoolon2X ??= EditorGUIUtility.IconContent("RotateTool On@2x");

		private static GUIContent _rotatetool;
		/// <summary>
		/// RotateTool
		/// </summary>
		public static GUIContent Rotatetool => _rotatetool ??= EditorGUIUtility.IconContent("RotateTool");

		private static GUIContent _rotatetool2X;
		/// <summary>
		/// RotateTool@2x
		/// </summary>
		public static GUIContent Rotatetool2X => _rotatetool2X ??= EditorGUIUtility.IconContent("RotateTool@2x");

		private static GUIContent _rotatetool4X;
		/// <summary>
		/// RotateTool@4x
		/// </summary>
		public static GUIContent Rotatetool4X => _rotatetool4X ??= EditorGUIUtility.IconContent("RotateTool@4x");

		private static GUIContent _saveactive;
		/// <summary>
		/// SaveActive
		/// </summary>
		public static GUIContent Saveactive => _saveactive ??= EditorGUIUtility.IconContent("SaveActive");

		private static GUIContent _saveas;
		/// <summary>
		/// SaveAs
		/// </summary>
		public static GUIContent Saveas => _saveas ??= EditorGUIUtility.IconContent("SaveAs");

		private static GUIContent _saveas2X;
		/// <summary>
		/// SaveAs@2x
		/// </summary>
		public static GUIContent Saveas2X => _saveas2X ??= EditorGUIUtility.IconContent("SaveAs@2x");

		private static GUIContent _savefromplay;
		/// <summary>
		/// SaveFromPlay
		/// </summary>
		public static GUIContent Savefromplay => _savefromplay ??= EditorGUIUtility.IconContent("SaveFromPlay");

		private static GUIContent _savepassive;
		/// <summary>
		/// SavePassive
		/// </summary>
		public static GUIContent Savepassive => _savepassive ??= EditorGUIUtility.IconContent("SavePassive");

		private static GUIContent _scaletoolon;
		/// <summary>
		/// ScaleTool On
		/// </summary>
		public static GUIContent ScaletoolOn => _scaletoolon ??= EditorGUIUtility.IconContent("ScaleTool On");

		private static GUIContent _scaletoolon2X;
		/// <summary>
		/// ScaleTool On@2x
		/// </summary>
		public static GUIContent ScaletoolOn2X => _scaletoolon2X ??= EditorGUIUtility.IconContent("ScaleTool On@2x");

		private static GUIContent _scaletool;
		/// <summary>
		/// ScaleTool
		/// </summary>
		public static GUIContent Scaletool => _scaletool ??= EditorGUIUtility.IconContent("ScaleTool");

		private static GUIContent _scaletool2X;
		/// <summary>
		/// ScaleTool@2x
		/// </summary>
		public static GUIContent Scaletool2X => _scaletool2X ??= EditorGUIUtility.IconContent("ScaleTool@2x");

		private static GUIContent _sceneloadin;
		/// <summary>
		/// SceneLoadIn
		/// </summary>
		public static GUIContent Sceneloadin => _sceneloadin ??= EditorGUIUtility.IconContent("SceneLoadIn");

		private static GUIContent _sceneloadout;
		/// <summary>
		/// SceneLoadOut
		/// </summary>
		public static GUIContent Sceneloadout => _sceneloadout ??= EditorGUIUtility.IconContent("SceneLoadOut");

		private static GUIContent _scenepickingnotpickablemixed;
		/// <summary>
		/// scenepicking_notpickable-mixed
		/// </summary>
		public static GUIContent ScenepickingNotpickableMixed => _scenepickingnotpickablemixed ??= EditorGUIUtility.IconContent("scenepicking_notpickable-mixed");

		private static GUIContent _scenepickingnotpickablemixed2X;
		/// <summary>
		/// scenepicking_notpickable-mixed@2x
		/// </summary>
		public static GUIContent ScenepickingNotpickableMixed2X => _scenepickingnotpickablemixed2X ??= EditorGUIUtility.IconContent("scenepicking_notpickable-mixed@2x");

		private static GUIContent _scenepickingnotpickablemixedhover;
		/// <summary>
		/// scenepicking_notpickable-mixed_hover
		/// </summary>
		public static GUIContent ScenepickingNotpickableMixedHover => _scenepickingnotpickablemixedhover ??= EditorGUIUtility.IconContent("scenepicking_notpickable-mixed_hover");

		private static GUIContent _scenepickingnotpickablemixedhover2X;
		/// <summary>
		/// scenepicking_notpickable-mixed_hover@2x
		/// </summary>
		public static GUIContent ScenepickingNotpickableMixedHover2X => _scenepickingnotpickablemixedhover2X ??= EditorGUIUtility.IconContent("scenepicking_notpickable-mixed_hover@2x");

		private static GUIContent _scenepickingnotpickable;
		/// <summary>
		/// scenepicking_notpickable
		/// </summary>
		public static GUIContent ScenepickingNotpickable => _scenepickingnotpickable ??= EditorGUIUtility.IconContent("scenepicking_notpickable");

		private static GUIContent _scenepickingnotpickable2X;
		/// <summary>
		/// scenepicking_notpickable@2x
		/// </summary>
		public static GUIContent ScenepickingNotpickable2X => _scenepickingnotpickable2X ??= EditorGUIUtility.IconContent("scenepicking_notpickable@2x");

		private static GUIContent _scenepickingnotpickablehover;
		/// <summary>
		/// scenepicking_notpickable_hover
		/// </summary>
		public static GUIContent ScenepickingNotpickableHover => _scenepickingnotpickablehover ??= EditorGUIUtility.IconContent("scenepicking_notpickable_hover");

		private static GUIContent _scenepickingnotpickablehover2X;
		/// <summary>
		/// scenepicking_notpickable_hover@2x
		/// </summary>
		public static GUIContent ScenepickingNotpickableHover2X => _scenepickingnotpickablehover2X ??= EditorGUIUtility.IconContent("scenepicking_notpickable_hover@2x");

		private static GUIContent _scenepickingpickablemixed;
		/// <summary>
		/// scenepicking_pickable-mixed
		/// </summary>
		public static GUIContent ScenepickingPickableMixed => _scenepickingpickablemixed ??= EditorGUIUtility.IconContent("scenepicking_pickable-mixed");

		private static GUIContent _scenepickingpickablemixed2X;
		/// <summary>
		/// scenepicking_pickable-mixed@2x
		/// </summary>
		public static GUIContent ScenepickingPickableMixed2X => _scenepickingpickablemixed2X ??= EditorGUIUtility.IconContent("scenepicking_pickable-mixed@2x");

		private static GUIContent _scenepickingpickablemixedhover;
		/// <summary>
		/// scenepicking_pickable-mixed_hover
		/// </summary>
		public static GUIContent ScenepickingPickableMixedHover => _scenepickingpickablemixedhover ??= EditorGUIUtility.IconContent("scenepicking_pickable-mixed_hover");

		private static GUIContent _scenepickingpickablemixedhover2X;
		/// <summary>
		/// scenepicking_pickable-mixed_hover@2x
		/// </summary>
		public static GUIContent ScenepickingPickableMixedHover2X => _scenepickingpickablemixedhover2X ??= EditorGUIUtility.IconContent("scenepicking_pickable-mixed_hover@2x");

		private static GUIContent _scenepickingpickable;
		/// <summary>
		/// scenepicking_pickable
		/// </summary>
		public static GUIContent ScenepickingPickable => _scenepickingpickable ??= EditorGUIUtility.IconContent("scenepicking_pickable");

		private static GUIContent _scenepickingpickable2X;
		/// <summary>
		/// scenepicking_pickable@2x
		/// </summary>
		public static GUIContent ScenepickingPickable2X => _scenepickingpickable2X ??= EditorGUIUtility.IconContent("scenepicking_pickable@2x");

		private static GUIContent _scenepickingpickablehover;
		/// <summary>
		/// scenepicking_pickable_hover
		/// </summary>
		public static GUIContent ScenepickingPickableHover => _scenepickingpickablehover ??= EditorGUIUtility.IconContent("scenepicking_pickable_hover");

		private static GUIContent _scenepickingpickablehover2X;
		/// <summary>
		/// scenepicking_pickable_hover@2x
		/// </summary>
		public static GUIContent ScenepickingPickableHover2X => _scenepickingpickablehover2X ??= EditorGUIUtility.IconContent("scenepicking_pickable_hover@2x");

		private static GUIContent _scenesave;
		/// <summary>
		/// SceneSave
		/// </summary>
		public static GUIContent Scenesave => _scenesave ??= EditorGUIUtility.IconContent("SceneSave");

		private static GUIContent _scenesavegrey;
		/// <summary>
		/// SceneSaveGrey
		/// </summary>
		public static GUIContent Scenesavegrey => _scenesavegrey ??= EditorGUIUtility.IconContent("SceneSaveGrey");

		private static GUIContent _sceneview2d;
		/// <summary>
		/// SceneView2D
		/// </summary>
		public static GUIContent Sceneview2d => _sceneview2d ??= EditorGUIUtility.IconContent("SceneView2D");

		private static GUIContent _sceneview2d2X;
		/// <summary>
		/// SceneView2D@2x
		/// </summary>
		public static GUIContent Sceneview2d2X => _sceneview2d2X ??= EditorGUIUtility.IconContent("SceneView2D@2x");

		private static GUIContent _sceneviewalpha;
		/// <summary>
		/// SceneViewAlpha
		/// </summary>
		public static GUIContent Sceneviewalpha => _sceneviewalpha ??= EditorGUIUtility.IconContent("SceneViewAlpha");

		private static GUIContent _sceneviewaudiooff;
		/// <summary>
		/// SceneViewAudio Off
		/// </summary>
		public static GUIContent SceneviewaudioOff => _sceneviewaudiooff ??= EditorGUIUtility.IconContent("SceneViewAudio Off");

		private static GUIContent _sceneviewaudiooff2X;
		/// <summary>
		/// SceneViewAudio Off@2x
		/// </summary>
		public static GUIContent SceneviewaudioOff2X => _sceneviewaudiooff2X ??= EditorGUIUtility.IconContent("SceneViewAudio Off@2x");

		private static GUIContent _sceneviewaudio;
		/// <summary>
		/// SceneViewAudio
		/// </summary>
		public static GUIContent Sceneviewaudio => _sceneviewaudio ??= EditorGUIUtility.IconContent("SceneViewAudio");

		private static GUIContent _sceneviewaudio2X;
		/// <summary>
		/// SceneViewAudio@2x
		/// </summary>
		public static GUIContent Sceneviewaudio2X => _sceneviewaudio2X ??= EditorGUIUtility.IconContent("SceneViewAudio@2x");

		private static GUIContent _sceneviewcamera;
		/// <summary>
		/// SceneViewCamera
		/// </summary>
		public static GUIContent Sceneviewcamera => _sceneviewcamera ??= EditorGUIUtility.IconContent("SceneViewCamera");

		private static GUIContent _sceneviewcamera2X;
		/// <summary>
		/// SceneViewCamera@2x
		/// </summary>
		public static GUIContent Sceneviewcamera2X => _sceneviewcamera2X ??= EditorGUIUtility.IconContent("SceneViewCamera@2x");

		private static GUIContent _sceneviewfx;
		/// <summary>
		/// SceneViewFx
		/// </summary>
		public static GUIContent Sceneviewfx => _sceneviewfx ??= EditorGUIUtility.IconContent("SceneViewFx");

		private static GUIContent _sceneviewfx2X;
		/// <summary>
		/// SceneViewFX@2x
		/// </summary>
		public static GUIContent Sceneviewfx2X => _sceneviewfx2X ??= EditorGUIUtility.IconContent("SceneViewFX@2x");

		private static GUIContent _sceneviewlightingoff;
		/// <summary>
		/// SceneViewLighting Off
		/// </summary>
		public static GUIContent SceneviewlightingOff => _sceneviewlightingoff ??= EditorGUIUtility.IconContent("SceneViewLighting Off");

		private static GUIContent _sceneviewlightingoff2X;
		/// <summary>
		/// SceneViewLighting Off@2x
		/// </summary>
		public static GUIContent SceneviewlightingOff2X => _sceneviewlightingoff2X ??= EditorGUIUtility.IconContent("SceneViewLighting Off@2x");

		private static GUIContent _sceneviewlighting;
		/// <summary>
		/// SceneViewLighting
		/// </summary>
		public static GUIContent Sceneviewlighting => _sceneviewlighting ??= EditorGUIUtility.IconContent("SceneViewLighting");

		private static GUIContent _sceneviewlighting2X;
		/// <summary>
		/// SceneViewLighting@2x
		/// </summary>
		public static GUIContent Sceneviewlighting2X => _sceneviewlighting2X ??= EditorGUIUtility.IconContent("SceneViewLighting@2x");

		private static GUIContent _sceneviewortho;
		/// <summary>
		/// SceneViewOrtho
		/// </summary>
		public static GUIContent Sceneviewortho => _sceneviewortho ??= EditorGUIUtility.IconContent("SceneViewOrtho");

		private static GUIContent _sceneviewrgb;
		/// <summary>
		/// SceneViewRGB
		/// </summary>
		public static GUIContent Sceneviewrgb => _sceneviewrgb ??= EditorGUIUtility.IconContent("SceneViewRGB");

		private static GUIContent _sceneviewtools;
		/// <summary>
		/// SceneViewTools
		/// </summary>
		public static GUIContent Sceneviewtools => _sceneviewtools ??= EditorGUIUtility.IconContent("SceneViewTools");

		private static GUIContent _sceneviewtools2X;
		/// <summary>
		/// SceneViewTools@2x
		/// </summary>
		public static GUIContent Sceneviewtools2X => _sceneviewtools2X ??= EditorGUIUtility.IconContent("SceneViewTools@2x");

		private static GUIContent _sceneviewvisibility;
		/// <summary>
		/// SceneViewVisibility
		/// </summary>
		public static GUIContent Sceneviewvisibility => _sceneviewvisibility ??= EditorGUIUtility.IconContent("SceneViewVisibility");

		private static GUIContent _sceneviewvisibility2X;
		/// <summary>
		/// SceneViewVisibility@2x
		/// </summary>
		public static GUIContent Sceneviewvisibility2X => _sceneviewvisibility2X ??= EditorGUIUtility.IconContent("SceneViewVisibility@2x");

		private static GUIContent _scenevishiddenmixed;
		/// <summary>
		/// scenevis_hidden-mixed
		/// </summary>
		public static GUIContent ScenevisHiddenMixed => _scenevishiddenmixed ??= EditorGUIUtility.IconContent("scenevis_hidden-mixed");

		private static GUIContent _scenevishiddenmixed2X;
		/// <summary>
		/// scenevis_hidden-mixed@2x
		/// </summary>
		public static GUIContent ScenevisHiddenMixed2X => _scenevishiddenmixed2X ??= EditorGUIUtility.IconContent("scenevis_hidden-mixed@2x");

		private static GUIContent _scenevishiddenmixedhover;
		/// <summary>
		/// scenevis_hidden-mixed_hover
		/// </summary>
		public static GUIContent ScenevisHiddenMixedHover => _scenevishiddenmixedhover ??= EditorGUIUtility.IconContent("scenevis_hidden-mixed_hover");

		private static GUIContent _scenevishiddenmixedhover2X;
		/// <summary>
		/// scenevis_hidden-mixed_hover@2x
		/// </summary>
		public static GUIContent ScenevisHiddenMixedHover2X => _scenevishiddenmixedhover2X ??= EditorGUIUtility.IconContent("scenevis_hidden-mixed_hover@2x");

		private static GUIContent _scenevishidden;
		/// <summary>
		/// scenevis_hidden
		/// </summary>
		public static GUIContent ScenevisHidden => _scenevishidden ??= EditorGUIUtility.IconContent("scenevis_hidden");

		private static GUIContent _scenevishidden2X;
		/// <summary>
		/// scenevis_hidden@2x
		/// </summary>
		public static GUIContent ScenevisHidden2X => _scenevishidden2X ??= EditorGUIUtility.IconContent("scenevis_hidden@2x");

		private static GUIContent _scenevishiddenhover;
		/// <summary>
		/// scenevis_hidden_hover
		/// </summary>
		public static GUIContent ScenevisHiddenHover => _scenevishiddenhover ??= EditorGUIUtility.IconContent("scenevis_hidden_hover");

		private static GUIContent _scenevishiddenhover2X;
		/// <summary>
		/// scenevis_hidden_hover@2x
		/// </summary>
		public static GUIContent ScenevisHiddenHover2X => _scenevishiddenhover2X ??= EditorGUIUtility.IconContent("scenevis_hidden_hover@2x");

		private static GUIContent _scenevisscenehover;
		/// <summary>
		/// scenevis_scene_hover
		/// </summary>
		public static GUIContent ScenevisSceneHover => _scenevisscenehover ??= EditorGUIUtility.IconContent("scenevis_scene_hover");

		private static GUIContent _scenevisscenehover2X;
		/// <summary>
		/// scenevis_scene_hover@2x
		/// </summary>
		public static GUIContent ScenevisSceneHover2X => _scenevisscenehover2X ??= EditorGUIUtility.IconContent("scenevis_scene_hover@2x");

		private static GUIContent _scenevisvisiblemixed;
		/// <summary>
		/// scenevis_visible-mixed
		/// </summary>
		public static GUIContent ScenevisVisibleMixed => _scenevisvisiblemixed ??= EditorGUIUtility.IconContent("scenevis_visible-mixed");

		private static GUIContent _scenevisvisiblemixed2X;
		/// <summary>
		/// scenevis_visible-mixed@2x
		/// </summary>
		public static GUIContent ScenevisVisibleMixed2X => _scenevisvisiblemixed2X ??= EditorGUIUtility.IconContent("scenevis_visible-mixed@2x");

		private static GUIContent _scenevisvisiblemixedhover;
		/// <summary>
		/// scenevis_visible-mixed_hover
		/// </summary>
		public static GUIContent ScenevisVisibleMixedHover => _scenevisvisiblemixedhover ??= EditorGUIUtility.IconContent("scenevis_visible-mixed_hover");

		private static GUIContent _scenevisvisiblemixedhover2X;
		/// <summary>
		/// scenevis_visible-mixed_hover@2x
		/// </summary>
		public static GUIContent ScenevisVisibleMixedHover2X => _scenevisvisiblemixedhover2X ??= EditorGUIUtility.IconContent("scenevis_visible-mixed_hover@2x");

		private static GUIContent _scenevisvisible;
		/// <summary>
		/// scenevis_visible
		/// </summary>
		public static GUIContent ScenevisVisible => _scenevisvisible ??= EditorGUIUtility.IconContent("scenevis_visible");

		private static GUIContent _scenevisvisible2X;
		/// <summary>
		/// scenevis_visible@2x
		/// </summary>
		public static GUIContent ScenevisVisible2X => _scenevisvisible2X ??= EditorGUIUtility.IconContent("scenevis_visible@2x");

		private static GUIContent _scenevisvisiblehover;
		/// <summary>
		/// scenevis_visible_hover
		/// </summary>
		public static GUIContent ScenevisVisibleHover => _scenevisvisiblehover ??= EditorGUIUtility.IconContent("scenevis_visible_hover");

		private static GUIContent _scenevisvisiblehover2X;
		/// <summary>
		/// scenevis_visible_hover@2x
		/// </summary>
		public static GUIContent ScenevisVisibleHover2X => _scenevisvisiblehover2X ??= EditorGUIUtility.IconContent("scenevis_visible_hover@2x");

		private static GUIContent _scrollshadow;
		/// <summary>
		/// ScrollShadow
		/// </summary>
		public static GUIContent Scrollshadow => _scrollshadow ??= EditorGUIUtility.IconContent("ScrollShadow");

		private static GUIContent _settings;
		/// <summary>
		/// Settings
		/// </summary>
		public static GUIContent Settings => _settings ??= EditorGUIUtility.IconContent("Settings");

		private static GUIContent _settings2X;
		/// <summary>
		/// Settings@2x
		/// </summary>
		public static GUIContent Settings2X => _settings2X ??= EditorGUIUtility.IconContent("Settings@2x");

		private static GUIContent _settingsicon;
		/// <summary>
		/// SettingsIcon
		/// </summary>
		public static GUIContent Settingsicon => _settingsicon ??= EditorGUIUtility.IconContent("SettingsIcon");

		private static GUIContent _settingsicon2X;
		/// <summary>
		/// SettingsIcon@2x
		/// </summary>
		public static GUIContent Settingsicon2X => _settingsicon2X ??= EditorGUIUtility.IconContent("SettingsIcon@2x");

		private static GUIContent _alertdialog;
		/// <summary>
		/// alertDialog
		/// </summary>
		public static GUIContent Alertdialog => _alertdialog ??= EditorGUIUtility.IconContent("alertDialog");

		private static GUIContent _alertdialog2X;
		/// <summary>
		/// alertDialog@2x
		/// </summary>
		public static GUIContent Alertdialog2X => _alertdialog2X ??= EditorGUIUtility.IconContent("alertDialog@2x");

		private static GUIContent _conflicticon;
		/// <summary>
		/// conflict-icon
		/// </summary>
		public static GUIContent ConflictIcon => _conflicticon ??= EditorGUIUtility.IconContent("conflict-icon");

		private static GUIContent _conflicticon2X;
		/// <summary>
		/// conflict-icon@2x
		/// </summary>
		public static GUIContent ConflictIcon2X => _conflicticon2X ??= EditorGUIUtility.IconContent("conflict-icon@2x");

		private static GUIContent _dgridaxisx;
		/// <summary>
		/// d_GridAxisX
		/// </summary>
		public static GUIContent DGridaxisx => _dgridaxisx ??= EditorGUIUtility.IconContent("d_GridAxisX");

		private static GUIContent _dgridaxisx2X;
		/// <summary>
		/// d_GridAxisX@2x
		/// </summary>
		public static GUIContent DGridaxisx2X => _dgridaxisx2X ??= EditorGUIUtility.IconContent("d_GridAxisX@2x");

		private static GUIContent _dgridaxisy;
		/// <summary>
		/// d_GridAxisY
		/// </summary>
		public static GUIContent DGridaxisy => _dgridaxisy ??= EditorGUIUtility.IconContent("d_GridAxisY");

		private static GUIContent _dgridaxisy2X;
		/// <summary>
		/// d_GridAxisY@2x
		/// </summary>
		public static GUIContent DGridaxisy2X => _dgridaxisy2X ??= EditorGUIUtility.IconContent("d_GridAxisY@2x");

		private static GUIContent _dgridaxisz;
		/// <summary>
		/// d_GridAxisZ
		/// </summary>
		public static GUIContent DGridaxisz => _dgridaxisz ??= EditorGUIUtility.IconContent("d_GridAxisZ");

		private static GUIContent _dgridaxisz2X;
		/// <summary>
		/// d_GridAxisZ@2x
		/// </summary>
		public static GUIContent DGridaxisz2X => _dgridaxisz2X ??= EditorGUIUtility.IconContent("d_GridAxisZ@2x");

		private static GUIContent _dsceneviewsnapoff;
		/// <summary>
		/// d_SceneViewSnap-Off
		/// </summary>
		public static GUIContent DSceneviewsnapOff => _dsceneviewsnapoff ??= EditorGUIUtility.IconContent("d_SceneViewSnap-Off");

		private static GUIContent _dsceneviewsnapoff2X;
		/// <summary>
		/// d_SceneViewSnap-Off@2x
		/// </summary>
		public static GUIContent DSceneviewsnapOff2X => _dsceneviewsnapoff2X ??= EditorGUIUtility.IconContent("d_SceneViewSnap-Off@2x");

		private static GUIContent _dsceneviewsnapon;
		/// <summary>
		/// d_SceneViewSnap-On
		/// </summary>
		public static GUIContent DSceneviewsnapOn => _dsceneviewsnapon ??= EditorGUIUtility.IconContent("d_SceneViewSnap-On");

		private static GUIContent _dsceneviewsnapon2X;
		/// <summary>
		/// d_SceneViewSnap-On@2x
		/// </summary>
		public static GUIContent DSceneviewsnapOn2X => _dsceneviewsnapon2X ??= EditorGUIUtility.IconContent("d_SceneViewSnap-On@2x");

		private static GUIContent _gridaxisx;
		/// <summary>
		/// GridAxisX
		/// </summary>
		public static GUIContent Gridaxisx => _gridaxisx ??= EditorGUIUtility.IconContent("GridAxisX");

		private static GUIContent _gridaxisx2X;
		/// <summary>
		/// GridAxisX@2x
		/// </summary>
		public static GUIContent Gridaxisx2X => _gridaxisx2X ??= EditorGUIUtility.IconContent("GridAxisX@2x");

		private static GUIContent _gridaxisy;
		/// <summary>
		/// GridAxisY
		/// </summary>
		public static GUIContent Gridaxisy => _gridaxisy ??= EditorGUIUtility.IconContent("GridAxisY");

		private static GUIContent _gridaxisy2X;
		/// <summary>
		/// GridAxisY@2x
		/// </summary>
		public static GUIContent Gridaxisy2X => _gridaxisy2X ??= EditorGUIUtility.IconContent("GridAxisY@2x");

		private static GUIContent _gridaxisz;
		/// <summary>
		/// GridAxisZ
		/// </summary>
		public static GUIContent Gridaxisz => _gridaxisz ??= EditorGUIUtility.IconContent("GridAxisZ");

		private static GUIContent _gridaxisz2X;
		/// <summary>
		/// GridAxisZ@2x
		/// </summary>
		public static GUIContent Gridaxisz2X => _gridaxisz2X ??= EditorGUIUtility.IconContent("GridAxisZ@2x");

		private static GUIContent _sceneviewsnapoff;
		/// <summary>
		/// SceneViewSnap-Off
		/// </summary>
		public static GUIContent SceneviewsnapOff => _sceneviewsnapoff ??= EditorGUIUtility.IconContent("SceneViewSnap-Off");

		private static GUIContent _sceneviewsnapoff2X;
		/// <summary>
		/// SceneViewSnap-Off@2x
		/// </summary>
		public static GUIContent SceneviewsnapOff2X => _sceneviewsnapoff2X ??= EditorGUIUtility.IconContent("SceneViewSnap-Off@2x");

		private static GUIContent _sceneviewsnapon;
		/// <summary>
		/// SceneViewSnap-On
		/// </summary>
		public static GUIContent SceneviewsnapOn => _sceneviewsnapon ??= EditorGUIUtility.IconContent("SceneViewSnap-On");

		private static GUIContent _sceneviewsnapon2X;
		/// <summary>
		/// SceneViewSnap-On@2x
		/// </summary>
		public static GUIContent SceneviewsnapOn2X => _sceneviewsnapon2X ??= EditorGUIUtility.IconContent("SceneViewSnap-On@2x");

		private static GUIContent _socialnetworksfacebookshare;
		/// <summary>
		/// SocialNetworks.FacebookShare
		/// </summary>
		public static GUIContent SocialnetworksFacebookshare => _socialnetworksfacebookshare ??= EditorGUIUtility.IconContent("SocialNetworks.FacebookShare");

		private static GUIContent _socialnetworkslinkedinshare;
		/// <summary>
		/// SocialNetworks.LinkedInShare
		/// </summary>
		public static GUIContent SocialnetworksLinkedinshare => _socialnetworkslinkedinshare ??= EditorGUIUtility.IconContent("SocialNetworks.LinkedInShare");

		private static GUIContent _socialnetworkstweet;
		/// <summary>
		/// SocialNetworks.Tweet
		/// </summary>
		public static GUIContent SocialnetworksTweet => _socialnetworkstweet ??= EditorGUIUtility.IconContent("SocialNetworks.Tweet");

		private static GUIContent _socialnetworksudnlogo;
		/// <summary>
		/// SocialNetworks.UDNLogo
		/// </summary>
		public static GUIContent SocialnetworksUdnlogo => _socialnetworksudnlogo ??= EditorGUIUtility.IconContent("SocialNetworks.UDNLogo");

		private static GUIContent _socialnetworksudnopen;
		/// <summary>
		/// SocialNetworks.UDNOpen
		/// </summary>
		public static GUIContent SocialnetworksUdnopen => _socialnetworksudnopen ??= EditorGUIUtility.IconContent("SocialNetworks.UDNOpen");

		private static GUIContent _softlockinline;
		/// <summary>
		/// SoftlockInline
		/// </summary>
		public static GUIContent Softlockinline => _softlockinline ??= EditorGUIUtility.IconContent("SoftlockInline");

		private static GUIContent _speedscale;
		/// <summary>
		/// SpeedScale
		/// </summary>
		public static GUIContent Speedscale => _speedscale ??= EditorGUIUtility.IconContent("SpeedScale");

		private static GUIContent _statemachineeditorarrowtip;
		/// <summary>
		/// StateMachineEditor.ArrowTip
		/// </summary>
		public static GUIContent StatemachineeditorArrowtip => _statemachineeditorarrowtip ??= EditorGUIUtility.IconContent("StateMachineEditor.ArrowTip");

		private static GUIContent _statemachineeditorarrowtipselected;
		/// <summary>
		/// StateMachineEditor.ArrowTipSelected
		/// </summary>
		public static GUIContent StatemachineeditorArrowtipselected => _statemachineeditorarrowtipselected ??= EditorGUIUtility.IconContent("StateMachineEditor.ArrowTipSelected");

		private static GUIContent _statemachineeditorbackground;
		/// <summary>
		/// StateMachineEditor.Background
		/// </summary>
		public static GUIContent StatemachineeditorBackground => _statemachineeditorbackground ??= EditorGUIUtility.IconContent("StateMachineEditor.Background");

		private static GUIContent _statemachineeditorstate;
		/// <summary>
		/// StateMachineEditor.State
		/// </summary>
		public static GUIContent StatemachineeditorState => _statemachineeditorstate ??= EditorGUIUtility.IconContent("StateMachineEditor.State");

		private static GUIContent _statemachineeditorstatehover;
		/// <summary>
		/// StateMachineEditor.StateHover
		/// </summary>
		public static GUIContent StatemachineeditorStatehover => _statemachineeditorstatehover ??= EditorGUIUtility.IconContent("StateMachineEditor.StateHover");

		private static GUIContent _statemachineeditorstateselected;
		/// <summary>
		/// StateMachineEditor.StateSelected
		/// </summary>
		public static GUIContent StatemachineeditorStateselected => _statemachineeditorstateselected ??= EditorGUIUtility.IconContent("StateMachineEditor.StateSelected");

		private static GUIContent _statemachineeditorstatesub;
		/// <summary>
		/// StateMachineEditor.StateSub
		/// </summary>
		public static GUIContent StatemachineeditorStatesub => _statemachineeditorstatesub ??= EditorGUIUtility.IconContent("StateMachineEditor.StateSub");

		private static GUIContent _statemachineeditorstatesubhover;
		/// <summary>
		/// StateMachineEditor.StateSubHover
		/// </summary>
		public static GUIContent StatemachineeditorStatesubhover => _statemachineeditorstatesubhover ??= EditorGUIUtility.IconContent("StateMachineEditor.StateSubHover");

		private static GUIContent _statemachineeditorstatesubselected;
		/// <summary>
		/// StateMachineEditor.StateSubSelected
		/// </summary>
		public static GUIContent StatemachineeditorStatesubselected => _statemachineeditorstatesubselected ??= EditorGUIUtility.IconContent("StateMachineEditor.StateSubSelected");

		private static GUIContent _statemachineeditorupbutton;
		/// <summary>
		/// StateMachineEditor.UpButton
		/// </summary>
		public static GUIContent StatemachineeditorUpbutton => _statemachineeditorupbutton ??= EditorGUIUtility.IconContent("StateMachineEditor.UpButton");

		private static GUIContent _statemachineeditorupbuttonhover;
		/// <summary>
		/// StateMachineEditor.UpButtonHover
		/// </summary>
		public static GUIContent StatemachineeditorUpbuttonhover => _statemachineeditorupbuttonhover ??= EditorGUIUtility.IconContent("StateMachineEditor.UpButtonHover");

		private static GUIContent _stepbuttonon;
		/// <summary>
		/// StepButton On
		/// </summary>
		public static GUIContent StepbuttonOn => _stepbuttonon ??= EditorGUIUtility.IconContent("StepButton On");

		private static GUIContent _stepbuttonon2X;
		/// <summary>
		/// StepButton On@2x
		/// </summary>
		public static GUIContent StepbuttonOn2X => _stepbuttonon2X ??= EditorGUIUtility.IconContent("StepButton On@2x");

		private static GUIContent _stepbutton;
		/// <summary>
		/// StepButton
		/// </summary>
		public static GUIContent Stepbutton => _stepbutton ??= EditorGUIUtility.IconContent("StepButton");

		private static GUIContent _stepbutton2X;
		/// <summary>
		/// StepButton@2x
		/// </summary>
		public static GUIContent Stepbutton2X => _stepbutton2X ??= EditorGUIUtility.IconContent("StepButton@2x");

		private static GUIContent _stepleftbuttonon;
		/// <summary>
		/// StepLeftButton-On
		/// </summary>
		public static GUIContent StepleftbuttonOn => _stepleftbuttonon ??= EditorGUIUtility.IconContent("StepLeftButton-On");

		private static GUIContent _stepleftbutton;
		/// <summary>
		/// StepLeftButton
		/// </summary>
		public static GUIContent Stepleftbutton => _stepleftbutton ??= EditorGUIUtility.IconContent("StepLeftButton");

		private static GUIContent _svicondot0Sml;
		/// <summary>
		/// sv_icon_dot0_sml
		/// </summary>
		public static GUIContent SvIconDot0Sml => _svicondot0Sml ??= EditorGUIUtility.IconContent("sv_icon_dot0_sml");

		private static GUIContent _svicondot10Sml;
		/// <summary>
		/// sv_icon_dot10_sml
		/// </summary>
		public static GUIContent SvIconDot10Sml => _svicondot10Sml ??= EditorGUIUtility.IconContent("sv_icon_dot10_sml");

		private static GUIContent _svicondot11Sml;
		/// <summary>
		/// sv_icon_dot11_sml
		/// </summary>
		public static GUIContent SvIconDot11Sml => _svicondot11Sml ??= EditorGUIUtility.IconContent("sv_icon_dot11_sml");

		private static GUIContent _svicondot12Sml;
		/// <summary>
		/// sv_icon_dot12_sml
		/// </summary>
		public static GUIContent SvIconDot12Sml => _svicondot12Sml ??= EditorGUIUtility.IconContent("sv_icon_dot12_sml");

		private static GUIContent _svicondot13Sml;
		/// <summary>
		/// sv_icon_dot13_sml
		/// </summary>
		public static GUIContent SvIconDot13Sml => _svicondot13Sml ??= EditorGUIUtility.IconContent("sv_icon_dot13_sml");

		private static GUIContent _svicondot14Sml;
		/// <summary>
		/// sv_icon_dot14_sml
		/// </summary>
		public static GUIContent SvIconDot14Sml => _svicondot14Sml ??= EditorGUIUtility.IconContent("sv_icon_dot14_sml");

		private static GUIContent _svicondot15Sml;
		/// <summary>
		/// sv_icon_dot15_sml
		/// </summary>
		public static GUIContent SvIconDot15Sml => _svicondot15Sml ??= EditorGUIUtility.IconContent("sv_icon_dot15_sml");

		private static GUIContent _svicondot1Sml;
		/// <summary>
		/// sv_icon_dot1_sml
		/// </summary>
		public static GUIContent SvIconDot1Sml => _svicondot1Sml ??= EditorGUIUtility.IconContent("sv_icon_dot1_sml");

		private static GUIContent _svicondot2Sml;
		/// <summary>
		/// sv_icon_dot2_sml
		/// </summary>
		public static GUIContent SvIconDot2Sml => _svicondot2Sml ??= EditorGUIUtility.IconContent("sv_icon_dot2_sml");

		private static GUIContent _svicondot3Sml;
		/// <summary>
		/// sv_icon_dot3_sml
		/// </summary>
		public static GUIContent SvIconDot3Sml => _svicondot3Sml ??= EditorGUIUtility.IconContent("sv_icon_dot3_sml");

		private static GUIContent _svicondot4Sml;
		/// <summary>
		/// sv_icon_dot4_sml
		/// </summary>
		public static GUIContent SvIconDot4Sml => _svicondot4Sml ??= EditorGUIUtility.IconContent("sv_icon_dot4_sml");

		private static GUIContent _svicondot5Sml;
		/// <summary>
		/// sv_icon_dot5_sml
		/// </summary>
		public static GUIContent SvIconDot5Sml => _svicondot5Sml ??= EditorGUIUtility.IconContent("sv_icon_dot5_sml");

		private static GUIContent _svicondot6Sml;
		/// <summary>
		/// sv_icon_dot6_sml
		/// </summary>
		public static GUIContent SvIconDot6Sml => _svicondot6Sml ??= EditorGUIUtility.IconContent("sv_icon_dot6_sml");

		private static GUIContent _svicondot7Sml;
		/// <summary>
		/// sv_icon_dot7_sml
		/// </summary>
		public static GUIContent SvIconDot7Sml => _svicondot7Sml ??= EditorGUIUtility.IconContent("sv_icon_dot7_sml");

		private static GUIContent _svicondot8Sml;
		/// <summary>
		/// sv_icon_dot8_sml
		/// </summary>
		public static GUIContent SvIconDot8Sml => _svicondot8Sml ??= EditorGUIUtility.IconContent("sv_icon_dot8_sml");

		private static GUIContent _svicondot9Sml;
		/// <summary>
		/// sv_icon_dot9_sml
		/// </summary>
		public static GUIContent SvIconDot9Sml => _svicondot9Sml ??= EditorGUIUtility.IconContent("sv_icon_dot9_sml");

		private static GUIContent _sviconname0;
		/// <summary>
		/// sv_icon_name0
		/// </summary>
		public static GUIContent SvIconName0 => _sviconname0 ??= EditorGUIUtility.IconContent("sv_icon_name0");

		private static GUIContent _sviconname1;
		/// <summary>
		/// sv_icon_name1
		/// </summary>
		public static GUIContent SvIconName1 => _sviconname1 ??= EditorGUIUtility.IconContent("sv_icon_name1");

		private static GUIContent _sviconname2;
		/// <summary>
		/// sv_icon_name2
		/// </summary>
		public static GUIContent SvIconName2 => _sviconname2 ??= EditorGUIUtility.IconContent("sv_icon_name2");

		private static GUIContent _sviconname3;
		/// <summary>
		/// sv_icon_name3
		/// </summary>
		public static GUIContent SvIconName3 => _sviconname3 ??= EditorGUIUtility.IconContent("sv_icon_name3");

		private static GUIContent _sviconname4;
		/// <summary>
		/// sv_icon_name4
		/// </summary>
		public static GUIContent SvIconName4 => _sviconname4 ??= EditorGUIUtility.IconContent("sv_icon_name4");

		private static GUIContent _sviconname5;
		/// <summary>
		/// sv_icon_name5
		/// </summary>
		public static GUIContent SvIconName5 => _sviconname5 ??= EditorGUIUtility.IconContent("sv_icon_name5");

		private static GUIContent _sviconname6;
		/// <summary>
		/// sv_icon_name6
		/// </summary>
		public static GUIContent SvIconName6 => _sviconname6 ??= EditorGUIUtility.IconContent("sv_icon_name6");

		private static GUIContent _sviconname7;
		/// <summary>
		/// sv_icon_name7
		/// </summary>
		public static GUIContent SvIconName7 => _sviconname7 ??= EditorGUIUtility.IconContent("sv_icon_name7");

		private static GUIContent _sviconnone;
		/// <summary>
		/// sv_icon_none
		/// </summary>
		public static GUIContent SvIconNone => _sviconnone ??= EditorGUIUtility.IconContent("sv_icon_none");

		private static GUIContent _svlabel0;
		/// <summary>
		/// sv_label_0
		/// </summary>
		public static GUIContent SvLabel0 => _svlabel0 ??= EditorGUIUtility.IconContent("sv_label_0");

		private static GUIContent _svlabel1;
		/// <summary>
		/// sv_label_1
		/// </summary>
		public static GUIContent SvLabel1 => _svlabel1 ??= EditorGUIUtility.IconContent("sv_label_1");

		private static GUIContent _svlabel2;
		/// <summary>
		/// sv_label_2
		/// </summary>
		public static GUIContent SvLabel2 => _svlabel2 ??= EditorGUIUtility.IconContent("sv_label_2");

		private static GUIContent _svlabel3;
		/// <summary>
		/// sv_label_3
		/// </summary>
		public static GUIContent SvLabel3 => _svlabel3 ??= EditorGUIUtility.IconContent("sv_label_3");

		private static GUIContent _svlabel4;
		/// <summary>
		/// sv_label_4
		/// </summary>
		public static GUIContent SvLabel4 => _svlabel4 ??= EditorGUIUtility.IconContent("sv_label_4");

		private static GUIContent _svlabel5;
		/// <summary>
		/// sv_label_5
		/// </summary>
		public static GUIContent SvLabel5 => _svlabel5 ??= EditorGUIUtility.IconContent("sv_label_5");

		private static GUIContent _svlabel6;
		/// <summary>
		/// sv_label_6
		/// </summary>
		public static GUIContent SvLabel6 => _svlabel6 ??= EditorGUIUtility.IconContent("sv_label_6");

		private static GUIContent _svlabel7;
		/// <summary>
		/// sv_label_7
		/// </summary>
		public static GUIContent SvLabel7 => _svlabel7 ??= EditorGUIUtility.IconContent("sv_label_7");

		private static GUIContent _tabnext;
		/// <summary>
		/// tab_next
		/// </summary>
		public static GUIContent TabNext => _tabnext ??= EditorGUIUtility.IconContent("tab_next");

		private static GUIContent _tabnext2X;
		/// <summary>
		/// tab_next@2x
		/// </summary>
		public static GUIContent TabNext2X => _tabnext2X ??= EditorGUIUtility.IconContent("tab_next@2x");

		private static GUIContent _tabprev;
		/// <summary>
		/// tab_prev
		/// </summary>
		public static GUIContent TabPrev => _tabprev ??= EditorGUIUtility.IconContent("tab_prev");

		private static GUIContent _tabprev2X;
		/// <summary>
		/// tab_prev@2x
		/// </summary>
		public static GUIContent TabPrev2X => _tabprev2X ??= EditorGUIUtility.IconContent("tab_prev@2x");

		private static GUIContent _terraininspectorterraintooladd;
		/// <summary>
		/// TerrainInspector.TerrainToolAdd
		/// </summary>
		public static GUIContent TerraininspectorTerraintooladd => _terraininspectorterraintooladd ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolAdd");

		private static GUIContent _terraininspectorterraintoolloweron;
		/// <summary>
		/// TerrainInspector.TerrainToolLower On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoollowerOn => _terraininspectorterraintoolloweron ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolLower On");

		private static GUIContent _terraininspectorterraintoollower;
		/// <summary>
		/// TerrainInspector.TerrainToolLower
		/// </summary>
		public static GUIContent TerraininspectorTerraintoollower => _terraininspectorterraintoollower ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolLower");

		private static GUIContent _terraininspectorterraintoolloweralt;
		/// <summary>
		/// TerrainInspector.TerrainToolLowerAlt
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolloweralt => _terraininspectorterraintoolloweralt ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolLowerAlt");

		private static GUIContent _terraininspectorterraintoolplantson;
		/// <summary>
		/// TerrainInspector.TerrainToolPlants On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolplantsOn => _terraininspectorterraintoolplantson ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolPlants On");

		private static GUIContent _terraininspectorterraintoolplants;
		/// <summary>
		/// TerrainInspector.TerrainToolPlants
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolplants => _terraininspectorterraintoolplants ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolPlants");

		private static GUIContent _terraininspectorterraintoolplantsalton;
		/// <summary>
		/// TerrainInspector.TerrainToolPlantsAlt On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolplantsaltOn => _terraininspectorterraintoolplantsalton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolPlantsAlt On");

		private static GUIContent _terraininspectorterraintoolplantsalt;
		/// <summary>
		/// TerrainInspector.TerrainToolPlantsAlt
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolplantsalt => _terraininspectorterraintoolplantsalt ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolPlantsAlt");

		private static GUIContent _terraininspectorterraintoolraiseon;
		/// <summary>
		/// TerrainInspector.TerrainToolRaise On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolraiseOn => _terraininspectorterraintoolraiseon ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolRaise On");

		private static GUIContent _terraininspectorterraintoolraise;
		/// <summary>
		/// TerrainInspector.TerrainToolRaise
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolraise => _terraininspectorterraintoolraise ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolRaise");

		private static GUIContent _terraininspectorterraintoolsculpton;
		/// <summary>
		/// TerrainInspector.TerrainToolSculpt On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsculptOn => _terraininspectorterraintoolsculpton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSculpt On");

		private static GUIContent _terraininspectorterraintoolsculpt;
		/// <summary>
		/// TerrainInspector.TerrainToolSculpt
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsculpt => _terraininspectorterraintoolsculpt ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSculpt");

		private static GUIContent _terraininspectorterraintoolsetheighton;
		/// <summary>
		/// TerrainInspector.TerrainToolSetheight On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsetheightOn => _terraininspectorterraintoolsetheighton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSetheight On");

		private static GUIContent _terraininspectorterraintoolsetheight;
		/// <summary>
		/// TerrainInspector.TerrainToolSetheight
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsetheight => _terraininspectorterraintoolsetheight ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSetheight");

		private static GUIContent _terraininspectorterraintoolsetheightalton;
		/// <summary>
		/// TerrainInspector.TerrainToolSetheightAlt On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsetheightaltOn => _terraininspectorterraintoolsetheightalton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSetheightAlt On");

		private static GUIContent _terraininspectorterraintoolsetheightalt;
		/// <summary>
		/// TerrainInspector.TerrainToolSetheightAlt
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsetheightalt => _terraininspectorterraintoolsetheightalt ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSetheightAlt");

		private static GUIContent _terraininspectorterraintoolsettingson;
		/// <summary>
		/// TerrainInspector.TerrainToolSettings On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsettingsOn => _terraininspectorterraintoolsettingson ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSettings On");

		private static GUIContent _terraininspectorterraintoolsettings;
		/// <summary>
		/// TerrainInspector.TerrainToolSettings
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsettings => _terraininspectorterraintoolsettings ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSettings");

		private static GUIContent _terraininspectorterraintoolsmoothheighton;
		/// <summary>
		/// TerrainInspector.TerrainToolSmoothHeight On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsmoothheightOn => _terraininspectorterraintoolsmoothheighton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSmoothHeight On");

		private static GUIContent _terraininspectorterraintoolsmoothheight;
		/// <summary>
		/// TerrainInspector.TerrainToolSmoothHeight
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsmoothheight => _terraininspectorterraintoolsmoothheight ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSmoothHeight");

		private static GUIContent _terraininspectorterraintoolsplaton;
		/// <summary>
		/// TerrainInspector.TerrainToolSplat On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsplatOn => _terraininspectorterraintoolsplaton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSplat On");

		private static GUIContent _terraininspectorterraintoolsplat;
		/// <summary>
		/// TerrainInspector.TerrainToolSplat
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsplat => _terraininspectorterraintoolsplat ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSplat");

		private static GUIContent _terraininspectorterraintoolsplatalton;
		/// <summary>
		/// TerrainInspector.TerrainToolSplatAlt On
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsplataltOn => _terraininspectorterraintoolsplatalton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSplatAlt On");

		private static GUIContent _terraininspectorterraintoolsplatalt;
		/// <summary>
		/// TerrainInspector.TerrainToolSplatAlt
		/// </summary>
		public static GUIContent TerraininspectorTerraintoolsplatalt => _terraininspectorterraintoolsplatalt ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolSplatAlt");

		private static GUIContent _terraininspectorterraintooltreeson;
		/// <summary>
		/// TerrainInspector.TerrainToolTrees On
		/// </summary>
		public static GUIContent TerraininspectorTerraintooltreesOn => _terraininspectorterraintooltreeson ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolTrees On");

		private static GUIContent _terraininspectorterraintooltrees;
		/// <summary>
		/// TerrainInspector.TerrainToolTrees
		/// </summary>
		public static GUIContent TerraininspectorTerraintooltrees => _terraininspectorterraintooltrees ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolTrees");

		private static GUIContent _terraininspectorterraintooltreesalton;
		/// <summary>
		/// TerrainInspector.TerrainToolTreesAlt On
		/// </summary>
		public static GUIContent TerraininspectorTerraintooltreesaltOn => _terraininspectorterraintooltreesalton ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolTreesAlt On");

		private static GUIContent _terraininspectorterraintooltreesalt;
		/// <summary>
		/// TerrainInspector.TerrainToolTreesAlt
		/// </summary>
		public static GUIContent TerraininspectorTerraintooltreesalt => _terraininspectorterraintooltreesalt ??= EditorGUIUtility.IconContent("TerrainInspector.TerrainToolTreesAlt");

		private static GUIContent _testfailed;
		/// <summary>
		/// TestFailed
		/// </summary>
		public static GUIContent Testfailed => _testfailed ??= EditorGUIUtility.IconContent("TestFailed");

		private static GUIContent _testignored;
		/// <summary>
		/// TestIgnored
		/// </summary>
		public static GUIContent Testignored => _testignored ??= EditorGUIUtility.IconContent("TestIgnored");

		private static GUIContent _testinconclusive;
		/// <summary>
		/// TestInconclusive
		/// </summary>
		public static GUIContent Testinconclusive => _testinconclusive ??= EditorGUIUtility.IconContent("TestInconclusive");

		private static GUIContent _testnormal;
		/// <summary>
		/// TestNormal
		/// </summary>
		public static GUIContent Testnormal => _testnormal ??= EditorGUIUtility.IconContent("TestNormal");

		private static GUIContent _testpassed;
		/// <summary>
		/// TestPassed
		/// </summary>
		public static GUIContent Testpassed => _testpassed ??= EditorGUIUtility.IconContent("TestPassed");

		private static GUIContent _teststopwatch;
		/// <summary>
		/// TestStopwatch
		/// </summary>
		public static GUIContent Teststopwatch => _teststopwatch ??= EditorGUIUtility.IconContent("TestStopwatch");

		private static GUIContent _toggleuvoverlay;
		/// <summary>
		/// ToggleUVOverlay
		/// </summary>
		public static GUIContent Toggleuvoverlay => _toggleuvoverlay ??= EditorGUIUtility.IconContent("ToggleUVOverlay");

		private static GUIContent _toggleuvoverlay2X;
		/// <summary>
		/// ToggleUVOverlay@2x
		/// </summary>
		public static GUIContent Toggleuvoverlay2X => _toggleuvoverlay2X ??= EditorGUIUtility.IconContent("ToggleUVOverlay@2x");

		private static GUIContent _toolbarminus;
		/// <summary>
		/// Toolbar Minus
		/// </summary>
		public static GUIContent ToolbarMinus => _toolbarminus ??= EditorGUIUtility.IconContent("Toolbar Minus");

		private static GUIContent _toolbarminus2X;
		/// <summary>
		/// Toolbar Minus@2x
		/// </summary>
		public static GUIContent ToolbarMinus2X => _toolbarminus2X ??= EditorGUIUtility.IconContent("Toolbar Minus@2x");

		private static GUIContent _toolbarplusmore;
		/// <summary>
		/// Toolbar Plus More
		/// </summary>
		public static GUIContent ToolbarPlusMore => _toolbarplusmore ??= EditorGUIUtility.IconContent("Toolbar Plus More");

		private static GUIContent _toolbarplusmore2X;
		/// <summary>
		/// Toolbar Plus More@2x
		/// </summary>
		public static GUIContent ToolbarPlusMore2X => _toolbarplusmore2X ??= EditorGUIUtility.IconContent("Toolbar Plus More@2x");

		private static GUIContent _toolbarplus;
		/// <summary>
		/// Toolbar Plus
		/// </summary>
		public static GUIContent ToolbarPlus => _toolbarplus ??= EditorGUIUtility.IconContent("Toolbar Plus");

		private static GUIContent _toolbarplus2X;
		/// <summary>
		/// Toolbar Plus@2x
		/// </summary>
		public static GUIContent ToolbarPlus2X => _toolbarplus2X ??= EditorGUIUtility.IconContent("Toolbar Plus@2x");

		private static GUIContent _toolhandlecenter;
		/// <summary>
		/// ToolHandleCenter
		/// </summary>
		public static GUIContent Toolhandlecenter => _toolhandlecenter ??= EditorGUIUtility.IconContent("ToolHandleCenter");

		private static GUIContent _toolhandlecenter2X;
		/// <summary>
		/// ToolHandleCenter@2x
		/// </summary>
		public static GUIContent Toolhandlecenter2X => _toolhandlecenter2X ??= EditorGUIUtility.IconContent("ToolHandleCenter@2x");

		private static GUIContent _toolhandleglobal;
		/// <summary>
		/// ToolHandleGlobal
		/// </summary>
		public static GUIContent Toolhandleglobal => _toolhandleglobal ??= EditorGUIUtility.IconContent("ToolHandleGlobal");

		private static GUIContent _toolhandleglobal2X;
		/// <summary>
		/// ToolHandleGlobal@2x
		/// </summary>
		public static GUIContent Toolhandleglobal2X => _toolhandleglobal2X ??= EditorGUIUtility.IconContent("ToolHandleGlobal@2x");

		private static GUIContent _toolhandlelocal;
		/// <summary>
		/// ToolHandleLocal
		/// </summary>
		public static GUIContent Toolhandlelocal => _toolhandlelocal ??= EditorGUIUtility.IconContent("ToolHandleLocal");

		private static GUIContent _toolhandlelocal2X;
		/// <summary>
		/// ToolHandleLocal@2x
		/// </summary>
		public static GUIContent Toolhandlelocal2X => _toolhandlelocal2X ??= EditorGUIUtility.IconContent("ToolHandleLocal@2x");

		private static GUIContent _toolhandlepivot;
		/// <summary>
		/// ToolHandlePivot
		/// </summary>
		public static GUIContent Toolhandlepivot => _toolhandlepivot ??= EditorGUIUtility.IconContent("ToolHandlePivot");

		private static GUIContent _toolhandlepivot2X;
		/// <summary>
		/// ToolHandlePivot@2x
		/// </summary>
		public static GUIContent Toolhandlepivot2X => _toolhandlepivot2X ??= EditorGUIUtility.IconContent("ToolHandlePivot@2x");

		private static GUIContent _toolsicon;
		/// <summary>
		/// ToolsIcon
		/// </summary>
		public static GUIContent Toolsicon => _toolsicon ??= EditorGUIUtility.IconContent("ToolsIcon");

		private static GUIContent _tranp;
		/// <summary>
		/// tranp
		/// </summary>
		public static GUIContent Tranp => _tranp ??= EditorGUIUtility.IconContent("tranp");

		private static GUIContent _transformtoolon;
		/// <summary>
		/// TransformTool On
		/// </summary>
		public static GUIContent TransformtoolOn => _transformtoolon ??= EditorGUIUtility.IconContent("TransformTool On");

		private static GUIContent _transformtoolon2X;
		/// <summary>
		/// TransformTool On@2x
		/// </summary>
		public static GUIContent TransformtoolOn2X => _transformtoolon2X ??= EditorGUIUtility.IconContent("TransformTool On@2x");

		private static GUIContent _transformtool;
		/// <summary>
		/// TransformTool
		/// </summary>
		public static GUIContent Transformtool => _transformtool ??= EditorGUIUtility.IconContent("TransformTool");

		private static GUIContent _transformtool2X;
		/// <summary>
		/// TransformTool@2x
		/// </summary>
		public static GUIContent Transformtool2X => _transformtool2X ??= EditorGUIUtility.IconContent("TransformTool@2x");

		private static GUIContent _treeicon;
		/// <summary>
		/// tree_icon
		/// </summary>
		public static GUIContent TreeIcon => _treeicon ??= EditorGUIUtility.IconContent("tree_icon");

		private static GUIContent _treeiconbranch;
		/// <summary>
		/// tree_icon_branch
		/// </summary>
		public static GUIContent TreeIconBranch => _treeiconbranch ??= EditorGUIUtility.IconContent("tree_icon_branch");

		private static GUIContent _treeiconbranchfrond;
		/// <summary>
		/// tree_icon_branch_frond
		/// </summary>
		public static GUIContent TreeIconBranchFrond => _treeiconbranchfrond ??= EditorGUIUtility.IconContent("tree_icon_branch_frond");

		private static GUIContent _treeiconfrond;
		/// <summary>
		/// tree_icon_frond
		/// </summary>
		public static GUIContent TreeIconFrond => _treeiconfrond ??= EditorGUIUtility.IconContent("tree_icon_frond");

		private static GUIContent _treeiconleaf;
		/// <summary>
		/// tree_icon_leaf
		/// </summary>
		public static GUIContent TreeIconLeaf => _treeiconleaf ??= EditorGUIUtility.IconContent("tree_icon_leaf");

		private static GUIContent _treeeditoraddbranches;
		/// <summary>
		/// TreeEditor.AddBranches
		/// </summary>
		public static GUIContent TreeeditorAddbranches => _treeeditoraddbranches ??= EditorGUIUtility.IconContent("TreeEditor.AddBranches");

		private static GUIContent _treeeditoraddleaves;
		/// <summary>
		/// TreeEditor.AddLeaves
		/// </summary>
		public static GUIContent TreeeditorAddleaves => _treeeditoraddleaves ??= EditorGUIUtility.IconContent("TreeEditor.AddLeaves");

		private static GUIContent _treeeditorbranchon;
		/// <summary>
		/// TreeEditor.Branch On
		/// </summary>
		public static GUIContent TreeeditorBranchOn => _treeeditorbranchon ??= EditorGUIUtility.IconContent("TreeEditor.Branch On");

		private static GUIContent _treeeditorbranch;
		/// <summary>
		/// TreeEditor.Branch
		/// </summary>
		public static GUIContent TreeeditorBranch => _treeeditorbranch ??= EditorGUIUtility.IconContent("TreeEditor.Branch");

		private static GUIContent _treeeditorbranchfreehandon;
		/// <summary>
		/// TreeEditor.BranchFreeHand On
		/// </summary>
		public static GUIContent TreeeditorBranchfreehandOn => _treeeditorbranchfreehandon ??= EditorGUIUtility.IconContent("TreeEditor.BranchFreeHand On");

		private static GUIContent _treeeditorbranchfreehand;
		/// <summary>
		/// TreeEditor.BranchFreeHand
		/// </summary>
		public static GUIContent TreeeditorBranchfreehand => _treeeditorbranchfreehand ??= EditorGUIUtility.IconContent("TreeEditor.BranchFreeHand");

		private static GUIContent _treeeditorbranchrotateon;
		/// <summary>
		/// TreeEditor.BranchRotate On
		/// </summary>
		public static GUIContent TreeeditorBranchrotateOn => _treeeditorbranchrotateon ??= EditorGUIUtility.IconContent("TreeEditor.BranchRotate On");

		private static GUIContent _treeeditorbranchrotate;
		/// <summary>
		/// TreeEditor.BranchRotate
		/// </summary>
		public static GUIContent TreeeditorBranchrotate => _treeeditorbranchrotate ??= EditorGUIUtility.IconContent("TreeEditor.BranchRotate");

		private static GUIContent _treeeditorbranchscaleon;
		/// <summary>
		/// TreeEditor.BranchScale On
		/// </summary>
		public static GUIContent TreeeditorBranchscaleOn => _treeeditorbranchscaleon ??= EditorGUIUtility.IconContent("TreeEditor.BranchScale On");

		private static GUIContent _treeeditorbranchscale;
		/// <summary>
		/// TreeEditor.BranchScale
		/// </summary>
		public static GUIContent TreeeditorBranchscale => _treeeditorbranchscale ??= EditorGUIUtility.IconContent("TreeEditor.BranchScale");

		private static GUIContent _treeeditorbranchtranslateon;
		/// <summary>
		/// TreeEditor.BranchTranslate On
		/// </summary>
		public static GUIContent TreeeditorBranchtranslateOn => _treeeditorbranchtranslateon ??= EditorGUIUtility.IconContent("TreeEditor.BranchTranslate On");

		private static GUIContent _treeeditorbranchtranslate;
		/// <summary>
		/// TreeEditor.BranchTranslate
		/// </summary>
		public static GUIContent TreeeditorBranchtranslate => _treeeditorbranchtranslate ??= EditorGUIUtility.IconContent("TreeEditor.BranchTranslate");

		private static GUIContent _treeeditordistributionon;
		/// <summary>
		/// TreeEditor.Distribution On
		/// </summary>
		public static GUIContent TreeeditorDistributionOn => _treeeditordistributionon ??= EditorGUIUtility.IconContent("TreeEditor.Distribution On");

		private static GUIContent _treeeditordistribution;
		/// <summary>
		/// TreeEditor.Distribution
		/// </summary>
		public static GUIContent TreeeditorDistribution => _treeeditordistribution ??= EditorGUIUtility.IconContent("TreeEditor.Distribution");

		private static GUIContent _treeeditorduplicate;
		/// <summary>
		/// TreeEditor.Duplicate
		/// </summary>
		public static GUIContent TreeeditorDuplicate => _treeeditorduplicate ??= EditorGUIUtility.IconContent("TreeEditor.Duplicate");

		private static GUIContent _treeeditorgeometryon;
		/// <summary>
		/// TreeEditor.Geometry On
		/// </summary>
		public static GUIContent TreeeditorGeometryOn => _treeeditorgeometryon ??= EditorGUIUtility.IconContent("TreeEditor.Geometry On");

		private static GUIContent _treeeditorgeometry;
		/// <summary>
		/// TreeEditor.Geometry
		/// </summary>
		public static GUIContent TreeeditorGeometry => _treeeditorgeometry ??= EditorGUIUtility.IconContent("TreeEditor.Geometry");

		private static GUIContent _treeeditorleafon;
		/// <summary>
		/// TreeEditor.Leaf On
		/// </summary>
		public static GUIContent TreeeditorLeafOn => _treeeditorleafon ??= EditorGUIUtility.IconContent("TreeEditor.Leaf On");

		private static GUIContent _treeeditorleaf;
		/// <summary>
		/// TreeEditor.Leaf
		/// </summary>
		public static GUIContent TreeeditorLeaf => _treeeditorleaf ??= EditorGUIUtility.IconContent("TreeEditor.Leaf");

		private static GUIContent _treeeditorleaffreehandon;
		/// <summary>
		/// TreeEditor.LeafFreeHand On
		/// </summary>
		public static GUIContent TreeeditorLeaffreehandOn => _treeeditorleaffreehandon ??= EditorGUIUtility.IconContent("TreeEditor.LeafFreeHand On");

		private static GUIContent _treeeditorleaffreehand;
		/// <summary>
		/// TreeEditor.LeafFreeHand
		/// </summary>
		public static GUIContent TreeeditorLeaffreehand => _treeeditorleaffreehand ??= EditorGUIUtility.IconContent("TreeEditor.LeafFreeHand");

		private static GUIContent _treeeditorleafrotateon;
		/// <summary>
		/// TreeEditor.LeafRotate On
		/// </summary>
		public static GUIContent TreeeditorLeafrotateOn => _treeeditorleafrotateon ??= EditorGUIUtility.IconContent("TreeEditor.LeafRotate On");

		private static GUIContent _treeeditorleafrotate;
		/// <summary>
		/// TreeEditor.LeafRotate
		/// </summary>
		public static GUIContent TreeeditorLeafrotate => _treeeditorleafrotate ??= EditorGUIUtility.IconContent("TreeEditor.LeafRotate");

		private static GUIContent _treeeditorleafscaleon;
		/// <summary>
		/// TreeEditor.LeafScale On
		/// </summary>
		public static GUIContent TreeeditorLeafscaleOn => _treeeditorleafscaleon ??= EditorGUIUtility.IconContent("TreeEditor.LeafScale On");

		private static GUIContent _treeeditorleafscale;
		/// <summary>
		/// TreeEditor.LeafScale
		/// </summary>
		public static GUIContent TreeeditorLeafscale => _treeeditorleafscale ??= EditorGUIUtility.IconContent("TreeEditor.LeafScale");

		private static GUIContent _treeeditorleaftranslateon;
		/// <summary>
		/// TreeEditor.LeafTranslate On
		/// </summary>
		public static GUIContent TreeeditorLeaftranslateOn => _treeeditorleaftranslateon ??= EditorGUIUtility.IconContent("TreeEditor.LeafTranslate On");

		private static GUIContent _treeeditorleaftranslate;
		/// <summary>
		/// TreeEditor.LeafTranslate
		/// </summary>
		public static GUIContent TreeeditorLeaftranslate => _treeeditorleaftranslate ??= EditorGUIUtility.IconContent("TreeEditor.LeafTranslate");

		private static GUIContent _treeeditormaterialon;
		/// <summary>
		/// TreeEditor.Material On
		/// </summary>
		public static GUIContent TreeeditorMaterialOn => _treeeditormaterialon ??= EditorGUIUtility.IconContent("TreeEditor.Material On");

		private static GUIContent _treeeditormaterial;
		/// <summary>
		/// TreeEditor.Material
		/// </summary>
		public static GUIContent TreeeditorMaterial => _treeeditormaterial ??= EditorGUIUtility.IconContent("TreeEditor.Material");

		private static GUIContent _treeeditorrefresh;
		/// <summary>
		/// TreeEditor.Refresh
		/// </summary>
		public static GUIContent TreeeditorRefresh => _treeeditorrefresh ??= EditorGUIUtility.IconContent("TreeEditor.Refresh");

		private static GUIContent _treeeditortrash;
		/// <summary>
		/// TreeEditor.Trash
		/// </summary>
		public static GUIContent TreeeditorTrash => _treeeditortrash ??= EditorGUIUtility.IconContent("TreeEditor.Trash");

		private static GUIContent _treeeditorwindon;
		/// <summary>
		/// TreeEditor.Wind On
		/// </summary>
		public static GUIContent TreeeditorWindOn => _treeeditorwindon ??= EditorGUIUtility.IconContent("TreeEditor.Wind On");

		private static GUIContent _treeeditorwind;
		/// <summary>
		/// TreeEditor.Wind
		/// </summary>
		public static GUIContent TreeeditorWind => _treeeditorwind ??= EditorGUIUtility.IconContent("TreeEditor.Wind");

		private static GUIContent _unityeditoranimationwindow;
		/// <summary>
		/// UnityEditor.AnimationWindow
		/// </summary>
		public static GUIContent UnityeditorAnimationwindow => _unityeditoranimationwindow ??= EditorGUIUtility.IconContent("UnityEditor.AnimationWindow");

		private static GUIContent _unityeditoranimationwindow2X;
		/// <summary>
		/// UnityEditor.AnimationWindow@2x
		/// </summary>
		public static GUIContent UnityeditorAnimationwindow2X => _unityeditoranimationwindow2X ??= EditorGUIUtility.IconContent("UnityEditor.AnimationWindow@2x");

		private static GUIContent _unityeditorconsolewindow;
		/// <summary>
		/// UnityEditor.ConsoleWindow
		/// </summary>
		public static GUIContent UnityeditorConsolewindow => _unityeditorconsolewindow ??= EditorGUIUtility.IconContent("UnityEditor.ConsoleWindow");

		private static GUIContent _unityeditorconsolewindow2X;
		/// <summary>
		/// UnityEditor.ConsoleWindow@2x
		/// </summary>
		public static GUIContent UnityeditorConsolewindow2X => _unityeditorconsolewindow2X ??= EditorGUIUtility.IconContent("UnityEditor.ConsoleWindow@2x");

		private static GUIContent _unityeditordebuginspectorwindow;
		/// <summary>
		/// UnityEditor.DebugInspectorWindow
		/// </summary>
		public static GUIContent UnityeditorDebuginspectorwindow => _unityeditordebuginspectorwindow ??= EditorGUIUtility.IconContent("UnityEditor.DebugInspectorWindow");

		private static GUIContent _unityeditorfinddependencies;
		/// <summary>
		/// UnityEditor.FindDependencies
		/// </summary>
		public static GUIContent UnityeditorFinddependencies => _unityeditorfinddependencies ??= EditorGUIUtility.IconContent("UnityEditor.FindDependencies");

		private static GUIContent _unityeditorgameview;
		/// <summary>
		/// UnityEditor.GameView
		/// </summary>
		public static GUIContent UnityeditorGameview => _unityeditorgameview ??= EditorGUIUtility.IconContent("UnityEditor.GameView");

		private static GUIContent _unityeditorgameview2X;
		/// <summary>
		/// UnityEditor.GameView@2x
		/// </summary>
		public static GUIContent UnityeditorGameview2X => _unityeditorgameview2X ??= EditorGUIUtility.IconContent("UnityEditor.GameView@2x");

		private static GUIContent _unityeditorgraphsanimatorcontrollertool;
		/// <summary>
		/// UnityEditor.Graphs.AnimatorControllerTool
		/// </summary>
		public static GUIContent UnityeditorGraphsAnimatorcontrollertool => _unityeditorgraphsanimatorcontrollertool ??= EditorGUIUtility.IconContent("UnityEditor.Graphs.AnimatorControllerTool");

		private static GUIContent _unityeditorgraphsanimatorcontrollertool2X;
		/// <summary>
		/// UnityEditor.Graphs.AnimatorControllerTool@2x
		/// </summary>
		public static GUIContent UnityeditorGraphsAnimatorcontrollertool2X => _unityeditorgraphsanimatorcontrollertool2X ??= EditorGUIUtility.IconContent("UnityEditor.Graphs.AnimatorControllerTool@2x");

		private static GUIContent _unityeditorhierarchywindow;
		/// <summary>
		/// UnityEditor.HierarchyWindow
		/// </summary>
		public static GUIContent UnityeditorHierarchywindow => _unityeditorhierarchywindow ??= EditorGUIUtility.IconContent("UnityEditor.HierarchyWindow");

		private static GUIContent _unityeditorhierarchywindow2X;
		/// <summary>
		/// UnityEditor.HierarchyWindow@2x
		/// </summary>
		public static GUIContent UnityeditorHierarchywindow2X => _unityeditorhierarchywindow2X ??= EditorGUIUtility.IconContent("UnityEditor.HierarchyWindow@2x");

		private static GUIContent _unityeditorinspectorwindow;
		/// <summary>
		/// UnityEditor.InspectorWindow
		/// </summary>
		public static GUIContent UnityeditorInspectorwindow => _unityeditorinspectorwindow ??= EditorGUIUtility.IconContent("UnityEditor.InspectorWindow");

		private static GUIContent _unityeditorinspectorwindow2X;
		/// <summary>
		/// UnityEditor.InspectorWindow@2x
		/// </summary>
		public static GUIContent UnityeditorInspectorwindow2X => _unityeditorinspectorwindow2X ??= EditorGUIUtility.IconContent("UnityEditor.InspectorWindow@2x");

		private static GUIContent _unityeditorprofilerwindow;
		/// <summary>
		/// UnityEditor.ProfilerWindow
		/// </summary>
		public static GUIContent UnityeditorProfilerwindow => _unityeditorprofilerwindow ??= EditorGUIUtility.IconContent("UnityEditor.ProfilerWindow");

		private static GUIContent _unityeditorprofilerwindow2X;
		/// <summary>
		/// UnityEditor.ProfilerWindow@2x
		/// </summary>
		public static GUIContent UnityeditorProfilerwindow2X => _unityeditorprofilerwindow2X ??= EditorGUIUtility.IconContent("UnityEditor.ProfilerWindow@2x");

		private static GUIContent _unityeditorscenehierarchywindow;
		/// <summary>
		/// UnityEditor.SceneHierarchyWindow
		/// </summary>
		public static GUIContent UnityeditorScenehierarchywindow => _unityeditorscenehierarchywindow ??= EditorGUIUtility.IconContent("UnityEditor.SceneHierarchyWindow");

		private static GUIContent _unityeditorscenehierarchywindow2X;
		/// <summary>
		/// UnityEditor.SceneHierarchyWindow@2x
		/// </summary>
		public static GUIContent UnityeditorScenehierarchywindow2X => _unityeditorscenehierarchywindow2X ??= EditorGUIUtility.IconContent("UnityEditor.SceneHierarchyWindow@2x");

		private static GUIContent _unityeditorsceneview;
		/// <summary>
		/// UnityEditor.SceneView
		/// </summary>
		public static GUIContent UnityeditorSceneview => _unityeditorsceneview ??= EditorGUIUtility.IconContent("UnityEditor.SceneView");

		private static GUIContent _unityeditorsceneview2X;
		/// <summary>
		/// UnityEditor.SceneView@2x
		/// </summary>
		public static GUIContent UnityeditorSceneview2X => _unityeditorsceneview2X ??= EditorGUIUtility.IconContent("UnityEditor.SceneView@2x");

		private static GUIContent _unityeditortimelinetimelinewindow;
		/// <summary>
		/// UnityEditor.Timeline.TimelineWindow
		/// </summary>
		public static GUIContent UnityeditorTimelineTimelinewindow => _unityeditortimelinetimelinewindow ??= EditorGUIUtility.IconContent("UnityEditor.Timeline.TimelineWindow");

		private static GUIContent _unityeditortimelinetimelinewindow2X;
		/// <summary>
		/// UnityEditor.Timeline.TimelineWindow@2x
		/// </summary>
		public static GUIContent UnityeditorTimelineTimelinewindow2X => _unityeditortimelinetimelinewindow2X ??= EditorGUIUtility.IconContent("UnityEditor.Timeline.TimelineWindow@2x");

		private static GUIContent _unityeditorversioncontrol;
		/// <summary>
		/// UnityEditor.VersionControl
		/// </summary>
		public static GUIContent UnityeditorVersioncontrol => _unityeditorversioncontrol ??= EditorGUIUtility.IconContent("UnityEditor.VersionControl");

		private static GUIContent _unitylogo;
		/// <summary>
		/// UnityLogo
		/// </summary>
		public static GUIContent Unitylogo => _unitylogo ??= EditorGUIUtility.IconContent("UnityLogo");

		private static GUIContent _unitylogolarge;
		/// <summary>
		/// UnityLogoLarge
		/// </summary>
		public static GUIContent Unitylogolarge => _unitylogolarge ??= EditorGUIUtility.IconContent("UnityLogoLarge");

		private static GUIContent _unlinked;
		/// <summary>
		/// UnLinked
		/// </summary>
		public static GUIContent Unlinked => _unlinked ??= EditorGUIUtility.IconContent("UnLinked");

		private static GUIContent _unlinked2X;
		/// <summary>
		/// UnLinked@2x
		/// </summary>
		public static GUIContent Unlinked2X => _unlinked2X ??= EditorGUIUtility.IconContent("UnLinked@2x");

		private static GUIContent _uparrow;
		/// <summary>
		/// UpArrow
		/// </summary>
		public static GUIContent Uparrow => _uparrow ??= EditorGUIUtility.IconContent("UpArrow");

		private static GUIContent _valid;
		/// <summary>
		/// Valid
		/// </summary>
		public static GUIContent Valid => _valid ??= EditorGUIUtility.IconContent("Valid");

		private static GUIContent _valid2X;
		/// <summary>
		/// Valid@2x
		/// </summary>
		public static GUIContent Valid2X => _valid2X ??= EditorGUIUtility.IconContent("Valid@2x");

		private static GUIContent _vcschange;
		/// <summary>
		/// vcs_change
		/// </summary>
		public static GUIContent VcsChange => _vcschange ??= EditorGUIUtility.IconContent("vcs_change");

		private static GUIContent _vcsdocument;
		/// <summary>
		/// vcs_document
		/// </summary>
		public static GUIContent VcsDocument => _vcsdocument ??= EditorGUIUtility.IconContent("vcs_document");

		private static GUIContent _vcsincoming;
		/// <summary>
		/// vcs_incoming
		/// </summary>
		public static GUIContent VcsIncoming => _vcsincoming ??= EditorGUIUtility.IconContent("vcs_incoming");

		private static GUIContent _p4Addedlocal;
		/// <summary>
		/// P4_AddedLocal
		/// </summary>
		public static GUIContent P4Addedlocal => _p4Addedlocal ??= EditorGUIUtility.IconContent("P4_AddedLocal");

		private static GUIContent _p4Addedlocal2X;
		/// <summary>
		/// P4_AddedLocal@2x
		/// </summary>
		public static GUIContent P4Addedlocal2X => _p4Addedlocal2X ??= EditorGUIUtility.IconContent("P4_AddedLocal@2x");

		private static GUIContent _p4Addedremote;
		/// <summary>
		/// P4_AddedRemote
		/// </summary>
		public static GUIContent P4Addedremote => _p4Addedremote ??= EditorGUIUtility.IconContent("P4_AddedRemote");

		private static GUIContent _p4Addedremote2X;
		/// <summary>
		/// P4_AddedRemote@2x
		/// </summary>
		public static GUIContent P4Addedremote2X => _p4Addedremote2X ??= EditorGUIUtility.IconContent("P4_AddedRemote@2x");

		private static GUIContent _p4Blueleftparenthesis;
		/// <summary>
		/// P4_BlueLeftParenthesis
		/// </summary>
		public static GUIContent P4Blueleftparenthesis => _p4Blueleftparenthesis ??= EditorGUIUtility.IconContent("P4_BlueLeftParenthesis");

		private static GUIContent _p4Blueleftparenthesis2X;
		/// <summary>
		/// P4_BlueLeftParenthesis@2x
		/// </summary>
		public static GUIContent P4Blueleftparenthesis2X => _p4Blueleftparenthesis2X ??= EditorGUIUtility.IconContent("P4_BlueLeftParenthesis@2x");

		private static GUIContent _p4Bluerightparenthesis;
		/// <summary>
		/// P4_BlueRightParenthesis
		/// </summary>
		public static GUIContent P4Bluerightparenthesis => _p4Bluerightparenthesis ??= EditorGUIUtility.IconContent("P4_BlueRightParenthesis");

		private static GUIContent _p4Bluerightparenthesis2X;
		/// <summary>
		/// P4_BlueRightParenthesis@2x
		/// </summary>
		public static GUIContent P4Bluerightparenthesis2X => _p4Bluerightparenthesis2X ??= EditorGUIUtility.IconContent("P4_BlueRightParenthesis@2x");

		private static GUIContent _p4Checkoutlocal;
		/// <summary>
		/// P4_CheckOutLocal
		/// </summary>
		public static GUIContent P4Checkoutlocal => _p4Checkoutlocal ??= EditorGUIUtility.IconContent("P4_CheckOutLocal");

		private static GUIContent _p4Checkoutlocal2X;
		/// <summary>
		/// P4_CheckOutLocal@2x
		/// </summary>
		public static GUIContent P4Checkoutlocal2X => _p4Checkoutlocal2X ??= EditorGUIUtility.IconContent("P4_CheckOutLocal@2x");

		private static GUIContent _p4Checkoutremote;
		/// <summary>
		/// P4_CheckOutRemote
		/// </summary>
		public static GUIContent P4Checkoutremote => _p4Checkoutremote ??= EditorGUIUtility.IconContent("P4_CheckOutRemote");

		private static GUIContent _p4Checkoutremote2X;
		/// <summary>
		/// P4_CheckOutRemote@2x
		/// </summary>
		public static GUIContent P4Checkoutremote2X => _p4Checkoutremote2X ??= EditorGUIUtility.IconContent("P4_CheckOutRemote@2x");

		private static GUIContent _p4Conflicted;
		/// <summary>
		/// P4_Conflicted
		/// </summary>
		public static GUIContent P4Conflicted => _p4Conflicted ??= EditorGUIUtility.IconContent("P4_Conflicted");

		private static GUIContent _p4Conflicted2X;
		/// <summary>
		/// P4_Conflicted@2x
		/// </summary>
		public static GUIContent P4Conflicted2X => _p4Conflicted2X ??= EditorGUIUtility.IconContent("P4_Conflicted@2x");

		private static GUIContent _p4deletedlocal;
		/// <summary>
		/// P4_DeletedLocal
		/// </summary>
		public static GUIContent P4Deletedlocal => _p4deletedlocal ??= EditorGUIUtility.IconContent("P4_DeletedLocal");

		private static GUIContent _p4deletedlocal2X;
		/// <summary>
		/// P4_DeletedLocal@2x
		/// </summary>
		public static GUIContent P4Deletedlocal2X => _p4deletedlocal2X ??= EditorGUIUtility.IconContent("P4_DeletedLocal@2x");

		private static GUIContent _p4deletedremote;
		/// <summary>
		/// P4_DeletedRemote
		/// </summary>
		public static GUIContent P4Deletedremote => _p4deletedremote ??= EditorGUIUtility.IconContent("P4_DeletedRemote");

		private static GUIContent _p4deletedremote2X;
		/// <summary>
		/// P4_DeletedRemote@2x
		/// </summary>
		public static GUIContent P4Deletedremote2X => _p4deletedremote2X ??= EditorGUIUtility.IconContent("P4_DeletedRemote@2x");

		private static GUIContent _p4Local;
		/// <summary>
		/// P4_Local
		/// </summary>
		public static GUIContent P4Local => _p4Local ??= EditorGUIUtility.IconContent("P4_Local");

		private static GUIContent _p4Local2X;
		/// <summary>
		/// P4_Local@2x
		/// </summary>
		public static GUIContent P4Local2X => _p4Local2X ??= EditorGUIUtility.IconContent("P4_Local@2x");

		private static GUIContent _p4Lockedlocal;
		/// <summary>
		/// P4_LockedLocal
		/// </summary>
		public static GUIContent P4Lockedlocal => _p4Lockedlocal ??= EditorGUIUtility.IconContent("P4_LockedLocal");

		private static GUIContent _p4Lockedlocal2X;
		/// <summary>
		/// P4_LockedLocal@2x
		/// </summary>
		public static GUIContent P4Lockedlocal2X => _p4Lockedlocal2X ??= EditorGUIUtility.IconContent("P4_LockedLocal@2x");

		private static GUIContent _p4Lockedremote;
		/// <summary>
		/// P4_LockedRemote
		/// </summary>
		public static GUIContent P4Lockedremote => _p4Lockedremote ??= EditorGUIUtility.IconContent("P4_LockedRemote");

		private static GUIContent _p4Lockedremote2X;
		/// <summary>
		/// P4_LockedRemote@2x
		/// </summary>
		public static GUIContent P4Lockedremote2X => _p4Lockedremote2X ??= EditorGUIUtility.IconContent("P4_LockedRemote@2x");

		private static GUIContent _p4Outofsync;
		/// <summary>
		/// P4_OutOfSync
		/// </summary>
		public static GUIContent P4Outofsync => _p4Outofsync ??= EditorGUIUtility.IconContent("P4_OutOfSync");

		private static GUIContent _p4Outofsync2X;
		/// <summary>
		/// P4_OutOfSync@2x
		/// </summary>
		public static GUIContent P4Outofsync2X => _p4Outofsync2X ??= EditorGUIUtility.IconContent("P4_OutOfSync@2x");

		private static GUIContent _p4Redleftparenthesis;
		/// <summary>
		/// P4_RedLeftParenthesis
		/// </summary>
		public static GUIContent P4Redleftparenthesis => _p4Redleftparenthesis ??= EditorGUIUtility.IconContent("P4_RedLeftParenthesis");

		private static GUIContent _p4Redleftparenthesis2X;
		/// <summary>
		/// P4_RedLeftParenthesis@2x
		/// </summary>
		public static GUIContent P4Redleftparenthesis2X => _p4Redleftparenthesis2X ??= EditorGUIUtility.IconContent("P4_RedLeftParenthesis@2x");

		private static GUIContent _p4Redrightparenthesis;
		/// <summary>
		/// P4_RedRightParenthesis
		/// </summary>
		public static GUIContent P4Redrightparenthesis => _p4Redrightparenthesis ??= EditorGUIUtility.IconContent("P4_RedRightParenthesis");

		private static GUIContent _p4Redrightparenthesis2X;
		/// <summary>
		/// P4_RedRightParenthesis@2x
		/// </summary>
		public static GUIContent P4Redrightparenthesis2X => _p4Redrightparenthesis2X ??= EditorGUIUtility.IconContent("P4_RedRightParenthesis@2x");

		private static GUIContent _p4Updating;
		/// <summary>
		/// P4_Updating
		/// </summary>
		public static GUIContent P4Updating => _p4Updating ??= EditorGUIUtility.IconContent("P4_Updating");

		private static GUIContent _p4Updating2X;
		/// <summary>
		/// P4_Updating@2x
		/// </summary>
		public static GUIContent P4Updating2X => _p4Updating2X ??= EditorGUIUtility.IconContent("P4_Updating@2x");

		private static GUIContent _verticalsplit;
		/// <summary>
		/// VerticalSplit
		/// </summary>
		public static GUIContent Verticalsplit => _verticalsplit ??= EditorGUIUtility.IconContent("VerticalSplit");

		private static GUIContent _viewtoolmoveon;
		/// <summary>
		/// ViewToolMove On
		/// </summary>
		public static GUIContent ViewtoolmoveOn => _viewtoolmoveon ??= EditorGUIUtility.IconContent("ViewToolMove On");

		private static GUIContent _viewtoolmoveon2X;
		/// <summary>
		/// ViewToolMove On@2x
		/// </summary>
		public static GUIContent ViewtoolmoveOn2X => _viewtoolmoveon2X ??= EditorGUIUtility.IconContent("ViewToolMove On@2x");

		private static GUIContent _viewtoolmove;
		/// <summary>
		/// ViewToolMove
		/// </summary>
		public static GUIContent Viewtoolmove => _viewtoolmove ??= EditorGUIUtility.IconContent("ViewToolMove");

		private static GUIContent _viewtoolmove2X;
		/// <summary>
		/// ViewToolMove@2x
		/// </summary>
		public static GUIContent Viewtoolmove2X => _viewtoolmove2X ??= EditorGUIUtility.IconContent("ViewToolMove@2x");

		private static GUIContent _viewtoolorbiton;
		/// <summary>
		/// ViewToolOrbit On
		/// </summary>
		public static GUIContent ViewtoolorbitOn => _viewtoolorbiton ??= EditorGUIUtility.IconContent("ViewToolOrbit On");

		private static GUIContent _viewtoolorbiton2X;
		/// <summary>
		/// ViewToolOrbit On@2x
		/// </summary>
		public static GUIContent ViewtoolorbitOn2X => _viewtoolorbiton2X ??= EditorGUIUtility.IconContent("ViewToolOrbit On@2x");

		private static GUIContent _viewtoolorbit;
		/// <summary>
		/// ViewToolOrbit
		/// </summary>
		public static GUIContent Viewtoolorbit => _viewtoolorbit ??= EditorGUIUtility.IconContent("ViewToolOrbit");

		private static GUIContent _viewtoolorbit2X;
		/// <summary>
		/// ViewToolOrbit@2x
		/// </summary>
		public static GUIContent Viewtoolorbit2X => _viewtoolorbit2X ??= EditorGUIUtility.IconContent("ViewToolOrbit@2x");

		private static GUIContent _viewtoolzoomon;
		/// <summary>
		/// ViewToolZoom On
		/// </summary>
		public static GUIContent ViewtoolzoomOn => _viewtoolzoomon ??= EditorGUIUtility.IconContent("ViewToolZoom On");

		private static GUIContent _viewtoolzoomon2X;
		/// <summary>
		/// ViewToolZoom On@2x
		/// </summary>
		public static GUIContent ViewtoolzoomOn2X => _viewtoolzoomon2X ??= EditorGUIUtility.IconContent("ViewToolZoom On@2x");

		private static GUIContent _viewtoolzoom;
		/// <summary>
		/// ViewToolZoom
		/// </summary>
		public static GUIContent Viewtoolzoom => _viewtoolzoom ??= EditorGUIUtility.IconContent("ViewToolZoom");

		private static GUIContent _viewtoolzoom2X;
		/// <summary>
		/// ViewToolZoom@2x
		/// </summary>
		public static GUIContent Viewtoolzoom2X => _viewtoolzoom2X ??= EditorGUIUtility.IconContent("ViewToolZoom@2x");

		private static GUIContent _visibilityoff;
		/// <summary>
		/// VisibilityOff
		/// </summary>
		public static GUIContent Visibilityoff => _visibilityoff ??= EditorGUIUtility.IconContent("VisibilityOff");

		private static GUIContent _visibilityon;
		/// <summary>
		/// VisibilityOn
		/// </summary>
		public static GUIContent Visibilityon => _visibilityon ??= EditorGUIUtility.IconContent("VisibilityOn");

		private static GUIContent _vumetertexturehorizontal;
		/// <summary>
		/// VUMeterTextureHorizontal
		/// </summary>
		public static GUIContent Vumetertexturehorizontal => _vumetertexturehorizontal ??= EditorGUIUtility.IconContent("VUMeterTextureHorizontal");

		private static GUIContent _vumetertexturevertical;
		/// <summary>
		/// VUMeterTextureVertical
		/// </summary>
		public static GUIContent Vumetertexturevertical => _vumetertexturevertical ??= EditorGUIUtility.IconContent("VUMeterTextureVertical");

		private static GUIContent _waitspin00;
		/// <summary>
		/// WaitSpin00
		/// </summary>
		public static GUIContent Waitspin00 => _waitspin00 ??= EditorGUIUtility.IconContent("WaitSpin00");

		private static GUIContent _waitspin01;
		/// <summary>
		/// WaitSpin01
		/// </summary>
		public static GUIContent Waitspin01 => _waitspin01 ??= EditorGUIUtility.IconContent("WaitSpin01");

		private static GUIContent _waitspin02;
		/// <summary>
		/// WaitSpin02
		/// </summary>
		public static GUIContent Waitspin02 => _waitspin02 ??= EditorGUIUtility.IconContent("WaitSpin02");

		private static GUIContent _waitspin03;
		/// <summary>
		/// WaitSpin03
		/// </summary>
		public static GUIContent Waitspin03 => _waitspin03 ??= EditorGUIUtility.IconContent("WaitSpin03");

		private static GUIContent _waitspin04;
		/// <summary>
		/// WaitSpin04
		/// </summary>
		public static GUIContent Waitspin04 => _waitspin04 ??= EditorGUIUtility.IconContent("WaitSpin04");

		private static GUIContent _waitspin05;
		/// <summary>
		/// WaitSpin05
		/// </summary>
		public static GUIContent Waitspin05 => _waitspin05 ??= EditorGUIUtility.IconContent("WaitSpin05");

		private static GUIContent _waitspin06;
		/// <summary>
		/// WaitSpin06
		/// </summary>
		public static GUIContent Waitspin06 => _waitspin06 ??= EditorGUIUtility.IconContent("WaitSpin06");

		private static GUIContent _waitspin07;
		/// <summary>
		/// WaitSpin07
		/// </summary>
		public static GUIContent Waitspin07 => _waitspin07 ??= EditorGUIUtility.IconContent("WaitSpin07");

		private static GUIContent _waitspin08;
		/// <summary>
		/// WaitSpin08
		/// </summary>
		public static GUIContent Waitspin08 => _waitspin08 ??= EditorGUIUtility.IconContent("WaitSpin08");

		private static GUIContent _waitspin09;
		/// <summary>
		/// WaitSpin09
		/// </summary>
		public static GUIContent Waitspin09 => _waitspin09 ??= EditorGUIUtility.IconContent("WaitSpin09");

		private static GUIContent _waitspin10;
		/// <summary>
		/// WaitSpin10
		/// </summary>
		public static GUIContent Waitspin10 => _waitspin10 ??= EditorGUIUtility.IconContent("WaitSpin10");

		private static GUIContent _waitspin11;
		/// <summary>
		/// WaitSpin11
		/// </summary>
		public static GUIContent Waitspin11 => _waitspin11 ??= EditorGUIUtility.IconContent("WaitSpin11");

		private static GUIContent _welcomescreenassetstorelogo;
		/// <summary>
		/// WelcomeScreen.AssetStoreLogo
		/// </summary>
		public static GUIContent WelcomescreenAssetstorelogo => _welcomescreenassetstorelogo ??= EditorGUIUtility.IconContent("WelcomeScreen.AssetStoreLogo");

		private static GUIContent _winbtngraph;
		/// <summary>
		/// winbtn_graph
		/// </summary>
		public static GUIContent WinbtnGraph => _winbtngraph ??= EditorGUIUtility.IconContent("winbtn_graph");

		private static GUIContent _winbtngraphcloseh;
		/// <summary>
		/// winbtn_graph_close_h
		/// </summary>
		public static GUIContent WinbtnGraphCloseH => _winbtngraphcloseh ??= EditorGUIUtility.IconContent("winbtn_graph_close_h");

		private static GUIContent _winbtngraphmaxh;
		/// <summary>
		/// winbtn_graph_max_h
		/// </summary>
		public static GUIContent WinbtnGraphMaxH => _winbtngraphmaxh ??= EditorGUIUtility.IconContent("winbtn_graph_max_h");

		private static GUIContent _winbtngraphminh;
		/// <summary>
		/// winbtn_graph_min_h
		/// </summary>
		public static GUIContent WinbtnGraphMinH => _winbtngraphminh ??= EditorGUIUtility.IconContent("winbtn_graph_min_h");

		private static GUIContent _winbtnmacclose;
		/// <summary>
		/// winbtn_mac_close
		/// </summary>
		public static GUIContent WinbtnMacClose => _winbtnmacclose ??= EditorGUIUtility.IconContent("winbtn_mac_close");

		private static GUIContent _winbtnmacclose2X;
		/// <summary>
		/// winbtn_mac_close@2x
		/// </summary>
		public static GUIContent WinbtnMacClose2X => _winbtnmacclose2X ??= EditorGUIUtility.IconContent("winbtn_mac_close@2x");

		private static GUIContent _winbtnmacclosea;
		/// <summary>
		/// winbtn_mac_close_a
		/// </summary>
		public static GUIContent WinbtnMacCloseA => _winbtnmacclosea ??= EditorGUIUtility.IconContent("winbtn_mac_close_a");

		private static GUIContent _winbtnmacclosea2X;
		/// <summary>
		/// winbtn_mac_close_a@2x
		/// </summary>
		public static GUIContent WinbtnMacCloseA2X => _winbtnmacclosea2X ??= EditorGUIUtility.IconContent("winbtn_mac_close_a@2x");

		private static GUIContent _winbtnmaccloseh;
		/// <summary>
		/// winbtn_mac_close_h
		/// </summary>
		public static GUIContent WinbtnMacCloseH => _winbtnmaccloseh ??= EditorGUIUtility.IconContent("winbtn_mac_close_h");

		private static GUIContent _winbtnmaccloseh2X;
		/// <summary>
		/// winbtn_mac_close_h@2x
		/// </summary>
		public static GUIContent WinbtnMacCloseH2X => _winbtnmaccloseh2X ??= EditorGUIUtility.IconContent("winbtn_mac_close_h@2x");

		private static GUIContent _winbtnmacinact;
		/// <summary>
		/// winbtn_mac_inact
		/// </summary>
		public static GUIContent WinbtnMacInact => _winbtnmacinact ??= EditorGUIUtility.IconContent("winbtn_mac_inact");

		private static GUIContent _winbtnmacinact2X;
		/// <summary>
		/// winbtn_mac_inact@2x
		/// </summary>
		public static GUIContent WinbtnMacInact2X => _winbtnmacinact2X ??= EditorGUIUtility.IconContent("winbtn_mac_inact@2x");

		private static GUIContent _winbtnmacmax;
		/// <summary>
		/// winbtn_mac_max
		/// </summary>
		public static GUIContent WinbtnMacMax => _winbtnmacmax ??= EditorGUIUtility.IconContent("winbtn_mac_max");

		private static GUIContent _winbtnmacmax2X;
		/// <summary>
		/// winbtn_mac_max@2x
		/// </summary>
		public static GUIContent WinbtnMacMax2X => _winbtnmacmax2X ??= EditorGUIUtility.IconContent("winbtn_mac_max@2x");

		private static GUIContent _winbtnmacmaxa;
		/// <summary>
		/// winbtn_mac_max_a
		/// </summary>
		public static GUIContent WinbtnMacMaxA => _winbtnmacmaxa ??= EditorGUIUtility.IconContent("winbtn_mac_max_a");

		private static GUIContent _winbtnmacmaxa2X;
		/// <summary>
		/// winbtn_mac_max_a@2x
		/// </summary>
		public static GUIContent WinbtnMacMaxA2X => _winbtnmacmaxa2X ??= EditorGUIUtility.IconContent("winbtn_mac_max_a@2x");

		private static GUIContent _winbtnmacmaxh;
		/// <summary>
		/// winbtn_mac_max_h
		/// </summary>
		public static GUIContent WinbtnMacMaxH => _winbtnmacmaxh ??= EditorGUIUtility.IconContent("winbtn_mac_max_h");

		private static GUIContent _winbtnmacmaxh2X;
		/// <summary>
		/// winbtn_mac_max_h@2x
		/// </summary>
		public static GUIContent WinbtnMacMaxH2X => _winbtnmacmaxh2X ??= EditorGUIUtility.IconContent("winbtn_mac_max_h@2x");

		private static GUIContent _winbtnmacmin;
		/// <summary>
		/// winbtn_mac_min
		/// </summary>
		public static GUIContent WinbtnMacMin => _winbtnmacmin ??= EditorGUIUtility.IconContent("winbtn_mac_min");

		private static GUIContent _winbtnmacmin2X;
		/// <summary>
		/// winbtn_mac_min@2x
		/// </summary>
		public static GUIContent WinbtnMacMin2X => _winbtnmacmin2X ??= EditorGUIUtility.IconContent("winbtn_mac_min@2x");

		private static GUIContent _winbtnmacmina;
		/// <summary>
		/// winbtn_mac_min_a
		/// </summary>
		public static GUIContent WinbtnMacMinA => _winbtnmacmina ??= EditorGUIUtility.IconContent("winbtn_mac_min_a");

		private static GUIContent _winbtnmacmina2X;
		/// <summary>
		/// winbtn_mac_min_a@2x
		/// </summary>
		public static GUIContent WinbtnMacMinA2X => _winbtnmacmina2X ??= EditorGUIUtility.IconContent("winbtn_mac_min_a@2x");

		private static GUIContent _winbtnmacminh;
		/// <summary>
		/// winbtn_mac_min_h
		/// </summary>
		public static GUIContent WinbtnMacMinH => _winbtnmacminh ??= EditorGUIUtility.IconContent("winbtn_mac_min_h");

		private static GUIContent _winbtnmacminh2X;
		/// <summary>
		/// winbtn_mac_min_h@2x
		/// </summary>
		public static GUIContent WinbtnMacMinH2X => _winbtnmacminh2X ??= EditorGUIUtility.IconContent("winbtn_mac_min_h@2x");

		private static GUIContent _winbtnwinclose;
		/// <summary>
		/// winbtn_win_close
		/// </summary>
		public static GUIContent WinbtnWinClose => _winbtnwinclose ??= EditorGUIUtility.IconContent("winbtn_win_close");

		private static GUIContent _winbtnwinclose2X;
		/// <summary>
		/// winbtn_win_close@2x
		/// </summary>
		public static GUIContent WinbtnWinClose2X => _winbtnwinclose2X ??= EditorGUIUtility.IconContent("winbtn_win_close@2x");

		private static GUIContent _winbtnwinclosea;
		/// <summary>
		/// winbtn_win_close_a
		/// </summary>
		public static GUIContent WinbtnWinCloseA => _winbtnwinclosea ??= EditorGUIUtility.IconContent("winbtn_win_close_a");

		private static GUIContent _winbtnwinclosea2X;
		/// <summary>
		/// winbtn_win_close_a@2x
		/// </summary>
		public static GUIContent WinbtnWinCloseA2X => _winbtnwinclosea2X ??= EditorGUIUtility.IconContent("winbtn_win_close_a@2x");

		private static GUIContent _winbtnwincloseh;
		/// <summary>
		/// winbtn_win_close_h
		/// </summary>
		public static GUIContent WinbtnWinCloseH => _winbtnwincloseh ??= EditorGUIUtility.IconContent("winbtn_win_close_h");

		private static GUIContent _winbtnwincloseh2X;
		/// <summary>
		/// winbtn_win_close_h@2x
		/// </summary>
		public static GUIContent WinbtnWinCloseH2X => _winbtnwincloseh2X ??= EditorGUIUtility.IconContent("winbtn_win_close_h@2x");

		private static GUIContent _winbtnwinmax;
		/// <summary>
		/// winbtn_win_max
		/// </summary>
		public static GUIContent WinbtnWinMax => _winbtnwinmax ??= EditorGUIUtility.IconContent("winbtn_win_max");

		private static GUIContent _winbtnwinmax2X;
		/// <summary>
		/// winbtn_win_max@2x
		/// </summary>
		public static GUIContent WinbtnWinMax2X => _winbtnwinmax2X ??= EditorGUIUtility.IconContent("winbtn_win_max@2x");

		private static GUIContent _winbtnwinmaxa;
		/// <summary>
		/// winbtn_win_max_a
		/// </summary>
		public static GUIContent WinbtnWinMaxA => _winbtnwinmaxa ??= EditorGUIUtility.IconContent("winbtn_win_max_a");

		private static GUIContent _winbtnwinmaxa2X;
		/// <summary>
		/// winbtn_win_max_a@2x
		/// </summary>
		public static GUIContent WinbtnWinMaxA2X => _winbtnwinmaxa2X ??= EditorGUIUtility.IconContent("winbtn_win_max_a@2x");

		private static GUIContent _winbtnwinmaxh;
		/// <summary>
		/// winbtn_win_max_h
		/// </summary>
		public static GUIContent WinbtnWinMaxH => _winbtnwinmaxh ??= EditorGUIUtility.IconContent("winbtn_win_max_h");

		private static GUIContent _winbtnwinmaxh2X;
		/// <summary>
		/// winbtn_win_max_h@2x
		/// </summary>
		public static GUIContent WinbtnWinMaxH2X => _winbtnwinmaxh2X ??= EditorGUIUtility.IconContent("winbtn_win_max_h@2x");

		private static GUIContent _winbtnwinmin;
		/// <summary>
		/// winbtn_win_min
		/// </summary>
		public static GUIContent WinbtnWinMin => _winbtnwinmin ??= EditorGUIUtility.IconContent("winbtn_win_min");

		private static GUIContent _winbtnwinmina;
		/// <summary>
		/// winbtn_win_min_a
		/// </summary>
		public static GUIContent WinbtnWinMinA => _winbtnwinmina ??= EditorGUIUtility.IconContent("winbtn_win_min_a");

		private static GUIContent _winbtnwinminh;
		/// <summary>
		/// winbtn_win_min_h
		/// </summary>
		public static GUIContent WinbtnWinMinH => _winbtnwinminh ??= EditorGUIUtility.IconContent("winbtn_win_min_h");

		private static GUIContent _winbtnwinrest;
		/// <summary>
		/// winbtn_win_rest
		/// </summary>
		public static GUIContent WinbtnWinRest => _winbtnwinrest ??= EditorGUIUtility.IconContent("winbtn_win_rest");

		private static GUIContent _winbtnwinresta;
		/// <summary>
		/// winbtn_win_rest_a
		/// </summary>
		public static GUIContent WinbtnWinRestA => _winbtnwinresta ??= EditorGUIUtility.IconContent("winbtn_win_rest_a");

		private static GUIContent _winbtnwinresth;
		/// <summary>
		/// winbtn_win_rest_h
		/// </summary>
		public static GUIContent WinbtnWinRestH => _winbtnwinresth ??= EditorGUIUtility.IconContent("winbtn_win_rest_h");

		private static GUIContent _winbtnwinrestore;
		/// <summary>
		/// winbtn_win_restore
		/// </summary>
		public static GUIContent WinbtnWinRestore => _winbtnwinrestore ??= EditorGUIUtility.IconContent("winbtn_win_restore");

		private static GUIContent _winbtnwinrestore2X;
		/// <summary>
		/// winbtn_win_restore@2x
		/// </summary>
		public static GUIContent WinbtnWinRestore2X => _winbtnwinrestore2X ??= EditorGUIUtility.IconContent("winbtn_win_restore@2x");

		private static GUIContent _winbtnwinrestorea;
		/// <summary>
		/// winbtn_win_restore_a
		/// </summary>
		public static GUIContent WinbtnWinRestoreA => _winbtnwinrestorea ??= EditorGUIUtility.IconContent("winbtn_win_restore_a");

		private static GUIContent _winbtnwinrestorea2X;
		/// <summary>
		/// winbtn_win_restore_a@2x
		/// </summary>
		public static GUIContent WinbtnWinRestoreA2X => _winbtnwinrestorea2X ??= EditorGUIUtility.IconContent("winbtn_win_restore_a@2x");

		private static GUIContent _winbtnwinrestoreh;
		/// <summary>
		/// winbtn_win_restore_h
		/// </summary>
		public static GUIContent WinbtnWinRestoreH => _winbtnwinrestoreh ??= EditorGUIUtility.IconContent("winbtn_win_restore_h");

		private static GUIContent _winbtnwinrestoreh2X;
		/// <summary>
		/// winbtn_win_restore_h@2x
		/// </summary>
		public static GUIContent WinbtnWinRestoreH2X => _winbtnwinrestoreh2X ??= EditorGUIUtility.IconContent("winbtn_win_restore_h@2x");
	}
}