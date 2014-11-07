VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "GoldCard"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
''����
'����:     intcom: ���ں� com1Ϊ0, com2Ϊ1
'Baud������ͨѶ�����ʣ�1200��115200����
'          vskh���û����ţ�00000000��99999999����
'vlql�� ����������
'vics: �����ڹ�������
'viklx�������ͣ�1���ñ���2��ҵ����3���㿨��4���̿�����ת�ƿ���
'  ����ֵ��int
'          = 0����ȷ
'����:  �������ж���
Private Declare Function Gold_Readcard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByRef userNo As String, ByRef vlql As Long, ByRef vics As Integer, ByRef viklx As Integer) As Long

'����
Private Declare Function Gold_Buycard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String, ByVal vlql As Long, ByVal vics As Long) As Long

'�����������
Private Declare Function Gold_Clearcard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long, ByVal userNo As String) As Long

'���ش�����Ϣ�ַ���
Private Declare Sub Error_message Lib "GoldCard" (ByVal errCode As Long, ByVal msg As String)

'����Ƿ��Ǳ���˾�Ŀ� ����ֵ 0���û�����1�����߿�������������
Private Declare Function Gold_CheckCard Lib "GoldCard" (ByVal intcom As Integer, ByVal Baud As Long) As Long

'ע������
'1�� ��������һ��Ҫ��ȷ����������ֻ�ܱ��ϴι��������󣬷�����᲻�Ͽ���
'2�� ����д��ʱ��������ڻ���������DLL��ѿ��ڵ������滻�ˣ���������ӡ�

'-----------------------------------end--------------------------------------------------------------------

Public Sub Make()
    MsgBox "�㽭�𿨲�֧�ַ�������"
End Sub

Public Sub Remake()
    MsgBox "�㽭�𿨲�֧�ֲ�������"
End Sub

Public Sub MakeTool()
    MsgBox "�㽭�𿨲�֧�ֹ��߿�����"
End Sub

Public Sub Buy()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Buycard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, Val(FrmCardReader.txtAmount.Text), Val(FrmCardReader.txtCount.Text))
    If ret = 0 Then
        MsgBox "�����ɹ���"
        FrmCardReader.cmdBuy.Enabled = False
    Else
        Call Error_message(ret, msg)
        MsgBox "����ʧ�ܣ�����:" & msg
    End If
End Sub

Public Sub Back()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Buycard(My_Commport - 1, 9600, FrmCardReader.txtCardID1.Text, 0, IIf(Val(FrmCardReader.txtCount.Text) > 1, Val(FrmCardReader.txtCount.Text) - 1, 0))
    If ret = 0 Then
        MsgBox "�����ɹ���"
        FrmCardReader.cmdBuy.Enabled = False
    Else
        Call Error_message(ret, msg)
        MsgBox "����ʧ�ܣ�����:" & msg
    End If
End Sub

Public Sub Clear()
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_Clearcard(My_Commport - 1, 9600, FrmCardReader.txtCardID.Text)
    If ret = 0 Then
        MsgBox "�忨�ɹ���"
    Else
        Call Error_message(ret, msg)
        MsgBox "�忨ʧ�ܣ�����:" & msg
    End If
End Sub

Public Sub Read()
    Dim ret As Long
    Dim userNo As String
    Dim vlql As Long
    Dim vics As Integer
    Dim viklx As Integer
    Dim msg As String * 50
    
    Call CheckReadCount
    Call IncreaseReadCount
    FrmCardReader.List1.Clear
    
    ret = Gold_Readcard(My_Commport - 1, 9600, userNo, vlql, vics, viklx) '���ں�0��ʼ������Ҫ��һ
    If ret = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        FrmCardReader.txtCardID1.Text = userCode
        FrmCardReader.List1.AddItem "���ţ�" & userCode
        FrmCardReader.txtAmount.Text = vlql
        FrmCardReader.List1.AddItem "��Ƭ��������" & vlql
        FrmCardReader.txtCount.Text = vics + 1
        FrmCardReader.List1.AddItem "����������" & vics
        Select Case viklx
            Case 1
                FrmCardReader.List1.AddItem "��Ƭ���ͣ����ÿ�"
            Case 2
                FrmCardReader.List1.AddItem "��Ƭ���ͣ���ҵ��"
            Case 3
                FrmCardReader.List1.AddItem "��Ƭ���ͣ����㿨"
            Case 4
                FrmCardReader.List1.AddItem "��Ƭ���ͣ�ת�ƿ�"
        End Select
        FrmCardReader.cmdBuy.Enabled = True
        FrmCardReader.CmdTool.Enabled = False
        FrmCardReader.cmdClear.Enabled = True
        FrmCardReader.CmdBack.Enabled = True
    Else
        Call Error_message(ret, msg)
        MsgBox "����ʧ�ܣ�����:" & msg
    End If
End Sub

Public Function IsMyCard() As Boolean
    Dim ret As Long
    Dim msg As String * 50
    
    ret = Gold_CheckCard(My_Commport - 1, 9600)
    If ret = 0 Or ret = 1 Then
        IsMyCard = True
    End If
End Function



