using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Classes
{
    public class DialogWindow : MonoBehaviour
    {
        public GameObject closeButtonGameObject;
        public GameObject yesButtonGameObject;
        public GameObject noButtonGameObject;
        public GameObject titleGameObject;
        public GameObject messageGameObject;
        public GameObject dialogGameObject;
        public bool isOpen;
        public bool answer;
        
        private GameObject _uiCanvas;
        private DialogWindow _dialogWindowOnPlayer;
        private GameObject _playerObject;
        private void Start()
        {
            _playerObject = GameObject.FindGameObjectWithTag("Player");
            _uiCanvas = GameObject.FindGameObjectWithTag("UI_Canvas");
        }

        enum ButtonEnum
        {
            YesButton,
            NoButton,
            CloseButton
        }

        public DialogWindow InitializeDialog(string titleText,string messageText, System.Action actionOnYes, System.Action actionOnNo)
        {
            if (_dialogWindowOnPlayer != null &&_dialogWindowOnPlayer.isOpen)
            {
                return null;
            }
            DialogWindow dialogWindow = _playerObject.AddComponent<DialogWindow>();
            dialogWindow.isOpen = true;
            _dialogWindowOnPlayer = _playerObject.GetComponent<DialogWindow>();
            
            //Dialog Game Object
            
            GameObject yesNoDialog = new GameObject("YesNoDialog");
            RectTransform dialogRectTransform = yesNoDialog.AddComponent<RectTransform>();
            Image diagBg = yesNoDialog.AddComponent<Image>();
            diagBg.color = new Color32(89, 89, 89, 255);
            
            dialogRectTransform.sizeDelta = new Vector2(800, 500);
            
            dialogRectTransform.localPosition = new Vector2
            {
                x = _uiCanvas.transform.position.x + 0,
                y = _uiCanvas.transform.position.y + 0
            };
            
            yesNoDialog.transform.SetParent(_uiCanvas.transform);

            dialogWindow.dialogGameObject = yesNoDialog;
            
            // Title Part of Dialog
            
            GameObject title = new GameObject("Title");
            title.transform.SetParent(yesNoDialog.transform);
            RectTransform titleRectTransform = title.AddComponent<RectTransform>();
            
            
            titleRectTransform.localPosition = new Vector2
            {
                x =  0,
                y = 207
            };
            
            TextMeshProUGUI tmpTitle = title.AddComponent<TextMeshProUGUI>();
            tmpTitle.text = titleText;
            tmpTitle.horizontalAlignment = HorizontalAlignmentOptions.Center;
            tmpTitle.verticalAlignment = VerticalAlignmentOptions.Middle;
            tmpTitle.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/TextMesh Pro/Fonts/OptimusPrinceps SDF.asset");
            tmpTitle.color = new Color32(234, 234, 234, 255);

            dialogWindow.titleGameObject = title; 
            // Message Part of Dialog
            
            GameObject message = new GameObject("Message");
            message.transform.SetParent(yesNoDialog.transform);
            RectTransform messageRectTransform = message.AddComponent<RectTransform>();
            messageRectTransform.sizeDelta = new Vector2(650, 335);
            
            messageRectTransform.localPosition = new Vector2
            {
                x =  0,
                y = 0
            };
            
            TextMeshProUGUI tmpMessageText = message.AddComponent<TextMeshProUGUI>();
            tmpMessageText.text = messageText;
            tmpMessageText.horizontalAlignment = HorizontalAlignmentOptions.Center;
            tmpMessageText.verticalAlignment = VerticalAlignmentOptions.Middle;
            tmpMessageText.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/TextMesh Pro/Fonts/OptimusPrinceps SDF.asset");
            tmpMessageText.color = new Color32(234, 234, 234, 255);

            dialogWindow.messageGameObject = message;
            // CloseButton Part of Dialog
            
           dialogWindow.closeButtonGameObject = CreateButton("CloseButton",yesNoDialog,new Vector2(60,60),new Vector2(356,204),"X",true, dialogWindow,ButtonEnum.CloseButton,actionOnYes,actionOnNo);
           
            // YesButton Part of the Dialog
            dialogWindow.yesButtonGameObject = CreateButton("YesButton",yesNoDialog,new Vector2(268,76),new Vector2(-178,-164),"Yes",false,dialogWindow,ButtonEnum.YesButton,actionOnYes,actionOnNo);

            // NoButton Part of the Dialog
            dialogWindow.noButtonGameObject = CreateButton("NoButton",yesNoDialog,new Vector2(268,76),new Vector2(182,-164),"No",false,dialogWindow,ButtonEnum.NoButton,actionOnYes,actionOnNo);

            
            
            return dialogWindow;
        }

        private GameObject CreateButton(string buttonName, GameObject parent, Vector2 buttonSize, Vector2 buttonPosition, string buttonText, bool useBold, DialogWindow dialogWindow, ButtonEnum buttonType, Action actionOnYes, Action actionOnNo)
        {
            GameObject button = new GameObject(buttonName);
            button.transform.SetParent(parent.transform);
            RectTransform ButtonRectTransform = button.AddComponent<RectTransform>();
            ButtonRectTransform.sizeDelta = buttonSize;

            ButtonRectTransform.localPosition = buttonPosition;

            Button buttonComponent = button.AddComponent<Button>();
            Image buttonImage = button.AddComponent<Image>();

            buttonComponent.targetGraphic = buttonImage;
            
            GameObject buttonTextGameObject = new GameObject(buttonName + "Text");
            buttonTextGameObject.transform.SetParent(buttonComponent.transform);
            RectTransform buttonTextGameObjectRectTransform = buttonTextGameObject.AddComponent<RectTransform>();
            buttonTextGameObjectRectTransform.sizeDelta = new Vector2(60, 60);
            
            buttonTextGameObjectRectTransform.localPosition = new Vector2
            {
                x = 0,
                y = 0
            };
            
            TextMeshProUGUI tmpButtonTextGameObject = buttonTextGameObject.AddComponent<TextMeshProUGUI>();
            tmpButtonTextGameObject.text = buttonText;
            if (useBold)
            {
                tmpButtonTextGameObject.fontStyle = FontStyles.Bold;
            }
            
            tmpButtonTextGameObject.color = Color.black;
            tmpButtonTextGameObject.horizontalAlignment = HorizontalAlignmentOptions.Center;
            tmpButtonTextGameObject.verticalAlignment = VerticalAlignmentOptions.Middle;

            switch (buttonType)
            {
                case ButtonEnum.CloseButton:
                    buttonComponent.onClick.AddListener(delegate{onCloseClick(dialogWindow);});
                    break;
                case ButtonEnum.YesButton:
                    buttonComponent.onClick.AddListener(delegate{onYesClick(dialogWindow,actionOnYes);});
                    break;
                case ButtonEnum.NoButton:
                    buttonComponent.onClick.AddListener(delegate{onNoClick(dialogWindow,actionOnNo);});
                    break;
            }
           
            
            return button;
        }

        void onCloseClick(DialogWindow dialogWindow)
        {
            Destroy(dialogWindow.dialogGameObject);
            DestroyDiagComponent();
        }
        
        void onYesClick(DialogWindow dialogWindow,Action actionOnYes)
        {
            dialogWindow.answer = true;
            Destroy(dialogWindow.dialogGameObject);
            actionOnYes();
        }
        void onNoClick(DialogWindow dialogWindow,Action actionOnNo)
        {
            dialogWindow.answer = false;
            Destroy(dialogWindow.dialogGameObject);
            actionOnNo();
        }

        public void DestroyDiagComponent()
        {
            Destroy(_dialogWindowOnPlayer);
        }
    }
}