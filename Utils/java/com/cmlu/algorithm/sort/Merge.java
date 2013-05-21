package com.cmlu.algorithm.sort;

/**
 * �ϲ������Ѿ��ź����������
 * @author Administrator
 *
 */
public class Merge {
    /**
     * �ϲ����������������
     * @param a
     * @param aux
     * @param lo
     * @param mid
     * @param hi
     */
    public static void merge(Comparable[] a,Comparable[] aux,int lo,int mid,int hi){
	assert isSorted(a,lo,mid);
	assert isSorted(a,mid+1,hi);
	//����һ�����ݣ�����ζ�źϲ�������Ҫ���������ռ�
	for(int k=lo;k<=hi;k++){
	    aux[k] = a[k];
	}
	//�����ݸ���Ϊa[]
	int i = lo,j = mid+1;
	for(int k=lo;k<=hi;k++){
	    if(i>mid) a[k] = aux[j++];//��ߵ������Ѿ�ȫ��������
	    else if(j>hi) a[k] = aux[i++];//�ұߵ������Ѿ�ȫ����
	    else if(less(aux[j],aux[i])) a[k] = aux[j++];
	    else a[k] = aux[i++];
	}
	
	//��֤�����ź�����
	assert isSorted(a,lo,hi);
    }
    
    /**
     * �ϲ�����
     * @param a
     * @param aux
     * @param lo
     * @param hi
     */
    private static void mergeSort(Comparable[] a,Comparable[] aux,int lo,int hi){
	if(hi <= lo) return;
	int mid = lo + (hi - lo)/2;
	mergeSort(a, aux, lo, mid);
	mergeSort(a, aux, mid+1, hi);
	merge(a, aux, lo, mid, hi);
    }
    
    /**
     * �ϲ�����
     * @param a
     */
    public static void mergeSort(Comparable[] a){
	//�ϲ�����ʵ������Ҫ����ΪN�Ķ���ռ�
	Comparable[] aux = new Comparable[a.length];
	mergeSort(a, aux, 0, a.length-1);
	assert isSorted(a);
    }
    
 // is v < w ?
    private static boolean less(Comparable v, Comparable w) {
        return (v.compareTo(w) < 0);
    }
        
    // exchange a[i] and a[j]
    private static void exch(Object[] a, int i, int j) {
        Object swap = a[i];
        a[i] = a[j];
        a[j] = swap;
    }


   /***********************************************************************
    *  Check if array is sorted - useful for debugging
    ***********************************************************************/
    private static boolean isSorted(Comparable[] a) {
        return isSorted(a, 0, a.length - 1);
    }

    private static boolean isSorted(Comparable[] a, int lo, int hi) {
        for (int i = lo + 1; i <= hi; i++)
            if (less(a[i], a[i-1])) return false;
        return true;
    }

    
}
