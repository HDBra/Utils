package iflytek.common.base;

import java.io.*;


/**
 * �ļ������࣬���ڶ�ȡvxml�ļ�
 * @author Administrator
 */
public class FileAccess {

	/**
	 * ��ȡvxml�ļ���������������Ϊ�ַ�������
	 * @param path �ļ���·��
	 * @return ��ȡ����vxml����
	 * @throws IOException
	 */
	public static String readVxmlFile(String path) throws IOException{
		BufferedInputStream bufferInput = null;
		StringBuffer buffer = new StringBuffer();
		try
		{
			File vxmlFile = new File(path);
			bufferInput = new BufferedInputStream(new FileInputStream(vxmlFile));
			int readBytes = 0;
			while( (readBytes=bufferInput.read()) != -1)
			{
				buffer.append((char)readBytes);
			}
			
			return buffer.toString();
		} catch (Exception ex) {
			return "";
		}
		finally
		{
			if(bufferInput!=null) {
				bufferInput.close();
			}
		}
	}
	
	/**
	 * ���� ����.gt.;���滻Ϊ>�ȣ�
	 * @param input �����ַ���
	 * @return �������ַ���
	 */
	public static String Decode(String input){
		String output = input;
		output = output.replace("&amp;", "&");
		output = output.replace("&lt;", "<");
		output = output.replace("&gt;", ">");
		output = output.replace("&quot;", "\"");
		return output;
	}
	
	/**
	 * ����  ����>���滻Ϊ .gt.;�ȣ�
	 * @param input
	 * @return
	 */
	public static String Encode(String input){
		if(input==null || input.isEmpty()){
			return "";
		}
		
		String output = input;
		output = output.replace("&","&amp;");
		output = output.replace("<","&lt;");
		output = output.replace(">","&gt;");
		output = output.replace("\"","&quot;");
		return output;
	}
}
