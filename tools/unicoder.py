
import unittest
import os.path
import shutil
import filecmp

encodingHash = {}

kBomUtf8 = '\xEF\xBB\xBF'
kBomUtf16Be = '\xFE\xFF'
kBomUtf16Le = '\xFF\xFE'
kBomAnsi = ''

def InferEncoding (text):
	if text.startswith (kBomUtf8):
		return 'utf-8'
       	elif text.startswith (kBomUtf16Be): 
		return 'utf-16-be'
	elif text.startswith (kBomUtf16Le):
		return 'utf-16-le'
	else:
		return 'iso-8859-1' # "ansi"

class InvalidEncodingException (Exception):
	pass

def OffsetFromEncoding (encoding):
	if encoding == 'utf-8':
		return len (kBomUtf8)
	elif encoding == 'utf-16-be':
		return len (kBomUtf16Be) 
	elif encoding == 'utf-16-le':
		return len (kBomUtf16Le) 
	elif encoding == 'iso-8859-1': # "ansi"
		return len (kBomAnsi) 
	else:
		raise InvalidEncodingException ()

def UnicodeSmartRead (path):
	global encodingHash 
	absPath = os.path.abspath (path)
	rawText = open (absPath).read ()  
	encoding = InferEncoding (rawText)
	encodingHash [absPath] = encoding
	return rawText[OffsetFromEncoding (encoding):].decode (encoding)

def BomFromEncoding (encoding):
	if encoding == 'utf-8':
		return kBomUtf8 
	elif encoding == 'utf-16-be':
		return kBomUtf16Be 
	elif encoding == 'utf-16-le':
		return kBomUtf16Le
	elif encoding == 'iso-8859-1':
		return kBomAnsi 
	else:
		raise InvalidEncodingException ()


def UnicodeSmartWrite (path, u_text):
	global encodingHash
	absPath = os.path.abspath (path)
	encoding = encodingHash [absPath] 
	open (absPath, "w").write (BomFromEncoding (encoding) + u_text.encode (encoding))
	del encodingHash [absPath]


if __name__ == '__main__':
	class TestThis (unittest.TestCase):
		def testInferEncoding0 (self):
			assert InferEncoding (open (r"dummy\utf-8.txt").read ()) == 'utf-8'
			assert InferEncoding (open (r"dummy\unicode.txt").read ()) == 'utf-16-le'
			assert InferEncoding (open (r"dummy\unicode-big-endian.txt").read ()) == 'utf-16-be'
			assert InferEncoding (open (r"dummy\ansi.txt").read ()) == 'iso-8859-1'

		def testUnicodeSmartRead (self):
			global encodingHash
			encodingHash = {}

			u_text = UnicodeSmartRead (r"dummy\utf-8.txt")
			assert len (u_text) == 21
			assert encodingHash [os.path.abspath (r"dummy\utf-8.txt")] == 'utf-8'

			encodingHash = {}

			u_text = UnicodeSmartRead (r"dummy\unicode.txt")
			assert len (u_text) == 21
			assert encodingHash [os.path.abspath (r"dummy\unicode.txt")] == 'utf-16-le'

			encodingHash = {}

			u_text = UnicodeSmartRead (r"dummy\unicode-big-endian.txt")
			assert len (u_text) == 21
			assert encodingHash [os.path.abspath (r"dummy\unicode-big-endian.txt")] == 'utf-16-be'

			encodingHash = {}

			u_text = UnicodeSmartRead (r"dummy\ansi.txt")
			assert len (u_text) == 21 
			assert encodingHash [os.path.abspath (r"dummy\ansi.txt")] == 'iso-8859-1'

			encodingHash = {}

		def testUnicodeSmartWrite (self):
			shutil.copyfile (r"dummy\utf-8-orig.txt", r"dummy\utf-8.txt")
			UnicodeSmartWrite (r"dummy\utf-8.txt", UnicodeSmartRead (r"dummy\utf-8.txt") + u".")
			assert filecmp.cmp (r"dummy\utf-8.txt", r"dummy\utf-8-result.txt") == 1
			shutil.copyfile (r"dummy\utf-8-orig.txt", r"dummy\utf-8.txt")

			shutil.copyfile (r"dummy\unicode-orig.txt", r"dummy\unicode.txt")
			UnicodeSmartWrite (r"dummy\unicode.txt", UnicodeSmartRead (r"dummy\unicode.txt") + u".")
			assert filecmp.cmp (r"dummy\unicode.txt", r"dummy\unicode-result.txt") == 1
			shutil.copyfile (r"dummy\unicode-orig.txt", r"dummy\unicode.txt")

			shutil.copyfile (r"dummy\unicode-big-endian-orig.txt", r"dummy\unicode-big-endian.txt")
			UnicodeSmartWrite (r"dummy\unicode-big-endian.txt", UnicodeSmartRead (r"dummy\unicode-big-endian.txt") + u".")
			assert filecmp.cmp (r"dummy\unicode-big-endian.txt", r"dummy\unicode-big-endian-result.txt") == 1
			shutil.copyfile (r"dummy\unicode-big-endian-orig.txt", r"dummy\unicode-big-endian.txt")

			shutil.copyfile (r"dummy\ansi-orig.txt", r"dummy\ansi.txt")
			UnicodeSmartWrite (r"dummy\ansi.txt", UnicodeSmartRead (r"dummy\ansi.txt") + u".")
			assert filecmp.cmp (r"dummy\ansi.txt", r"dummy\ansi-result.txt")
			shutil.copyfile (r"dummy\ansi-orig.txt", r"dummy\ansi.txt")

	unittest.main ()


