using System.Collections.Generic;
using System;

public class EllysJuice {
	public string[] getWinners(string[] players) {
		int[] ptary = new int[players.Length];
		for(int i = 0; i < players.Length; i++) {
			ptary[i] = 1;
			if(i%2==0) for(int j = 0; j < i; j++) ptary[j] *= 2;
		}
		Array.Sort(players);
		Dictionary<string,int> retV = new Dictionary<string,int>();
		while(true) {
			Dictionary<string, int> pt = new Dictionary<string, int>();
			for(int i = 0; i < players.Length; i++) {
				if(!pt.ContainsKey(players[i])) pt.Add(players[i],0);
				pt[players[i]] += ptary[i];
			}
			int maxval = 0;
			string maxplayer = null;
			for(int i = 0; i < players.Length; i++) {
				if(pt[players[i]] == maxval && maxplayer != players[i]) maxplayer = null;
				if(pt[players[i]] > maxval) {
					maxval = pt[players[i]];
					maxplayer = players[i];
				}
			}
			if(maxplayer != null) if(!retV.ContainsKey(maxplayer)) retV.Add(maxplayer,0);
			{
				int i = players.Length-2;
				while(0 <= i && string.CompareOrdinal(players[i],players[i+1])>=0) i--;
				if(i==-1) break;
				string s = players[players.Length-1];
				{
					int sp = i+1;
					int tp = players.Length-1;
					while(sp<tp) {
						string tt = players[sp]; players[sp] = players[tp]; players[tp]=tt;
						sp++; tp--;
					}
				}
				int j = i+1;
				while(string.CompareOrdinal(players[i],players[j])>=0) j++;
				{
					string tt = players[j]; players[j] = players[i]; players[i]=tt;
				}
			}
		}
		Dictionary<string,int>.KeyCollection retK = retV.Keys;
		string[] ret = new string[retK.Count];
		retK.CopyTo(ret, 0);
		Array.Sort(ret);
		return ret;
	}
}
