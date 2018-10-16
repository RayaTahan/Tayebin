Imports System.Text

Public Class Imager
    Public Enum ImageFormat
        unKnown = 0
        BMP = 1
        JPEG = 2
        GIF = 3
        TIFF = 4
        PNG = 5
    End Enum

    Public Shared Function GetImageFormat(bytes As Byte()) As ImageFormat
        ' see http://www.mikekunz.com/image_file_header.html  
        ' see https://web.archive.org/web/20090302032444/http://www.mikekunz.com/image_file_header.html 
        ' see https://stackoverflow.com/questions/210650/validate-image-from-file-in-c-sharp/9446045#9446045

        Dim bmp = Encoding.ASCII.GetBytes("BM")         ' bmp
        Dim gif = Encoding.ASCII.GetBytes("GIF")        ' GIF
        Dim png = New Byte() {137, 80, 78, 71}          ' PNG
        Dim tiff = New Byte() {73, 73, 42}              ' TIFF
        Dim tiff2 = New Byte() {77, 77, 42}             ' TIFF
        Dim jpeg = New Byte() {255, 216, 255, 224}      ' jpeg
        Dim jpeg2 = New Byte() {255, 216, 255, 225}     ' jpeg canon

        If (bmp.SequenceEqual(bytes.Take(bmp.Length))) Then Return ImageFormat.BMP
        If (gif.SequenceEqual(bytes.Take(gif.Length))) Then Return ImageFormat.GIF
        If (png.SequenceEqual(bytes.Take(png.Length))) Then Return ImageFormat.PNG
        If (tiff.SequenceEqual(bytes.Take(tiff.Length))) Then Return ImageFormat.TIFF
        If (tiff2.SequenceEqual(bytes.Take(tiff2.Length))) Then Return ImageFormat.TIFF
        If (jpeg.SequenceEqual(bytes.Take(jpeg.Length))) Then Return ImageFormat.JPEG
        If (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length))) Then Return ImageFormat.JPEG

        Return ImageFormat.unKnown
    End Function
End Class
