package com.cmlu.algorithm.graph;

import com.cmlu.commons.Bag;
import com.cmlu.lang.In;
import com.cmlu.lang.StdOut;

/**
 * ͼ��ʵ��
 * ʵ��������ͼ��ͼ�ĸ����ڵ��־��0��v-1
 * @author Administrator
 *
 */
public class Graph {

    /*
     * ������
     */
    private final int V;
    /**
     * ����
     */
    private int E;
    
    /**
     * ��i���㼯�����ӵ����������
     */
    private Bag<Integer>[] adj;
    
    /**
     * ���캯��������һ����v������յ�ͼ
     * @param V
     */
    public Graph(int V){
	if(V < 0){
	    throw new RuntimeException("Number of vertices must be nonnegative");
	}
	
	this.V = V;
	this.E = 0;
	adj =  (Bag<Integer> [])new Bag[V];
	
	for(int i=0;i<V;i++){
	    adj[i] = new Bag<Integer>();
	}
    }
    
    /**
     * ����һ�������ͼ������v�������E����
     * @param V
     * @param E
     */
    public Graph(int V,int E){
	this(V);
	if(E < 0){
	    throw new RuntimeException("Number of edges must be nonnegative");
	}
	
	for(int i=0;i<E;i++){
	    //�����������㣬����һ����
	    int v = (int) (Math.random()*V);
	    int w = (int) (Math.random()*V);
	    addEdge(v,w);
	}
    }
    
    /**
     * ���������д���һ��ͼ
     * @param in
     */
    public Graph(In in){
	this(in.readInt());
	int E = in.readInt();
	for(int i=0;i<E;i++){
	    int v = in.readInt();
	    int w = in.readInt();
	    addEdge(v,w);
	}
    }
    
    /**
     * ����ͼ�нڵ����Ŀ
     * @return
     */
    public int V(){
	return V;
    }
    
    /**
     * ����ͼ�бߵĸ���
     * @return
     */
    public int E(){
	return E;
    }
    
    /**
     * ����һ������� w-v
     */
    public void addEdge(int v,int w){
	E++;
	adj[v].add(w);
	adj[w].add(v);
    }
    
    /**
     * ��ȡ��v��������ھ�(ֱ�����ӵı�)
     * @param v
     * @return
     */
    public Iterable<Integer> adj(int v){
	return adj[v];
    }
    
    @Override
    public String toString(){
	StringBuilder s = new StringBuilder();
	String NEWLINE = System.getProperty("line.separator");
	s.append(V+" vertices, "+E+" edges "+NEWLINE);
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
        Graph G = new Graph(in);
        StdOut.println(G);
    }
}
