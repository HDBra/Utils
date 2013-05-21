package com.cmlu.commons;

import java.util.concurrent.Exchanger;

import com.cmlu.lang.StdOut;

/**
 * ���ȶ��У�ÿ�ε������ֵ
 * @author Administrator
 *
 * @param <Key>
 */
public class UnorderedArrayMaxPQ<Key extends Comparable<Key>> {

    /**
     * �����ڲ��洢
     */
    private Key[] pq;
    
    /**
     * Ԫ�ص���Ŀ
     */
    private int N;
    
    /**
     * ���캯��
     * @param capacity
     */
    public UnorderedArrayMaxPQ(int capacity){
	pq = (Key[]) new Comparable[capacity];
	N = 0;
    }
    
    /**
     * �ж����ȶ����Ƿ�Ϊ��
     * @return
     */
    public boolean isEmpty(){
	return N == 0;
    }
    
    /**
     * Ԫ�ص���Ŀ
     * @return
     */
    public int size(){
	return N;
    }
    
    /**
     * ����Ԫ��
     * @param x
     */
    public void insert(Key x){
	pq[N++] = x;
    }
    
    /**
     * ɾ�����ֵ
     * @return
     */
    public Key delMax(){
	int max = 0;
	for(int i=1;i<N;i++){
	    if(less(max,i))
		max = i;
	}
	exch(max,N-1);
	return pq[--N];
    }
    
    
    /**
     * �Ƚ�����Ϊi��j��Ԫ�صĴ�С
     */
    private boolean less(int i,int j){
	return (pq[i].compareTo(pq[j]) < 0);
    }
    
    /**
     * ��������Ϊi��j��Ԫ��
     * @param i
     * @param j
     */
    private void exch(int i,int j){
	Key swap = pq[i];
	pq[i] = pq[j];
	pq[j] = swap;
    }
    
    
    /***********************************************************************
     * Test routine.
     **********************************************************************/
     public static void main(String[] args) {
         UnorderedArrayMaxPQ<String> pq = new UnorderedArrayMaxPQ<String>(10);
         pq.insert("this");
         pq.insert("is");
         pq.insert("a");
         pq.insert("test");
         while (!pq.isEmpty()) 
             StdOut.println(pq.delMax());
     }

}
