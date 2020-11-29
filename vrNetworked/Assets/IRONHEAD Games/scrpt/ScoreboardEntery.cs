using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardEntry : MonoBehaviour
{
	public Player Player => m_player;
	public int Score => m_player.GetScore();

	private Player m_player;

	//store player for this entry
	//set init value and color
	public void Set(Player player)
	{
		m_player = player;

	}

	//update label bases on score and name

}