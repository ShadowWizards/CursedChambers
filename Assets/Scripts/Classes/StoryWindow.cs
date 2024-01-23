using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Classes
{
    public class StoryWindow : MonoBehaviour
    {
        private GameObject _uiCanvas;
        private void Start()
        {
            _uiCanvas = GameObject.FindGameObjectWithTag("UI_Canvas");
        }

        public void InitializeStory(string messageText, System.Action actionOnClickToPlay)
        {
            GameObject storyUI = new GameObject("StoryUI");
            RectTransform dialogRectTransform = storyUI.AddComponent<RectTransform>();
            Image diagBg = storyUI.AddComponent<Image>();
            diagBg.color = new Color32(24, 24, 24, 255);
            
            dialogRectTransform.sizeDelta = new Vector2(1920, 1080);
            
            dialogRectTransform.localPosition = new Vector2
            {
                x = _uiCanvas.transform.position.x + 0,
                y = _uiCanvas.transform.position.y + 0
            };
            storyUI.transform.SetParent(_uiCanvas.transform);
            
            GameObject storyText = new GameObject("StoryText");
            storyText.transform.SetParent(storyUI.transform);
            RectTransform storyTextRectTransform = storyText.AddComponent<RectTransform>();
            storyTextRectTransform.sizeDelta = new Vector2(1684, 903);
            
            storyTextRectTransform.localPosition = new Vector2
            {
                x =  0,
                y = 69
            };
            
            TextMeshProUGUI tmpStoryText = storyText.AddComponent<TextMeshProUGUI>();
            tmpStoryText.text = messageText;
            tmpStoryText.horizontalAlignment = HorizontalAlignmentOptions.Center;
            tmpStoryText.verticalAlignment = VerticalAlignmentOptions.Middle;
            tmpStoryText.font = Resources.Load<TMP_FontAsset>("OptimusStoryFont");
            tmpStoryText.color = new Color32(234, 234, 234, 255);
            tmpStoryText.fontSize = 43;
            tmpStoryText.fontStyle = FontStyles.Bold;
            tmpStoryText.horizontalAlignment = HorizontalAlignmentOptions.Left;
            tmpStoryText.verticalAlignment = VerticalAlignmentOptions.Middle;
            tmpStoryText.characterSpacing = 10;
            tmpStoryText.lineSpacing = 56;
            
            
            GameObject continueText = new GameObject("ContinueText");
            continueText.transform.SetParent(storyUI.transform);
            RectTransform continueTextRectTransform = continueText.AddComponent<RectTransform>();
            continueTextRectTransform.sizeDelta = new Vector2(736, 736);
            
            continueTextRectTransform.localPosition = new Vector2
            {
                x =  0,
                y = -444
            };
            
            TextMeshProUGUI tmpContinueText = continueText.AddComponent<TextMeshProUGUI>();
            tmpContinueText.text = "Press anywhere on the screen to continue";
            tmpContinueText.horizontalAlignment = HorizontalAlignmentOptions.Center;
            tmpContinueText.verticalAlignment = VerticalAlignmentOptions.Middle;
            tmpContinueText.font = Resources.Load<TMP_FontAsset>("OptimusStoryFont");
            tmpContinueText.color = new Color32(185, 173, 123, 255);
            
            
            GameObject button = new GameObject("ClickToPlayButton");
            button.transform.SetParent(storyUI.transform);
            RectTransform ButtonRectTransform = button.AddComponent<RectTransform>();
            ButtonRectTransform.sizeDelta = new Vector2(1920,1080);
            ButtonRectTransform.localPosition = new Vector2
            {
                x = 0,
                y = 0
            };

            Button buttonComponent = button.AddComponent<Button>();
            buttonComponent.onClick.AddListener(delegate{onClickToPlay(actionOnClickToPlay);});
            Image buttonImage = button.AddComponent<Image>();
            buttonComponent.targetGraphic = buttonImage;
            buttonImage.color = new Color32(0, 0, 0, 0);
        }

        void onClickToPlay(Action onClickToPlay)
        {
            onClickToPlay();
        }
    }
}