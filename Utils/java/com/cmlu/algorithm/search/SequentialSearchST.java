package com.cmlu.algorithm.search;

import com.cmlu.commons.Queue;
import com.cmlu.lang.StdIn;
import com.cmlu.lang.StdOut;

public class SequentialSearchST<Key, Value> {

    //Ԫ�صĸ���
    private int N;
    //��һ�����
    private Node first;
    
    //�ڲ���
    private class Node{
	private Key key;
	private Value value;
	private Node next;
	
	public Node(Key key,Value value,Node next){
	    this.key = key;
	    this.value = value;
	    this.next = next;
	}
    }
    
    /**
     * ����Ԫ�ص���Ŀ
     * @return
     */
    public int size(){
	return N;
    }
    
    /**
     * �Ƿ�Ϊ��
     * @return
     */
    public boolean isEmpty(){
	return N == 0;
    }
    
    
    public boolean contains(Key key){
	return get(key) != null;
    }
    
    /**
     * ��ȡ��㣬����Ҳ�������null
     * @param key
     * @return
     */
    public Value get(Key key){
	for(Node x=first;x!=null;x=x.next){
	    if(key.equals(x.key)) return x.value;
	}
	
	return null;
    }
    
    /**
     * ����Ѿ������ý��������ֵ��������뵽��㿪ͷ
     * ���ֵΪnull����ɾ���ü�
     * @param key
     * @param val
     */
    public void put(Key key,Value val){
	if(val == null) {
	    delete(key);
	    return;
	}
	
	for(Node x=first;x!=null;x=x.next){
	    if(key.equals(x.key)){
		x.value = val;
		return;
	    }
	}
	
	first = new Node(key, val, first);
	N++;
	
    }
    
    
    public void delete(Key key){
	first = delete(first,key);
    }
    
    private Node delete(Node x,Key key){
	if(x == null) return null;
	
	if(key.equals(x.key)){
	    N--;
	    return x.next;
	}
	
	x.next = delete(x.next, key);
	return x;
    }
    
 // return all keys as an Iterable
    public Iterable<Key> keys()  {
        Queue<Key> queue = new Queue<Key>();
        for (Node x = first; x != null; x = x.next)
            queue.enqueue(x.key);
        return queue;
    }
    
    
    /***********************************************************************
     * Test client
     **********************************************************************/
     public static void main(String[] args) {
         SequentialSearchST<String, Integer> st = new SequentialSearchST<String, Integer>();
         for (int i = 0; !StdIn.isEmpty(); i++) {
             String key = StdIn.readString();
             st.put(key, i);
         }
         for (String s : st.keys())
             StdOut.println(s + " " + st.get(s));
     }
    
}
