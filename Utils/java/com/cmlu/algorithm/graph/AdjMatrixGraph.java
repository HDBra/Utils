package com.cmlu.algorithm.graph;

import java.util.Iterator;
import java.util.NoSuchElementException;

import com.cmlu.lang.StdOut;

/**
 * ͼ���ڽӾ���ʵ�֣�V*V�ľ���
 * @author Administrator
 *
 */
public class AdjMatrixGraph {
    /**
     * �����
     */
    private int V;
    
    /**
     * ����
     */
    private int E;
    
    /**
     * ���Ϊtrue�����ʾi��j�����ӵ�
     */
    private boolean[][] adj;
    
    /**
     * ���캯��
     */
    public AdjMatrixGraph(int V){
	if(V<0){
	    throw new RuntimeException("Number of vertices must be nonnegative");
	}
	this.V = V;
	E = 0;
	adj = new boolean[V][V];
    }
    
    /**
     * ���캯��
     * @param V
     * @param E
     */
    public AdjMatrixGraph(int V,int E){
	this(V);
	if(E<0){
	    throw new RuntimeException("Number of edges must be nonnegative");
	}
	
	if(E>V*V) {
	    throw new RuntimeException("Too many edges");
	}
	
	if(this.E != E){
	    int v = (int)(V*Math.random());
	    int w = (int)(V*Math.random());
	    addEdge(v,w);
	}
	
    }
    
    /**
     * ���ؽ����
     * @return
     */
    public int V(){
	return V;
    }
    
    /**
     * ���ر�
     * @return
     */
    public int E(){
	return E;
    }
    
    /**
     * ����һ����
     */
    public void addEdge(int v,int w){
	if(!adj[v][w]) E++;
	
	adj[w][v] = true;
	adj[v][w] = true;
    }
    
    /**
     * �Ƿ����v-w��
     */
    public boolean contains(int v,int w){
	return adj[v][w];
    }
    
    
    // return list of neighbors of v
    public Iterable<Integer> adj(int v) {
        return new AdjIterator(v);
    }

    // support iteration over graph vertices
    private class AdjIterator implements Iterator<Integer>, Iterable<Integer> {
        int v, w = 0;
        AdjIterator(int v) { this.v = v; }

        public Iterator<Integer> iterator() { return this; }

        public boolean hasNext() {
            while (w < V) {
                if (adj[v][w]) return true;
                w++;
            }
            return false;
        }

        public Integer next() {
            if (hasNext()) { return w++;                         }
            else           { throw new NoSuchElementException(); }
        }

        public void remove()  { throw new UnsupportedOperationException();  }
    }


    // string representation of Graph - takes quadratic time
    public String toString() {
        String NEWLINE = System.getProperty("line.separator");
        StringBuilder s = new StringBuilder();
        s.append(V + " " + E + NEWLINE);
        for (int v = 0; v < V; v++) {
            s.append(v + ": ");
            for (int w : adj(v)) {
                s.append(w + " ");
            }
            s.append(NEWLINE);
        }
        return s.toString();
    }


    // test client
    public static void main(String[] args) {
        int V = Integer.parseInt(args[0]);
        int E = Integer.parseInt(args[1]);
        AdjMatrixGraph G = new AdjMatrixGraph(V, E);
        StdOut.println(G);
    }
    
    
    
}
