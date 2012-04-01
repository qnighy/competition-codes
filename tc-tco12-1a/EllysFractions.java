import java.util.*;

public class EllysFractions {
	public long getCount(int N) {
		boolean[] prime = new boolean[N+1];
		for(int i = 2; i < N+1; i++) prime[i] = true;
		for(int i = 2; i <= N; i++) {
			if(prime[i]) {
				for(int j = i*2; j <= N; j+=i) {
					prime[j] = false;
				}
			}
		}
		long ret = 0;
		long sub = 1;
		for(int i = 2; i <= N; i++) {
			if(prime[i]) sub*=2;
			if(i==2) sub/=2;
			ret += sub;
		}
		return ret;
	}
}
