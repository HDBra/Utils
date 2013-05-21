package com.cmlu.algorithm.graph;

import com.cmlu.commons.Bag;
import com.cmlu.commons.Stack;
import com.cmlu.lang.In;
import com.cmlu.lang.StdOut;

/**
 * ����ͼ
 */
public class Digraph {

    /**
     * �������
     */
    private final int V;
    
    /**
     * �ߵĸ���
     */
    private int E;
    
    /**
     * adj[i]��ʾ��i�����Ϊ���ı�
     */
    private Bag<Integer>[] adj;
    
    /**
     * ����һ���յĴ���V�����������ͼ
     */
    public Digraph(int V){
	if(V < 0){
	    throw new RuntimeException("Number of vertices must be nonnegative");
	}
	this.V = V;
	this.E = 0;
	adj = (Bag<Integer>[]) new Bag[V];
	
	for(int v=0;v<V;v++){
	    adj[v] = new Bag<Integer>();
	}
    }
    
    /**
     * ����һ������ͼ��������
     */
    public Digraph(In in){
	this(in.readInt());
	int E = in.readInt();
	for(int i=0;i<E;i++){
	    int v = in.readInt();
	    int w = in.readInt();
	    addEdge(v,w);
	}
    }
    
    /**
     * ���ƹ��캯��, ����һ������ԭ����ȫ�෴��ͼ
     */
    public Digraph(Digraph G){
	this(G.V());
	this.E = G.V();
	for(int v=0;v<G.V();v++){
	    Stack<Integer> reverse = new Stack<Integer>();
	    for(int w:G.adj[v]){
		reverse.push(w);
	    }
	    
	    for(int w:reverse){
		adj[w].add(w);
	    }
	}
    }
    
    /**
     * ���ؽ�����Ŀ
     */
    public int V(){
	return V;
    }
    
    /**
     * ���رߵ���Ŀ
     */
    public int E(){
	return E;
    }
    
    /**
     * ����һ�������v->w
     */
    public void addEdge(int v,int w){
	adj[v].add(w);
	E++;
    }
    
    /**
     * Return the list of vertices pointed to from vertex v as an Iterable.
     */
    public Iterable<Integer> adj(int v) {
        return adj[v];
    }
    
    /**
     * ��������ͼ�ķ�ת�汾
     */
    public Digraph reverse(){
	Digraph R = new Digraph(V);
	for(int v=0;v<V;v++){
	    for(int w:adj(v)){
		R.addEdge(w, v);
	    }
	}
	return R;
    }
    
    /**
     * Return a string representation of the digraph.
     */
    public String toString() {
        StringBuilder s = new StringBuilder();
        String NEWLINE = System.getProperty("line.separator");
        s.append(V + " " + E + NEWLINE);
        for (int v = 0; v < V; v++) {
            s.append(v + ": ");
            for (int w : adj[v]) {
                s.append(w + " ");
            }
            s.append(NEWLINE);
        }
        return s.toString();
    }

    /**
     * Test client.
     */
    public static void main(String[] args) {
        In in = new In(args[0]);
        Digraph G = new Digraph(in);
        StdOut.println(G);

        StdOut.println();
        for (int v = 0; v < G.V(); v++)
            for (int w : G.adj(v))
                StdOut.println(v + "->" + w);
    }

    
    
    
    
    
    
    
}
