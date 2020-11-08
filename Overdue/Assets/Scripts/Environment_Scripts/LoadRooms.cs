using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadRooms : MonoBehaviour
{
  public float room_space;

  public int roomCount = 9;
  //roomList is the list of layout slots
  public RoomSlot[] roomList;
  //possible rooms are the prefabs
  public GameObject[] possibleRooms;
  //loaded rooms are actual instances of the rooms
  [SerializeField]
  GameObject[] loadedRooms;

  public class RoomSlot
  {
    Vector3 location;
    GameObject slot_room;

    public RoomSlot(Vector3 loc, GameObject r)
    {
      location = loc;
      slot_room = r;
    }

    public RoomSlot(Vector3 loc)
    {
      location = loc;
    }

    public Vector3 currentLocation()
    {
      return this.location;
    }

    public void assignRoom(GameObject r)
    {
      slot_room = r;
    }

    public GameObject currentRoom()
    {
      return this.slot_room;
    }

  }

     // Start is called before the first frame update
    void Start()
    {
      roomList = new RoomSlot[roomCount];
      loadedRooms = new GameObject[roomCount];
      List<Vector3> roomLocations = new List<Vector3>();
      roomLocations.Add(new Vector3(-room_space, 0, 0));
      roomLocations.Add(new Vector3(0, 0, 0));
      roomLocations.Add(new Vector3(room_space, 0, 0));
      roomLocations.Add(new Vector3(-room_space, room_space, 0));
      roomLocations.Add(new Vector3(0, room_space, 0));
      roomLocations.Add(new Vector3(room_space, room_space, 0));
      roomLocations.Add(new Vector3(-room_space, room_space * 2, 0));
      roomLocations.Add(new Vector3(0, room_space * 2, 0));
      roomLocations.Add(new Vector3(room_space, room_space * 2, 0));
      for(int i = 0; i < roomCount; i++)
      {
        roomList[i] = new RoomSlot(roomLocations[i]);

      }
    }

    public void ArrangeRooms()
    {
      int newRoom = 0;
      List<int> chosen = new List<int>();
      for(int i = 0; i < roomCount; i++)
      {
        Destroy(loadedRooms[i]);
        chosen.Clear();
      }

      for(int i = 0; i < roomCount; i++)
      {
        do{
          newRoom = Random.Range(0, roomCount);
        }while(chosen.Contains(newRoom));
        chosen.Add(newRoom);
        roomList[i].assignRoom(possibleRooms[newRoom]);
        loadedRooms[i] = Instantiate(roomList[i].currentRoom(), roomList[i].currentLocation(), Quaternion.identity);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
