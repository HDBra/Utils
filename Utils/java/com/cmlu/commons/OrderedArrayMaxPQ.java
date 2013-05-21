package com.cmlu.commons;

import com.cmlu.lang.StdOut;

public class OrderedArrayMaxPQ<Key extends Comparable<Key>> {
    
    /**
     * ����ײ������
     */
    private Key[] pq;
    
    /**
     * ���ȶ����е�Ԫ����Ŀ
     */
    private int N;

    /**
     * ���캯��
     */
    public OrderedArrayMaxPQ(int capacity){
	pq = (Key[])(new Comparable[capacity]);
	N = 0;
    }
    
    /**
     * �ж����ȶ����Ƿ�Ϊ��
     */
    public boolean isEmpty(){
	return N == 0;
    }
    
    /**
     * ���ȶ�����Ԫ�ص���Ŀ
     * @return
     */
    public int size(){
	return N;
    }
    
    /**
     * ɾ�����ֵ
     * @return
     */
    public Key delMax(){
	return pq[--N];
    }
    
    /**
     * ����Ԫ��
     * @param key
     */
    public void insert(Key key){
	int i = N - 1;
	while(i>=0 && less(key,pq[i])){
	    pq[i+1] = pq[i];
	    i--;
	}
	
	pq[i+1] = key;
	N++;
    }
    
    /**
     * v �Ƿ�С�� w
     * @param v
     * @param w
     * @return
     */
    private boolean less(Key v,Key w){
	return v.compareTo(w) < 0;
    }
    
    /**
     * ����
     * @param i
     * @param j
     */
    public void exch(int i,int j){
	Key swap = pq[i];
	pq[i] = pq[j];
	pq[j] = swap;
    }
    
    /***********************************************************************
     * Test routine.
     **********************************************************************/
     public static void main(String[] args) {
         OrderedArrayMaxPQ<String> pq = new OrderedArrayMaxPQ<String>(10);
         pq.insert("this");
         pq.insert("is");
         pq.insert("a");
         pq.insert("test");
         while (!pq.isEmpty())
             StdOut.println(pq.delMax());
     }
}
