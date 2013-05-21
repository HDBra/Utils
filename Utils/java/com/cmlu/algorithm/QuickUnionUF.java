package com.cmlu.algorithm;

import com.cmlu.lang.StdIn;
import com.cmlu.lang.StdOut;
import com.cmlu.lang.Stopwatch;

/**
 * Union-find ����ģ��
 * 
 * @author Administrator
 * 
 */
/**
 * ����㷨���Ӷ��Ǹ����ڵ���ȵľ�ֵ��������lgN��*N
 * @author Administrator
 *
 */
public class QuickUnionUF {
    // id[i] = parent of i
    // ��i������ĵȼ����е�����һ������
    // �����͹�����һ�����ӣ�id[i]->id[id[i]]ֱ��id[i] == i,��ʱ��i�ǵȼ���ĸ�
    private int[] id;
    // sz[i] = number of objects in subtree rooted at i
    // i��ȡֵֻ����root
    private int[] sz;
    // number of compents
    private int count;

    /**
     * �����N��ָ�������������е�ÿ�������ܹ�N������ת��Ϊ0��N-1������
     * 
     * @param N
     */
    public QuickUnionUF(int N) {
	count = N;
	id = new int[N];
	sz = new int[N];
	for (int i = 0; i < N; i++) {
	    id[i] = i;
	    sz[i] = 1;
	}
    }

    /**
     * return the id of component corresponding of object p
     * ������Խ�һ���Ż�Ч�ʣ��ڲ���ʱ����¼��p!=id[p]��p�����ҵ����󣬽�id[p]ֱ����Ϊ����ֵ������ÿ���ڵ�����Ϊ1
     * �����path compression
     * @param p
     * @return
     */
    public int find(int p) {
	while (p != id[p]) {
	    p = id[p];
	}
	return p;
    }

    /**
     * return the number of disjoint sets
     */
    public int count() {
	return count;
    }

    /**
     * are objects p and q in the same set?
     */
    public boolean connected(int p, int q) {
	return find(p) == find(q);
    }

    /**
     * replace the set containing p and q with their union
     */
    public void union(int p, int q) {
	int i = find(p);
	int j = find(q);
	if (i == j)
	    return;
	// make smaller root point to larger one
	// �����ѡ���ǿ�ѡ��
	/*if (sz[i] < sz[j]) {
	    id[i] = j;
	    sz[j] += sz[i];
	} else {
	    id[j] = i;
	    sz[i] += sz[j];
	}*/
	//��Զ��һ�����ӵ���һ�ˣ����������������ڲ�ƽ�⣨�����
	id[i] = j;
	sz[j] = sz[i] + sz[j];
	count--;
    }
    
    public void weightedUnion(int p,int q){
	int i = find(p);
	int j = find(q);
	if (i == j)
	    return;
	// make smaller root point to larger one
	// �����ѡ���ǿ�ѡ��
	if (sz[i] < sz[j]) {
	    //��С��һ�����ӵ�root���Ӷ�ʹ������������ƽ��
	    //����㷨��Ч�ʸ���
	    id[i] = j;
	    sz[j] += sz[i];
	} else {
	    id[j] = i;
	    sz[i] += sz[j];
	}
    }

    public static void main(String[] args) {
	try {
	    int N = StdIn.readInt();
	    Stopwatch watch = new Stopwatch();
	    QuickUnionUF uf = new QuickUnionUF(N);

	    // read in a sequence of pairs of integers (each in the range 0 to
	    // N-1),
	    // calling find() for each pair: If the members of the pair are not
	    // already
	    // call union() and print the pair.
	    while (!StdIn.isEmpty()) {
		int p = StdIn.readInt();
		int q = StdIn.readInt();
		if (uf.connected(p, q))
		    continue;
		uf.union(p, q);
		StdOut.println(p + " " + q);
	    }

	    StdOut.println("# components: " + uf.count());
	    StdOut.println("time used:" + watch.elapsedTime() + "s");

	} catch (Exception ex) {
	    StdOut.println(ex.toString());
	}
    }
}
