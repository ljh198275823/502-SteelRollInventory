VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ChengDe"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
'/�ײ㶯̬��
'///////////��������
Private Declare Function ic_init Lib "MWIC_32" (ByVal port As Long, ByVal Baud As Long) As Long
Private Declare Function ic_exit Lib "MWIC_32" (ByVal icDev As Long) As Long
Private Declare Function csc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long
Private Declare Function wsc_4442 Lib "MWIC_32" (ByVal icDev As Long, ByVal leng As Long, ByVal databuff As String) As Long

'///////////IC������
Private Declare Function rdcompany Lib "BGCard" (ByVal icDev As Long, isTrue As Byte) As Long
Private Declare Function readCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, cardAmount As Single, meterAmount As Single, TestAmount As Single, inserted As Byte) As Long
Private Declare Function MakeCard Lib "BGCard" Alias "makeCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String, ByVal mark As Byte) As Long
Private Declare Function writeCard Lib "BGCard" (ByVal icDev As Long, ByVal userCode As String, ByVal Amount As Single, ByVal saveInfo As String) As Long
Private Declare Function ClearCard Lib "BGCard" Alias "clearCard" (ByVal icDev As Long, ByVal userCode As String) As Long
Private Declare Function writetoolCard Lib "BGCard" (ByVal icDev As Long, ByVal WriteType As Long, ByVal TestAmount As Single, ByVal TestTimes As Long) As Long

'////ȫ�ֱ��������淵����Ϣ
Private Sub WriteInfo(s As String)
    Open App.Path & "\saveinf.txt" For Output As #1
    Print #1, s
    Close #1
End Sub

Private Function ReadInfo() As String
    Open App.Path & "\saveinf.txt" For Input As #1
    Dim FileData As String
    Input #1, FileData
    ReadInfo = FileData
    Close #1
End Function

Private Function ChengdeErr(ByVal err As Integer) As String
    ChengdeErr = "δ֪����"
    Select Case err
        Case 1
            ChengdeErr = "���������Ǵ����"
        Case 2
            ChengdeErr = "û������û�"
        Case 3
            ChengdeErr = "�������ݳ���"
        Case 6
            ChengdeErr = "����������"
        Case 9
            ChengdeErr = "�û��źͿ�����Ӧ"
        Case 10
            ChengdeErr = "д������"
        Case 11
            ChengdeErr = "��������"
        Case 13
            ChengdeErr = "�û��ų��ȴ���"
        Case 14
            ChengdeErr = "�û����ַ��Ƿ�"
        Case 15
            ChengdeErr = "�û����Ѵ���"
        Case 16
            ChengdeErr = "�ǲ��ڿ�"
        Case 17
            ChengdeErr = "У�鿨�������"
        Case 18
            ChengdeErr = "���ݴ���"
        Case 19
            ChengdeErr = "IC���ѱ���"
        Case 20
            ChengdeErr = "���������ڿ��ڴ�������"
        Case 21
            ChengdeErr = "���û���"
        Case 22
            ChengdeErr = "У��ʹ���"
        Case 23
            ChengdeErr = "��������"
    End Select
End Function
'-----------------------------------------------------end-----------------------------------------------------

Public Function IsMyCard() As Boolean
    Dim icDev As Long
    Dim isTrue As Byte
    Dim reVal As Long
    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
    reVal = rdcompany(icDev, isTrue)
    If reVal = 0 Then
        If isTrue = 0 Then IsMyCard = True
    End If
    ic_exit icDev
End Function

Public Sub Buy()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim saveInfo As String * 16
    
    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
    userCode = FrmCardReader.txtCardID1.Text
'    saveInfo = ReadInfo
    reVal = writeCard(icDev, userCode, Val(FrmCardReader.txtAmount.Text), saveInfo)
    If reVal = 0 Then
'        WriteInfo saveInfo
        MsgBox "�����ɹ���"
    Else
        MsgBox "����ʧ�ܣ�����:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Public Sub Back()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim saveInfo As String * 16
    
    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
    userCode = FrmCardReader.txtCardID1.Text
