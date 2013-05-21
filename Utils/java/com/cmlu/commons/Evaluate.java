package com.cmlu.commons;

import java.util.Stack;

import javax.script.ScriptEngineManager;
import javax.script.ScriptException;

import com.cmlu.lang.StdIn;
import com.cmlu.lang.StdOut;

/**
 * Dijkstra��s Two-Stack Algorithm for Expression Evaluation
 * �����������£�
 * 1��push�������ŵ�������ջ
 * 2��push�������ŵ�������ջ��
 * 3������������
 * 4�������������ţ�����һ����������������������Ҫ�Ĳ������������������������ջ��
 * �����һ�������ű������ֻ��һ��ֵ�ڲ�����ջ�м����ս��
 * @author Administrator
 *
For simplicity, this code assumes that the expression
is fully parenthesized, with numbers and characters
separated by whitespace.
 */
public class Evaluate {

	public static void main(String[] args) {
		Stack<String> ops = new Stack<String>();
		Stack<Double> vals = new Stack<Double>();

		while (!StdIn.isEmpty()) {
			String s = StdIn.readString();
			if(s.equals("(")){}
			else if (s.equals("+")){ops.push(s);}
			else if (s.equals("-")){ops.push(s);}
			else if(s.equals("*")) {ops.push(s);}
			else if(s.equals("/")) {ops.push(s);}
			else if(s.equals("sqrt")){ops.push(s);}
			else if(s.equals(")")){
				String op = ops.pop();
				double v = vals.pop();
				if(op.equals("+")) v = vals.pop()+v;
				if(op.equals("-")) v = vals.pop()-v;
				if(op.equals("*")) v = vals.pop()*v;
				if(op.equals("/")) v = vals.pop()/v;
				if(op.equals("sqrt")) v = Math.sqrt(v);
				vals.push(v);
			}
			else{
				vals.push(Double.parseDouble(s));
			}
		}
		
		//��ӡ���ս��
		StdOut.println(vals.pop());
	}
	
	
	/**
	 * ������ʽ��ֵ
	 * @param expr
	 * @return
	 */
	public static Object eval(String expr){
		  ScriptEngineManager sem = new ScriptEngineManager();
		  Object result = null;
		  try {
		    result = sem.getEngineByName("javascript").eval(expr);
		   //System.out.println(result.getClass());
		   //System.out.println(result);
		  } catch (Exception e) {
		  }
		  return result;
	}
}
