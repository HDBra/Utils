package com.cmlu.algorithm.graph;

/**
 * ������������㷨
 * ����˼�룺
 * ��־һ�����
 * �ݹ�������ýڵ����ӵ�δ��־���
 * @author Administrator
 *
 */
public class DepthFirstSearch {

    /**
     * marked[i]��־��i������Ƿ��Ѿ�����־
     */
    private boolean[] marked;
    /**
     * ��ʾ��־�Ľ����
     */
    private int count;
    
    public int S;
    
    /**
     * ���캯��
     * @param G
     * @param s ����������������
     */
    public DepthFirstSearch(Graph G,int s){
	marked = new boolean[G.V()];
	S = s;
	dfs(G,s);
    }
    
    /**
     * �����������
     * @param G
     * @param v
     */
    private void dfs(Graph G,int v){
	marked[v] = true;
	count++;
	for(int w:G.adj(v)){
	    if(!marked[w]){
		dfs(G, w);
	    }
	}
    }
    
    /**
     * ��־s��w�Ƿ�����
     * @param w
     * @return
     */
    public boolean marked(int w){
	return marked[w];
    }
    
    /**
     * ��s���ӵĶ����� �������G.V()-1���־���еĶ��������ӵ�
     * @return
     */
    public int count(){
	return count;
    }
    
}
