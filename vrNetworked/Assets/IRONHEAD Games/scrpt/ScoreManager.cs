using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using Photon.Pun.UtilityScripts;


public class ScoreManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI scoreboard;
    private ScoreboardEntry m_entry = null;
    private List<ScoreboardEntry> m_entries = new List<ScoreboardEntry>();

	#region Callbacks


	//creates and entry for local player and udpates the board
	public override void OnJoinedRoom()
	{
		Debug.Log(PhotonNetwork.CurrentRoom.Players.Count);
		CreateNewEntry(PhotonNetwork.LocalPlayer);
		UpdateScoreboard();
	}

	//creates entry foreach new player and updates the board
	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		CreateNewEntry(newPlayer);
		UpdateScoreboard();
	}

	//removes entry from player that left the room and updates the board
	public override void OnPlayerLeftRoom(Player targetPlayer)
	{
		RemoveEntry(targetPlayer);
		UpdateScoreboard();
	}

	//using this callback to update the scoreboard only if the score property changed
	public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
	{
		if (changedProps.ContainsKey("score"))
		{
			UpdateScoreboard();
		}
	}

	#endregion

	private ScoreboardEntry CreateNewEntry(Player newPlayer)
	{
		var newEntry = new ScoreboardEntry();
		newEntry.Set(newPlayer);
		m_entries.Add(newEntry);
		return newEntry;
	}
	private void UpdateScoreboard()
	{
		scoreboard.text = "";

		//iterate through all player to update score
		//if no entry exists create one
		foreach (var targetPlayer in PhotonNetwork.CurrentRoom.Players.Values)
		{
			Debug.Log(targetPlayer.NickName);
			var targetEntry = m_entries.Find(x => x.Player == targetPlayer);
			if (targetEntry == null)
			{
				targetEntry = CreateNewEntry(targetPlayer);
			}
			string name = "";
			if (targetEntry.Player.NickName != null && targetEntry.Player.NickName != "")
				name = targetEntry.Player.NickName;
			else
				name = "Player " + targetEntry.Player.GetPlayerNumber();
			scoreboard.text += name + " : " + targetEntry.Score + "\n";

		}

	}



	private void RemoveEntry(Player targetPlayer)
	{
		var targetEntry = m_entries.Find(x => x.Player == targetPlayer);
		m_entries.Remove(targetEntry);
		Destroy(targetEntry.gameObject);
	}

}