'    saveInfo = ReadInfo
    reVal = writeCard(icDev, userCode, 0, saveInfo)
    If reVal = 0 Then
'        WriteInfo saveInfo
        MsgBox "�����ɹ���"
    Else
        MsgBox "����ʧ�ܣ�����:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Private Function CheckForMake() As Boolean
    If Len(FrmCardReader.txtCardID.Text) <> 8 Then
        MsgBox "���Ų���ȷ��Ӧ��Ϊ8λ����"
        CheckForMake = False
        Exit Function
    End If
    If Not IsNumeric(FrmCardReader.txtCardID.Text) Then
        MsgBox "���Ų��ܰ���������"
        CheckForMake = False
        Exit Function
    End If
    CheckForMake = True
End Function

Public Sub Make()
    Dim icDev As Long
    Dim reVal As Long
    
    Dim saveInfo As String * 16
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
        reVal = MakeCard(icDev, FrmCardReader.txtCardID.Text, 0, saveInfo, 129)
        If reVal = 0 Then
'            WriteInfo saveInfo
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Public Sub Remake()
    Dim icDev As Long
    Dim reVal As Long
    Dim saveInfo As String * 16
    
    If CheckForMake() Then
        icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
'        saveInfo = ReadInfo
        reVal = MakeCard(icDev, FrmCardReader.txtCardID.Text, 0, saveInfo, 0)  '//mark=0 ���һ�ι���δ���뵽�����ڣ�mark=1 ���һ�ι��������뵽����
        If reVal = 0 Then
'            WriteInfo saveInfo
            MsgBox "�����ɹ�"
        Else
            MsgBox "����ʧ�ܣ�����:" & ChengdeErr(reVal)
        End If
        ic_exit icDev
    End If
End Sub

Public Sub Clear()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    
    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
    userCode = FrmCardReader.txtCardID1.Text
    reVal = ClearCard(icDev, userCode)
    If reVal = 0 Then
        MsgBox "�忨�ɹ���"
    Else
        MsgBox "�忨ʧ�ܣ�����:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Public Sub Read()
    Dim icDev As Long
    Dim reVal As Long
    Dim userCode As String * 8
    Dim cardAmount, meterAmount, TestAmount As Single
    Dim inserted As Byte
    Dim times As Long
    
    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
    reVal = readCard(icDev, userCode, cardAmount, meterAmount, TestAmount, inserted)
    If reVal = 0 Then
        Call CheckReadCount
        Call IncreaseReadCount
        FrmCardReader.txtCardID1.Text = userCode
        FrmCardReader.txtAmount.Text = cardAmount
        FrmCardReader.List1.AddItem "����:" & userCode
        FrmCardReader.List1.AddItem "��������:" & cardAmount
        FrmCardReader.List1.AddItem "��������:" & meterAmount
        FrmCardReader.List1.AddItem IIf(inserted = 0, "δ", "��") & "�������ϲ忨"
    Else
        MsgBox "����ʧ�ܣ�����:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub

Public Sub MakeTool()
    Dim icDev As Long
    Dim reVal As Long

    icDev = ic_init(My_Commport - 1, 9600) '���ں�0��ʼ������Ҫ��һ
    If FrmCardReader.Option1(0).Value Then
        reVal = writetoolCard(icDev, 5, 0, 0)
    ElseIf FrmCardReader.Option1(1).Value Then
        reVal = writetoolCard(icDev, 9, 0, 0)
    ElseIf FrmCardReader.Option1(2).Value Then
        reVal = writetoolCard(icDev, 7, 0, 0)
    End If
    If reVal = 0 Then
        MsgBox "�����߿��ɹ���"
    Else
        MsgBox "�����߿�ʧ�ܣ�����:" & ChengdeErr(reVal)
    End If
    ic_exit icDev
End Sub


