using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSequenceController : MonoBehaviour
{
    public static LevelSequenceController instance;

    public Transform RoomHolder;
    public string FirstRoomName;

    [Space(10)]
    [Header("Animation Config")]

    public float Duration = 2f;

    [Serializable]
    public struct LevelPart 
    {
        public string name;
        public Transform Room;
        public Vector3 originCoords;
    }

    [Header("Level Rooms")]
    public LevelPart[] levelParts;

    Dictionary<string, LevelPart> rooms = new Dictionary<string, LevelPart>();

    LevelPart _currentRoom;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < levelParts.Length; i++)
            levelParts[i].originCoords = levelParts[i].Room.position;

        for (int i = 0; i < levelParts.Length; i++)
            rooms.Add(levelParts[i].name, levelParts[i]);

        ShowNewRoom(FirstRoomName);
    }
    public void ChangeRoom(string roomName) 
    {
        HideOldRoom();
        ShowNewRoom(roomName);
    }

    void ShowNewRoom(string roomName) 
    {
        rooms[roomName].Room.DOMove(RoomHolder.position, Duration);
        _currentRoom = rooms[roomName];
    }

    void HideOldRoom() 
    {
        _currentRoom.Room.DOMove(_currentRoom.originCoords * -1, Duration);
    }

}
