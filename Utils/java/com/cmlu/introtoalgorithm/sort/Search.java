package com.cmlu.introtoalgorithm.sort;

public class Search {

	//���ֲ���
	/**
	 * �����в���ĳ��ָ����Ԫ�أ��������������ź����
	 * @param array
	 * @param key
	 * @return  key���ڵ�����λ��  -1����Ҳ���
	 */
	public static int BinarySearch(int[] array,int key){
		if(array == null || array.length==0){
			return -1;
		}
		
		return BinarySearch(array, 0,array.length-1 ,key);
	}
	
	/**
	 * ���ֲ���
	 * @param array
	 * @param beginIndex ����������ʼλ��
	 * @param endIndex  ������������λ��
	 * @param key
	 * @return
	 */
	public static int BinarySearch(int[] array,int beginIndex, int endIndex,int key){
		if(array == null || array.length==0 || endIndex <beginIndex){
			return -1;
		}
		int mid = (beginIndex+endIndex) /2;
		if(array[mid] == key){
			return mid;
		}
		if(array[mid] < key){
			return BinarySearch(array, mid+1,endIndex,key);
		}
		else{
			return BinarySearch(array, beginIndex, mid-1, key);
		}
	}
}
