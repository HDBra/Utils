package com.cmlu.introtoalgorithm.sort;

import com.cmlu.lang.StdOut;

public class Sort {
	/**
	 * �������� �ǽ���
	 * 
	 * @param array
	 */
	public static void InsertionSort(int[] array) {
		if (array == null || array.length <= 1) {
			return;
		}
		// �������������ƣ����е������ź����
		// ���ٴ����µ�����
		int temp;
		int length = array.length;
		for (int i = 1; i < length; i++) {
			temp = array[i];
			// �ڶ���ѭ��
			int j;
			for (j = i - 1; j > -1 && array[j] > temp; j--) {
				// ���������
				array[j + 1] = array[j];
			}
			array[j + 1] = temp;
		}
	}

	/**
	 * ѡ�����򣨾������ÿ���ҳ���Сֵ�������ŵ�ǰ�棩
	 * 
	 * @param array
	 */
	public static void SelectionSort(int[] array) {
		// ��������
		if (array == null || array.length <= 1) {
			return;
		}

		for (int i = 0; i < array.length; i++) {
			// �ӵڶ���Ԫ�ؿ�ʼ
			int min = array[i];
			// ��С�����ڵ�����
			int minIndex = i;
			for (int j = i + 1; j < array.length; j++) {
				if (min > array[j]) {
					min = array[j];
					minIndex = j;
				}
			}

			// ����i��j����λ���ϵ�����
			int temp = array[i];
			array[i] = array[minIndex];
			array[minIndex] = temp;
		}
	}

	/**
	 * ð������  ÿ�ν������������λ��
	 * @param array
	 */
	public static void BubbleSort(int[]array){
		if(array == null || array.length <=1){
			return;
		}
		
		int temp;
		for(int i=0;i<array.length;i++){
			for(int j=array.length-1;j>i;j--){
				if(array[j]<array[j-1]){
					//�������������λ�ã�С����ǰ
					temp = array[j];
					array[j] = array[j-1];
					array[j-1] = temp;
				}
			}
		}
	}
	
	
	// �ϲ�����************************************************************************************
	/**
	 * �ϲ����򣬲��÷��η�
	 * 
	 * @param
	 */
	public static void MergeSort(int[] array) {
		if (array == null || array.length <= 1) {
			return;
		}

		MergeSort(array, 0, array.length - 1);
	}

	/**
	 * �ϲ����� ��������鲻����null�������ȿ�����0
	 * 
	 * @param array
	 *            ����������
	 * @param beginIndex
	 *            ���鿪ʼ���� 0
	 * @param endIndex
	 *            ����������� ��array.Length -1
	 */
	public static void MergeSort(int[] array, int beginIndex, int endIndex) {
		if (beginIndex < endIndex) {
			int mid = (beginIndex + endIndex) / 2;
			// ���η�
			MergeSort(array, beginIndex, mid);
			MergeSort(array, mid + 1, endIndex);
			// �ϲ������Ѿ��ź�������飬�������������ٳ���Ϊ1��
			Merge(array, beginIndex, mid, endIndex);
		}
	}

	/**
	 * �ϲ������Ѿ��ź�������飬�������������ٳ���Ϊ1��
	 * 
	 * @param array
	 * @param beginIndex
	 * @param mid
	 * @param endIndex
	 */
	public static void Merge(int[] array, int beginIndex, int mid, int endIndex) {
		int[] arrayLeft = new int[mid - beginIndex + 1];
		int[] arrayRight = new int[endIndex - mid];
		// ��ߵ����鱸��
		for (int i = 0; i < arrayLeft.length; i++) {
			arrayLeft[i] = array[beginIndex + i];
		}
		// �ұߵ�����
		for (int i = 0; i < arrayRight.length; i++) {
			arrayRight[i] = array[mid + 1 + i];
		}
		// ��ߵ����飬�ұߵ�����
		int left = 0;
		int right = 0;
		for (int i = beginIndex; i <= endIndex; i++) {

			// ��ߵ������Ѿ�����
			if (left >= arrayLeft.length && right <= arrayRight.length - 1) {
				array[i] = arrayRight[right];
				right++;
				continue;
			}

			// �ұߵ������Ѿ�����
			if (right >= arrayRight.length && left <= arrayLeft.length - 1) {
				array[i] = arrayLeft[left];
				left++;
				continue;
			}

			if (arrayLeft[left] < arrayRight[right]) {
				array[i] = arrayLeft[left];
				left++;
			} else {
				array[i] = arrayRight[right];
				right++;
			}
		}
	}

	// �ϲ�����************************************************************************************

	/**
	 * test client
	 * 
	 * @param args
	 */
	public static void main(String[] args) {
		int[] array = { 1, 2, 3, 4, 5, 6, -10, -11, 34, -10 ,123,-89};

		BubbleSort(array);
		// SelectionSort(array);
		for (int i : array) {
			StdOut.print(i + " ");
		}
		
		StdOut.println();
		StdOut.println(Search.BinarySearch(array, 34));
	}

}
