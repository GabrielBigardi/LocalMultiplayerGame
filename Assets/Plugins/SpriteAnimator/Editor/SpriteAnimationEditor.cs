using UnityEngine;
using UnityEditorInternal;
using UnityEditor;

namespace GabrielBigardi.Animator
{
    [CustomEditor(typeof(SpriteAnimation))]
    public class SpriteAnimationEditor : Editor
    {
        private ReorderableList framesList;

        private SpriteAnimation SelectedSpriteAnimation
        {
            get { return target as SpriteAnimation; }
        }

        private float timeTracker = 0;

        private SpriteAnimationFrame currentFrame;

        private SpriteAnimationHelper spriteAnimationHelper;

        private void OnEnable()
        {
            timeTracker = (float)EditorApplication.timeSinceStartup;
            spriteAnimationHelper = new SpriteAnimationHelper(SelectedSpriteAnimation);

            InitializeFrameList();

            EditorApplication.update += OnUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= OnUpdate;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            if (SelectedSpriteAnimation != null && framesList != null)
            {
                SelectedSpriteAnimation.Name = EditorGUILayout.TextField("Name", SelectedSpriteAnimation.Name);

                framesList.DoLayoutList();

                SelectedSpriteAnimation.FPS = Mathf.Max(EditorGUILayout.IntField("FPS", SelectedSpriteAnimation.FPS), 0);

                SelectedSpriteAnimation.SpriteAnimationType = (SpriteAnimationType)EditorGUILayout.EnumPopup("Type", SelectedSpriteAnimation.SpriteAnimationType);
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);
            }

            serializedObject.ApplyModifiedProperties();
        }

        public override bool HasPreviewGUI()
        {
            return HasAnimationAndFrames();
        }

        public override bool RequiresConstantRepaint()
        {
            return HasAnimationAndFrames();
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            if (currentFrame != null && currentFrame.Sprite != null)
            {
                Texture t = currentFrame.Sprite.texture;
                Rect tr = currentFrame.Sprite.textureRect;
                Rect r2 = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);

                Rect previewRect = r;

                float targetAspectRatio = tr.width / tr.height;
                float windowAspectRatio = r.width / r.height;
                float scaleHeight = windowAspectRatio / targetAspectRatio;

                if (scaleHeight < 1f)
                {
                    previewRect.width = r.width;
                    previewRect.height = scaleHeight * r.height;
                    previewRect.x = r.x;
                    previewRect.y = r.y + (r.height - previewRect.height) / 2f;
                }
                else
                {
                    float scaleWidth = 1f / scaleHeight;

                    previewRect.width = scaleWidth * r.width;
                    previewRect.height = r.height;
                    previewRect.x = r.x + (r.width - previewRect.width) / 2f;
                    previewRect.y = r.y;
                }

                GUI.DrawTextureWithTexCoords(previewRect, t, r2, true);
            }
        }

        private void InitializeFrameList()
        {
            framesList = new ReorderableList(serializedObject, serializedObject.FindProperty("Frames"), true, true, true, true);
            //framesList = new ReorderableList(SelectedSpriteAnimation.Frames, typeof(Sprite), true, true, true, true);
            //framesList.elementHeight = EditorGUIUtility.singleLineHeight * 5f;

            framesList.drawElementCallback = DrawElement; // Actually draws the elements
            framesList.drawHeaderCallback = DrawHeader; // Label the Rect with "Frames" instead of IList
        }

        private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = framesList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            Debug.Log(rect);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("Sprite"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("EventName"), GUIContent.none);

            //SpriteAnimationFrame spriteAnimationFrame = SelectedSpriteAnimation.Frames[index];
            //
            //rect.y += 2;
            //
            //spriteAnimationFrame.Sprite = EditorGUI.ObjectField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), "", spriteAnimationFrame.Sprite, typeof(Sprite), false) as Sprite;
        }

        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Frames");
        }

        private bool HasAnimationAndFrames()
        {
            return SelectedSpriteAnimation != null && SelectedSpriteAnimation.Frames.Count > 0;
        }

        private void OnUpdate()
        {
            if (SelectedSpriteAnimation != null && SelectedSpriteAnimation.Frames.Count > 0)
            {
                float deltaTime = (float)EditorApplication.timeSinceStartup - timeTracker;
                timeTracker += deltaTime;
                currentFrame = spriteAnimationHelper.UpdateAnimation(deltaTime);
            }
        }
    }
}