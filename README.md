# ahplA - Simple reverse alpha composition

This program is a simple tool for finding a transparent image(source) from an original image(destination) and an alpha-synthesized image.

When there is an alpha-composited image C made from a translucent image A (0 <= alpha <= 1) composited over another opaque image B (alpha == 1), each r,g,b values are calculated as follows:

Crgb = Argb * Aa + Brgb * (1 - Aa)

If you have an opaque image B that has not yet been synthesized here and you want to get A using these, there are three expressions, but the number of unknowns is four, so you get infinite number of values.
If the pixel format is 32bppARGB, then a,r,g,b are integers with values ​​from 0 to 255, so the range of possible solutions is not very wide. Therefore, assuming that "a" is a certain value, and calculating rgb, you can get several solutions including the value that was originally in A (correct answer). Since there is no r, g, or b for all "a", the number of solution is larger than 0 and less than 256 (there always is an answer if "a" is 1; and we don't have to think about the case where "a" is 0).
This program outputs A when B and C are given. In this case, there are 4 options for the assumption of "a":

L: Finds a pixel value with minimum "a" by incrementing "a" from 1.

M: From 85. If there is no answer up to 170, it searches from 1. If there is no answer from 1 to 170, it searches from 171.

H: From 171. If there is no answer up to 255, this option is equal to M.

N: Assume "a" is 255. Therefore, rgb values are equal to the value of C.

If a pixel value ​​of A and C are the same, then the output pixel becomes transparent. If at least one of r, g, or b of two pixels is different, the value is only calculated if this difference is greater than another option TH(the text box above the radio buttons), otherwise the pixel becomes transparent. Therefore, if TH is 0, every different pixels are calculated.

Also, even if specific rgb exists for an "a"(assumed value), if the order of the sizes of r, g, and b is different from the order of size of r, g, and b in C, this output value is ignored. This is based on the experience that r, g, and b for at smallest "a" are complementary to B, in a large number of cases. If you do not need it, you can delete this part.

If TH is 0, you can use either L, M, H, or N to get the original C when you synthesize the output image A to B. However, it is very unlikely that the output image A is actually the completely correct answer.

Note: This program splits the image into 16 smaller images for faster processing. And it uses Graphics.FromImage and DrawImage for partial cloning of images. In my experience, this method may not duplicate the original image with the same pixel value. If it is necessary to preserve pixel values completely, it is recommended to use other methods such as LockBits.

How to use:
1. Drag image file B and place it in the upper text box.
2. Drag image file C into the text box below.
3. Determine the TH and options, and click GO to get PNG image A with an underbar(_) after its original filename.



이 프로그램은 원본 이미지(destination)와 알파 합성된 이미지가 주어졌을 때, 합성된 투명 이미지(source)를 구하기 위한 간단한 툴입니다.

어떤 반투명 이미지 A(0 <= alpha <= 1)가 다른 불투명 이미지 B(alpha == 1) 위에 합성되어 있는(alpha composition) 이미지 C가 있을 때, C의 각 픽셀에 대한 r,g,b값은 다음과 같이 계산됩니다.

Crgb = Argb * Aa + Brgb * (1 - Aa)

여기서 아직 합성되지 않은 불투명 이미지 B를 가지고 있고, 이들을 이용해서 A를 구하고 싶다면, 식은 3개인데 미지수는 4개이므로 해가 무수히 많아집니다.
만약 픽셀 포맷이 32bppARGB라면, 여기서의 a,r,g,b는 0~255의 값을 갖는 정수이므로 얻을 수 있는 해의 범위가 별로 넓지 않습니다. 따라서 a를 어떤 값이라고 가정하고 r,g,b를 계산하면 원래 A에 들어있던 값(정답)을 포함한 여러 개의 해를 얻을 수 있습니다. 모든 a에 대해 r,g,b가 있지는 않으므로 해는 1개 이상 ~ 255개 이하가 됩니다(a가 1이면 무조건 답이 있고, a가 0인 경우는 무시).
이 프로그램은 B와 C가 주어졌을 때 위의 방법으로 각 픽셀을 계산하여 A를 출력합니다. 이때 가정되는 a는 4가지 중에서 선택할 수 있습니다.

L: a를 1부터 증가시켜 최소한의 a를 갖는 픽셀값을 찾습니다.

M: a를 85부터 증가시킵니다. 170까지 답이 없으면 1부터 찾습니다. 1~170에 답이 없으면 171부터 찾습니다.

H: a를 171부터 증가시킵니다. 255까지 답이 없으면 M과 같습니다.

N: a를 255라고 가정합니다. 따라서 r,g,b는 C의 값과 같습니다.

만약 A와 C의 픽셀값이 똑같은 픽셀은 투명 처리됩니다. 두 픽셀의 r,g,b 중 하나 이상이 다르다면, 이 차이가 또 다른 옵션인 TH(radio button 위에 있는 텍스트 박스)보다 클 경우에만 계산해서 값을 출력하고, 아니면 해당 픽셀은 투명 처리합니다. 따라서 TH가 0이라면 r,g,b중 1만 차이가 나도 계산을 하게 됩니다.

또한 어떤 a(가정값)에 대한 r,g,b가 있더라도, 이 r,g,b의 크기 순서가 C의 r,g,b의 크기 순서와 다르다면 해당 답을 버립니다. 이것은 상당히 많은 경우에서 최소a에 대한 r,g,b가 B의 보색이 된다는 경험에 근거한 것인데 필요없다면 해당 부분은 삭제하고 사용하시면 됩니다.

TH가 0이라면, L,M,H,N 중 어떤 옵션을 사용해도 출력 이미지 A를 B에 합성할 경우 완전한 C를 얻을 수 있습니다. 그러나 출력된 A가 실제 정답일 가능성은 거의 없습니다.

참고: 이 프로그램은 처리 속도를 높이기 위해 이미지를 16개로 분할하여 동시에 처리합니다. 이때 이미지의 부분 복제를 위해 Graphics.FromImage와 DrawImage를 사용합니다. 제 경험상 이 방법은 원 이미지를 똑같은 픽셀값으로 복제하지 않을 가능성이 있습니다. 픽셀값의 온전한 보존이 필요하다면 LockBits등 다른 방법을 사용하시기를 권장합니다.

사용법:
1. 이미지 파일 B를 드래그하여 위쪽 텍스트 박스에 넣습니다.
2. 이미지 파일 C를 그래그하여 아래쪽 텍스트 박스에 넣습니다.
3. TH와 옵션을 결정하고 GO 버튼을 클릭하면 원 이미지 이름에 언더바(_)가 붙은 PNG 이미지 A가 출력됩니다.