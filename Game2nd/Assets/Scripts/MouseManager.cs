using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    void Awake()
    {
        texture2D = Resources.Load<Texture2D>("Default");
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnEnable()
    {
        State.Subscribe(Condition.START, DisableMode);
        State.Subscribe(Condition.FINISH, EnableMode);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Cursor.visible) { DisableMode(); }
            else if (!Cursor.visible) { EnableMode(); }
        }
    }

    void EnableMode() { Cursor.visible = true; Cursor.lockState = CursorLockMode.None; }
    void DisableMode() { Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; }

    void OnDisable()
    {
        State.UnSubscribe(Condition.START, DisableMode);
        State.UnSubscribe(Condition.FINISH, EnableMode);
    }
}
