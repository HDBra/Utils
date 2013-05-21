package com.cmlu.algorithm.graph;

import com.cmlu.commons.Stack;
import com.cmlu.lang.StdOut;




/**
 * ��Ȧͼ���
 * @author Administrator
 *
 */
public class Cycle {
    private boolean[] marked;
    private int[] edgeTo;
    private Stack<Integer> cycle;
    
    public Cycle(Graph G){
	if(hasSelfLoop(G)) return;
	
	if(hasParallelEdges(G)) return;
	
	marked = new boolean[G.V()];
	edgeTo = new int[G.V()];
	for(int v=0;v<G.V();v++){
	    if(!marked[v]){
		dfs(G,-1,v);
	    }
	}
    }
    
    /**
     * �Ƿ�����Ի�
     */
    private boolean hasSelfLoop(Graph G){
	for(int v=0;v<G.V();v++){
	    for(int w:G.adj(v)){
		if(w == v){
		    cycle = new Stack<Integer>();
		    cycle.push(v);
		    cycle.push(v);
		    return true;
		}
	    }
	}
	return false;
    }
    
    //�Ƿ�������ƽ�еı�
    public boolean hasParallelEdges(Graph G){
	marked = new boolean[G.V()];
	
	for(int v=0;v<G.V();v++){
	    for(int w:G.adj(v)){
		if(marked[w]){
		    cycle = new Stack<Integer>();
		    cycle.push(v);
		    cycle.push(w);
		    cycle.push(v);
		    return true;
		}
		marked[w] = true;
	    }
	    
	 // reset so marked[v] = false for all v
            for (int w : G.adj(v)) {
                marked[w] = false;
            }
	}

	return false;
    }
    
    public boolean hasCycle()        { return cycle != null; }
    public Iterable<Integer> cycle() { return cycle;         }
    
    
    
    
    private void dfs(Graph G, int u, int v) {
        marked[v] = true;
        for (int w : G.adj(v)) {

            // short circuit if cycle already found
            if (cycle != null) return;

            if (!marked[w]) {
                edgeTo[w] = v;
                dfs(G, v, w);
            }

            // check for cycle (but disregard reverse of edge leading to v)
            else if (w != u) {
                cycle = new Stack<Integer>();
                for (int x = v; x != w; x = edgeTo[x]) {
                    cycle.push(x);
                }
                cycle.push(w);
                cycle.push(v);
            }
        }
    }

    // test client
    public static void main(String[] args) {
        int V = Integer.parseInt(args[0]);
        int E = Integer.parseInt(args[1]);
        Graph G = new Graph(V, E);
        StdOut.println(G);

        Cycle finder = new Cycle(G);
        if (finder.hasCycle()) {
            for (int v : finder.cycle()) {
                StdOut.print(v + " ");
            }
            StdOut.println();
        }
        else {
            StdOut.println("Graph is acyclic");
        }
    }
    
    
    
    
    
    
    
    
}
