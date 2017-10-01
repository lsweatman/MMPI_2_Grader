using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Try_2.Static
{
    public class RawScales
    // Values for what responses up the count for each scale
    {
        // For calculating gender based scales
        private bool gender; // male == true, female == false

        // Full after population method
        private List<List<int[]>> allRawScales = new List<List<int[]>>();

        private List<int[]> basicScales = new List<int[]>();
        private List<int[]> harrisLingoesScales = new List<int[]>();
        private List<int[]> wienerHarmonScales = new List<int[]>();
        private List<int[]> siSubScales = new List<int[]>();
        private List<int[]> supplementalScales = new List<int[]>();

        public RawScales()
        {
            gender = true;

            // If you add it first then populate later it still adds to the allRawScales
            allRawScales.Add(basicScales);
            allRawScales.Add(harrisLingoesScales);
            allRawScales.Add(wienerHarmonScales);
            allRawScales.Add(siSubScales);
            allRawScales.Add(supplementalScales);
        }

        public void setGender(bool passedGender)
        {
            gender = passedGender;
        }

        public void populateScales() // There is no pattern to this madness
        {
            #region BASIC SCALES
            basicScales.Add(new int[0]); //lTrue
            basicScales.Add(new int[15] { 16, 29, 41, 51, 77, 93, 102, 107, 123, 139, 153, 183, 203, 232, 260 }); //lFalse

            basicScales.Add(new int[41] { 18, 24, 30, 36, 42, 48, 54, 60, 66, 72, 84, 96, 114, 138, 144, 150, 156, 162, 168, 180, 198, 216, 228, 234, 240, 246, 252, 258, 264, 270, 282, 288, 294, 300, 306, 312, 324, 336, 349, 355, 361 }); //fTrue
            basicScales.Add(new int[19] { 6, 12, 78, 90, 102, 108, 120, 126, 132, 174, 186, 192, 204, 210, 222, 276, 318, 330, 343 }); //fFalse

            basicScales.Add(new int[1] { 83 }); //kTrue
            basicScales.Add(new int[29] { 29, 37, 58, 76, 110, 116, 122, 127, 130, 136, 148, 157, 158, 167, 171, 196, 213, 243, 267, 284, 290, 330, 338, 339, 341, 346, 348, 356, 365 }); //kFalse

            basicScales.Add(new int[11] { 18, 28, 39, 53, 59, 97, 101, 111, 149, 175, 247 }); //hsTrue
            basicScales.Add(new int[21] { 2, 3, 8, 10, 20, 45, 47, 57, 91, 117, 141, 143, 152, 164, 173, 176, 179, 208, 224, 249, 255 }); //hsFalse 

            basicScales.Add(new int[20] { 5, 15, 18, 31, 38, 39, 46, 56, 73, 92, 117, 127, 130, 146, 147, 170, 175, 181, 215, 233 }); //dTrue
            basicScales.Add(new int[37] { 2, 9, 10, 20, 29, 33, 37, 43, 45, 49, 55, 68, 75, 76, 95, 109, 118, 134, 140, 141, 142, 143, 148, 165, 178, 188, 189, 212, 221, 223, 226, 238, 245, 248, 260, 267, 330 }); //dFalse

            basicScales.Add(new int[] { 11, 18, 31, 39, 40, 44, 65, 101, 166, 172, 175, 218, 230 }); //hyTrue
            basicScales.Add(new int[47] { 2, 3, 7, 8, 9, 10, 14, 26, 29, 45, 47, 58, 76, 81, 91, 95, 98, 110, 115, 116, 124, 125, 129, 135, 141, 148, 151, 152, 157, 159, 161, 164, 167, 173, 176, 179, 185, 193, 208, 213, 224, 241, 243, 249, 253, 263, 265 }); //hyFalse

            basicScales.Add(new int[24] { 17, 21, 22, 31, 32, 35, 42, 52, 54, 56, 71, 82, 89, 94, 99, 105, 113, 195, 202, 219, 225, 259, 264, 288 }); //pdTrue
            basicScales.Add(new int[26] { 9, 12, 34, 70, 79, 83, 95, 122, 125, 129, 143, 157, 158, 160, 167, 171, 185, 209, 214, 217, 226, 243, 261, 263, 266, 267 }); //pdFalse

            if (gender) // Male
            {
                basicScales.Add(new int[25] { 4, 25, 62, 64, 67, 74, 80, 112, 119, 122, 128, 137, 166, 177, 187, 191, 196, 205, 209, 219, 236, 251, 256, 268, 271 }); //mfmTrue
                basicScales.Add(new int[31] { 1, 19, 26, 27, 63, 68, 69, 76, 86, 103, 104, 107, 120, 121, 132, 133, 163, 184, 193, 194, 197, 199, 201, 207, 231, 235, 237, 239, 254, 257, 272 }); //mfmFalse
            }

            if (!gender) // Female
            {
                basicScales.Add(new int[23] { 4, 25, 62, 64, 67, 74, 80, 112, 119, 121, 122, 128, 137, 177, 187, 191, 196, 205, 219, 236, 251, 256, 271 }); //mffTrue
                basicScales.Add(new int[33] { 1, 19, 26, 27, 63, 68, 69, 76, 86, 103, 104, 107, 120, 132, 133, 163, 166, 184, 193, 194, 197, 199, 201, 207, 209, 231, 235, 237, 239, 254, 257, 268, 272 }); //mffFalse
            }

            basicScales.Add(new int[25] { 16, 17, 22, 23, 24, 42, 99, 113, 138, 144, 145, 146, 162, 234, 259, 271, 277, 285, 305, 307, 333, 334, 336, 355, 361 }); //paTrue
            basicScales.Add(new int[15] { 81, 95, 98, 100, 104, 110, 244, 255, 266, 283, 284, 286, 297, 314, 315 }); //paFalse

            basicScales.Add(new int[39] { 11, 16, 23, 31, 38, 56, 65, 73, 82, 89, 94, 130, 147, 170, 175, 196, 218, 242, 273, 275, 277, 285, 289, 301, 302, 304, 308, 309, 310, 313, 316, 317, 320, 325, 326, 327, 328, 329, 331 }); //ptTrue
            basicScales.Add(new int[9] { 3, 9, 33, 109, 140, 165, 174, 293, 321 }); //ptFalse

            basicScales.Add(new int[59] { 16, 17, 21, 22, 23, 31, 32, 35, 38, 42, 44, 46, 48, 65, 85, 92, 138, 145, 147, 166, 168, 170, 180, 182, 190, 218, 221, 229, 233, 234, 242, 247, 252, 256, 268, 273, 274, 277, 279, 281, 287, 291, 292, 296, 298, 299, 303, 307, 311, 316, 319, 320, 322, 323, 325, 329, 332, 333, 355 }); //scTrue
            basicScales.Add(new int[19] { 6, 9, 12, 34, 90, 91, 106, 165, 177, 179, 192, 210, 255, 276, 278, 280, 290, 295, 343 }); //scFalse

            basicScales.Add(new int[35] { 13, 15, 21, 23, 50, 55, 61, 85, 87, 98, 113, 122, 131, 145, 155, 168, 169, 182, 190, 200, 205, 206, 211, 212, 218, 220, 227, 229, 238, 242, 244, 248, 250, 253, 269 }); //maTrue
            basicScales.Add(new int[11] { 88, 93, 100, 106, 107, 136, 154, 158, 167, 243, 263 }); //maFalse

            basicScales.Add(new int[36] { 31, 56, 70, 100, 104, 110, 127, 135, 158, 161, 167, 185, 215, 243, 251, 265, 275, 284, 289, 296, 302, 308, 326, 328, 337, 338, 347, 348, 351, 352, 357, 358, 364, 367, 368, 369 }); //siTrue
            basicScales.Add(new int[33] { 25, 32, 49, 79, 86, 106, 112, 131, 181, 189, 207, 209, 231, 237, 255, 262, 267, 280, 321, 335, 340, 342, 344, 345, 350, 353, 354, 359, 360, 362, 363, 366, 370 }); //siFalse
            #endregion BASIC_SCALES                                                                                                                                                                                              // End BASIC SCALES

            #region HARRIS-LINGOES SUBSCALES
            harrisLingoesScales.Add(new int[15] { 31, 38, 39, 46, 56, 73, 92, 127, 130, 146, 147, 170, 175, 215, 233 }); //d1True
            harrisLingoesScales.Add(new int[17] { 2, 9, 43, 49, 75, 95, 109, 118, 140, 148, 178, 188, 189, 223, 260, 267, 330 }); //d1False

            harrisLingoesScales.Add(new int[4] { 38, 46, 170, 233 }); //d2True
            harrisLingoesScales.Add(new int[10] { 9, 29, 37, 49, 55, 76, 134, 188, 189, 212 }); //d2False

            harrisLingoesScales.Add(new int[4] { 18, 117, 175, 181 }); //d3True
            harrisLingoesScales.Add(new int[7] { 2, 20, 45, 141, 142, 143, 148 }); //d3False

            harrisLingoesScales.Add(new int[8] { 15, 31, 38, 73, 92, 147, 170, 233 }); //d4True
            harrisLingoesScales.Add(new int[7] { 9, 10, 43, 75, 109, 165, 188 }); //d4False

            harrisLingoesScales.Add(new int[8] { 38, 56, 92, 127, 130, 146, 170, 215 }); //d5True
            harrisLingoesScales.Add(new int[2] { 75, 95 }); //d5False

            harrisLingoesScales.Add(new int[0]); //hy1True
            harrisLingoesScales.Add(new int[6] { 129, 161, 167, 185, 243, 265 }); //hy1False

            harrisLingoesScales.Add(new int[1] { 230 }); //hy2True
            harrisLingoesScales.Add(new int[11] { 26, 58, 76, 81, 98, 110, 124, 151, 213, 241, 263 }); //hy2False

            harrisLingoesScales.Add(new int[5] { 31, 39, 65, 175, 218 }); //hy3True
            harrisLingoesScales.Add(new int[10] { 2, 3, 9, 10, 45, 95, 125, 141, 148, 152 }); //hy3False

            harrisLingoesScales.Add(new int[6] { 11, 18, 40, 44, 101, 172 }); //hy4True
            harrisLingoesScales.Add(new int[11] { 8, 47, 91, 159, 164, 173, 176, 179, 208, 224, 249 }); //hy4False

            harrisLingoesScales.Add(new int[0]); //hy5True
            harrisLingoesScales.Add(new int[7] { 7, 14, 29, 115, 116, 135, 157 }); //hy5False

            harrisLingoesScales.Add(new int[5] { 21, 54, 195, 202, 288 }); //pd1True
            harrisLingoesScales.Add(new int[4] { 83, 125, 214, 217 }); //pd1False

            harrisLingoesScales.Add(new int[2] { 35, 105 }); //pd2True
            harrisLingoesScales.Add(new int[6] { 34, 70, 129, 160, 263, 266 }); //pd2False

            harrisLingoesScales.Add(new int[0]);//pd3True
            harrisLingoesScales.Add(new int[6] { 70, 129, 158, 167, 185, 243 }); //pd3False

            harrisLingoesScales.Add(new int[10] { 17, 22, 42, 56, 82, 99, 113, 219, 225, 259 }); //pd4True
            harrisLingoesScales.Add(new int[3] { 12, 129, 157 }); //pd4False

            harrisLingoesScales.Add(new int[10] { 31, 32, 52, 56, 71, 82, 89, 94, 113, 264 }); //pd5True
            harrisLingoesScales.Add(new int[2] { 9, 95 }); //pd5False

            harrisLingoesScales.Add(new int[16] { 17, 22, 42, 99, 113, 138, 144, 145, 162, 234, 259, 305, 333, 336, 355, 361 }); //pa1True
            harrisLingoesScales.Add(new int[1] { 314 }); //pa1False

            harrisLingoesScales.Add(new int[7] { 22, 146, 271, 277, 285, 307, 334 }); //pa2True
            harrisLingoesScales.Add(new int[2] { 100, 244 }); //pa2False

            harrisLingoesScales.Add(new int[1] { 16 }); //pa3True
            harrisLingoesScales.Add(new int[8] { 81, 98, 104, 110, 283, 284, 286, 315 }); //pa3False

            harrisLingoesScales.Add(new int[16] { 17, 21, 22, 42, 46, 138, 145, 190, 221, 256, 277, 281, 291, 292, 320, 333 }); //sc1True
            harrisLingoesScales.Add(new int[5] { 90, 276, 278, 280, 343 }); //sc1False

            harrisLingoesScales.Add(new int[8] { 65, 92, 234, 273, 303, 323, 329, 332 }); //sc2True
            harrisLingoesScales.Add(new int[3] { 9, 210, 290 }); //sc2False

            harrisLingoesScales.Add(new int[9] { 31, 32, 147, 170, 180, 299, 311, 316, 325 }); //sc3True
            harrisLingoesScales.Add(new int[1] { 165 }); //sc3False

            harrisLingoesScales.Add(new int[11] { 31, 38, 48, 65, 92, 233, 234, 273, 299, 303, 325 }); //sc4True
            harrisLingoesScales.Add(new int[3] { 9, 210, 290 }); //sc4False

            harrisLingoesScales.Add(new int[11] { 23, 85, 168, 182, 218, 242, 274, 320, 322, 329, 355 }); //sc5True
            harrisLingoesScales.Add(new int[0]); //sc5False

            harrisLingoesScales.Add(new int[14] { 23, 32, 44, 168, 182, 229, 247, 252, 296, 298, 307, 311, 319, 355 }); //sc6True
            harrisLingoesScales.Add(new int[6] { 91, 106, 177, 179, 255, 295 }); //sc6False

            harrisLingoesScales.Add(new int[5] { 131, 227, 248, 250, 269 }); //ma1True
            harrisLingoesScales.Add(new int[1] { 263 }); //ma1False

            harrisLingoesScales.Add(new int[9] { 15, 85, 87, 122, 169, 206, 218, 242, 244 }); //ma2True
            harrisLingoesScales.Add(new int[2] { 100, 106 }); //ma2False

            harrisLingoesScales.Add(new int[3] { 155, 200, 220 }); //ma3True
            harrisLingoesScales.Add(new int[5] { 93, 136, 158, 167, 243 }); //ma3False

            harrisLingoesScales.Add(new int[9] { 13, 50, 55, 61, 98, 145, 190, 211, 212 }); //ma4True
            harrisLingoesScales.Add(new int[0]); //ma4False
            #endregion HARRIS-LINGOES SUBSCALES

            #region WIENER-HARMON SUBTLE-OBVIOUS SCALES
            wienerHarmonScales.Add(new int[] { 15, 18, 31, 38, 39, 46, 56, 73, 92, 127, 130, 146, 147, 170, 175, 215, 233 });//D-OTrue
            wienerHarmonScales.Add(new int[] { 2, 9, 10, 20, 33, 43, 45, 49, 75, 95, 109, 118, 140, 141, 142, 165, 188, 223, 245, 248, 260, 330 });//D-O False

            wienerHarmonScales.Add(new int[] { 5, 117, 181 });//D-STrue
            wienerHarmonScales.Add(new int[] { 29, 37, 55, 68, 76, 134, 143, 148, 178, 189, 212, 221, 226, 238, 267 });//D-SFalse

            wienerHarmonScales.Add(new int[] { 11, 18, 31, 39, 40, 44, 65, 101, 166, 172, 175, 218 });//Hy-OTrue
            wienerHarmonScales.Add(new int[] { 2, 3, 8, 9, 10, 45, 47, 91, 95, 115, 125, 141, 152, 159, 164, 173, 179, 208, 224, 249 });//Hy-OFalse

            wienerHarmonScales.Add(new int[] { 230 });//Hy-STrue
            wienerHarmonScales.Add(new int[] { 7, 14, 26, 29, 58, 76, 81, 98, 110, 116, 124, 129, 135, 148, 151, 157, 161, 167, 176, 185, 193, 213, 241, 243, 253, 263, 265 });//Hy-SFalse

            wienerHarmonScales.Add(new int[] { 17, 22, 31, 32, 35, 42, 52, 54, 56, 71, 82, 94, 99, 105, 195, 202, 225, 259, 264, 288 });//Pd-OTrue
            wienerHarmonScales.Add(new int[] { 9, 12, 34, 79, 95, 125, 261, 266 });//Pd-OFalse

            wienerHarmonScales.Add(new int[] { 21, 89, 113, 219 });//Pd-STrue
            wienerHarmonScales.Add(new int[] { 70, 83, 122, 129, 143, 157, 158, 160, 167, 171, 185, 209, 214, 217, 226, 243, 263, 267 });//Pd-SFalse

            wienerHarmonScales.Add(new int[] { 17, 22, 23, 24, 42, 99, 138, 144, 146, 162, 234, 259, 277, 285, 305, 307, 333, 336, 355, 361 });//Pa-OTrue
            wienerHarmonScales.Add(new int[] { 255, 266, 314 });//Pa-OFalse

            wienerHarmonScales.Add(new int[] { 16, 113, 145, 271, 334 });//Pa-STrue
            wienerHarmonScales.Add(new int[] { 81, 95, 98, 100, 104, 110, 244, 283, 284, 286, 297, 315 });//Pa-SFalse

            wienerHarmonScales.Add(new int[] { 15, 23, 50, 61, 85, 87, 145, 155, 168, 182, 190, 205, 218, 227, 229, 238, 242, 250, 253, 269 });//Ma-OTrue
            wienerHarmonScales.Add(new int[] { 100, 106, 107 });//Ma-OFalse

            wienerHarmonScales.Add(new int[] { 13, 21, 55, 98, 113, 122, 131, 169, 200, 206, 211, 212, 220, 244, 248 }); //Ma-STrue
            wienerHarmonScales.Add(new int[] { 88, 93, 136, 154, 158, 167, 243, 263 });//Ma-SFalse
            #endregion WIENER-HARMON SUBTLE-OBVIOUS SCALES

            #region SI_SCALES
            siSubScales.Add(new int[] { 158, 161, 167, 185, 243, 265, 275, 289 });//SI1True
            siSubScales.Add(new int[] { 49, 262, 280, 321, 342, 360 });//SI1False

            siSubScales.Add(new int[] { 337, 367 });//SI2True
            siSubScales.Add(new int[] { 86, 340, 353, 359, 363, 370 });//SI2False

            siSubScales.Add(new int[] { 31, 56, 104, 110, 135, 284, 302, 308, 326, 328, 338, 347, 348, 358, 364, 368, 369 }); //SI3True
            siSubScales.Add(new int[0] { }); //SI3False
            #endregion SI_SCALES

            #region SUPPLEMENTARY_SCALES 
            supplementalScales.Add(new int[] { 31, 38, 56, 65, 82, 127, 135, 215, 233, 243, 251, 273, 277, 289, 301, 309, 310, 311, 325, 328, 338, 339, 341, 347, 390, 391, 394, 400, 408, 411, 415, 421, 428, 442, 448, 451, 464, 469 });//ATrue
            supplementalScales.Add(new int[] { 388 });//AFalse

            supplementalScales.Add(new int[0] { });//RTrue
            supplementalScales.Add(new int[] { 1, 7, 10, 14, 37, 45, 69, 112, 118, 120, 128, 134, 142, 168, 178, 189, 197, 199, 248, 255, 256, 297, 330, 346, 350, 353, 354, 359, 363, 365, 422, 423, 430, 432, 449, 456, 465 });//RFalse

            supplementalScales.Add(new int[] { 2, 33, 45, 98, 141, 159, 169, 177, 179, 189, 199, 209, 213, 230, 245, 323, 385, 406, 413, 425 });//EsTrue
            supplementalScales.Add(new int[] { 23, 31, 32, 36, 39, 53, 60, 70, 82, 87, 119, 128, 175, 196, 215, 221, 225, 229, 236, 246, 307, 310, 316, 328, 391, 394, 441, 447, 458, 464, 469, 471 });//EsFalse

            supplementalScales.Add(new int[] { 7, 24, 36, 49, 52, 69, 72, 82, 84, 103, 105, 113, 115, 128, 168, 172, 202, 214, 224, 229, 238, 257, 280, 342, 344, 387, 407, 412, 414, 422, 434, 439, 445, 456, 473, 502, 506, 549 });//MAC-RTrue
            supplementalScales.Add(new int[] { 73, 107, 117, 137, 160, 166, 251, 266, 287, 299, 325 });//MAC-RFalse

            supplementalScales.Add(new int[] { 281, 291, 303, 311, 317, 319, 322, 323, 329, 332, 333, 334, 387, 395, 407, 431, 450, 454, 463, 468, 476, 478, 484, 489, 506, 516, 517, 520, 524, 525, 526, 528, 530, 539, 540, 544, 555 });//FaTrue
            supplementalScales.Add(new int[] { 383, 404, 501 }); //FaFalse

            supplementalScales.Add(new int[] { 67, 79, 207, 286, 305, 398, 471 }); //O-HTrue
            supplementalScales.Add(new int[] { 1, 15, 29, 69, 77, 89, 98, 116, 117, 129, 153, 169, 171, 293, 344, 390, 400, 420, 433, 440, 460 }); //O-HFalse

            supplementalScales.Add(new int[] { 55, 207, 232, 245, 386, 416 });//DoTrue
            supplementalScales.Add(new int[] { 31, 52, 70, 73, 82, 172, 201, 202, 220, 227, 243, 244, 275, 309, 325, 399, 412, 470, 473 });//DoFalse

            supplementalScales.Add(new int[] { 100, 160, 199, 266, 440, 467 });//ReTrue
            supplementalScales.Add(new int[] { 7, 27, 29, 32, 84, 103, 105, 145, 164, 169, 201, 202, 235, 275, 358, 412, 417, 418, 430, 431, 432, 456, 468, 470 });//ReFalse

            supplementalScales.Add(new int[] { 15, 16, 28, 31, 38, 71, 73, 81, 82, 110, 130, 215, 218, 233, 269, 273, 299, 302, 325, 331, 339, 357, 408, 411, 449, 464, 469, 472 });//MtTrue
            supplementalScales.Add(new int[] { 2, 3, 9, 10, 20, 43, 95, 131, 140, 148, 152, 223, 405 });//MTFalse

            supplementalScales.Add(new int[] { 8, 20, 143, 152, 159, 163, 176, 199, 214, 237, 321, 350, 385, 388, 401, 440, 462, 467, 474 });//GMTrue
            supplementalScales.Add(new int[] { 4, 23, 44, 64, 70, 73, 74, 80, 100, 137, 146, 187, 289, 331, 351, 364, 392, 395, 435, 438, 441, 469, 471, 498, 509, 519, 532, 536 });//GMFalse

            supplementalScales.Add(new int[] { 62, 67, 119, 121, 128, 203, 263, 266, 353, 384, 426, 449, 456, 473, 552 });//GFTrue
            supplementalScales.Add(new int[] { 1, 27, 63, 68, 79, 84, 105, 123, 133, 155, 197, 201, 220, 231, 238, 239, 250, 257, 264, 272, 287, 406, 417, 465, 477, 487, 510, 511, 537, 548, 550 });//GFFalse

            supplementalScales.Add(new int[] { 16, 17, 22, 23, 30, 31, 32, 37, 39, 48, 52, 56, 59, 65, 82, 85, 92, 94, 101, 135, 150, 168, 170, 196, 221, 274, 277, 302, 303, 305, 316, 319, 327, 328, 339, 347, 349, 367 });//PKTrue
            supplementalScales.Add(new int[] { 2, 3, 9, 49, 75, 95, 125, 140 });//PKFalse

            supplementalScales.Add(new int[] { 17, 21, 22, 31, 32, 37, 38, 44, 48, 56, 59, 65, 85, 94, 116, 135, 145, 150, 168, 170, 180, 218, 221, 273, 274, 277, 299, 301, 304, 305, 311, 316, 319, 325, 328, 377, 386, 400, 463, 464, 469, 471, 475, 479, 515, 516, 565 });//PSTrue
            supplementalScales.Add(new int[] { 3, 9, 45, 75, 95, 141, 165, 208, 223, 280, 372, 405, 564 });//PSFalse

            supplementalScales.Add(new int[] { 21, 22, 135, 195, 219, 382, 484, 563 });//MDSTrue
            supplementalScales.Add(new int[] { 12, 83, 95, 125, 493, 494 });//MDSFalse

            supplementalScales.Add(new int[] { 7, 29, 41, 89, 103, 113, 120, 168, 183, 189, 196, 217, 242, 260, 267, 341, 342, 344, 377, 422, 502, 523, 540 });//APSTrue
            supplementalScales.Add(new int[] { 4, 43, 76, 104, 137, 157, 220, 239, 306, 312, 349, 440, 495, 496, 500, 504 });//APSFalse

            supplementalScales.Add(new int[] { 172, 264, 288, 362, 387, 487, 489, 511, 527, 544 });//AASTrue
            supplementalScales.Add(new int[] { 266, 429, 501 });//AASFalse

            supplementalScales.Add(new int[] { 15, 30, 31, 39, 170, 196, 273, 290, 299, 301, 305, 339, 408, 415, 463, 469, 509, 556 });//ANXTrue
            supplementalScales.Add(new int[] { 140, 208, 223, 405, 496 });//ANXFalse

            supplementalScales.Add(new int[] { 154, 317, 322, 329, 334, 392, 395, 397, 435, 438, 441, 447, 458, 468, 471, 555 });//FRSTrue
            supplementalScales.Add(new int[] { 115, 163, 186, 385, 401, 453, 462 });//FRSFalse

            supplementalScales.Add(new int[] { 55, 87, 135, 196, 309, 313, 327, 328, 394, 442, 482, 491, 497, 509, 547, 553 });//OBSTrue
            supplementalScales.Add(new int[0] { });//OSBFalse

            supplementalScales.Add(new int[] { 38, 52, 56, 65, 71, 82, 92, 130, 146, 215, 234, 246, 277, 303, 306, 331, 377, 399, 400, 411, 454, 506, 512, 516, 520, 539, 546, 554 });//DEPTrue
            supplementalScales.Add(new int[] { 3, 9, 75, 95, 388 });//DEPFalse

            supplementalScales.Add(new int[] { 11, 18, 28, 36, 40, 44, 53, 59, 97, 101, 111, 149, 175, 247 });//HEATrue
            supplementalScales.Add(new int[] { 20, 33, 45, 47, 57, 91, 117, 118, 141, 142, 159, 164, 176, 179, 181, 194, 204, 224, 249, 255, 295, 404 });//HEAFalse

            supplementalScales.Add(new int[] { 24, 32, 60, 96, 138, 162, 198, 228, 259, 298, 311, 316, 319, 333, 336, 355, 361, 466, 490, 508, 543, 551 });//BIZTrue
            supplementalScales.Add(new int[] { 427 });//BIZFalse

            supplementalScales.Add(new int[] { 29, 37, 116, 134, 302, 389, 410, 414, 430, 461, 486, 513, 540, 542, 548 });//ANGTrue
            supplementalScales.Add(new int[] { 564 });//ANGFalse

            supplementalScales.Add(new int[] { 50, 58, 76, 81, 104, 110, 124, 225, 241, 254, 283, 284, 286, 315, 346, 352, 358, 374, 399, 403, 445, 470, 538 });//CYNTrue
            supplementalScales.Add(new int[0] { });//CYNFalse

            supplementalScales.Add(new int[] { 26, 35, 66, 81, 84, 104, 105, 110, 123, 227, 240, 248, 250, 254, 269, 283, 284, 374, 412, 418, 419 });//ASPTrue
            supplementalScales.Add(new int[] { 266 });//ASPFalse

            supplementalScales.Add(new int[] { 27, 136, 151, 212, 302, 358, 414, 419, 420, 423, 430, 437, 507, 510, 523, 531, 535, 541, 545 });//TPATrue
            supplementalScales.Add(new int[0] { });//TPAFalse

            supplementalScales.Add(new int[] { 70, 73, 130, 235, 326, 369, 376, 380, 411, 421, 450, 457, 475, 476, 483, 485, 503, 504, 519, 526, 562 });//LSETrue
            supplementalScales.Add(new int[] { 61, 78, 109 });//LSEFalse

            supplementalScales.Add(new int[] { 46, 158, 167, 185, 265, 275, 281, 337, 349, 367, 479, 480, 515 });//SODTrue
            supplementalScales.Add(new int[] { 49, 86, 262, 280, 321, 340, 353, 359, 360, 363, 370 });//SODFalse

            supplementalScales.Add(new int[] { 21, 54, 145, 190, 195, 205, 256, 292, 300, 323, 378, 379, 382, 413, 449, 478, 543, 550, 563, 567 });//FAMTrue
            supplementalScales.Add(new int[] { 83, 125, 217, 383, 455 });//FAMFalse

            supplementalScales.Add(new int[] { 15, 17, 31, 54, 73, 98, 135, 233, 243, 299, 302, 339, 364, 368, 394, 409, 428, 445, 464, 491, 505, 509, 517, 525, 545, 554, 559, 566 });//WRKTrue
            supplementalScales.Add(new int[] { 10, 108, 318, 521, 561 });//WRKFalse

            supplementalScales.Add(new int[] { 22, 92, 274, 306, 364, 368, 373, 375, 376, 377, 391, 399, 482, 488, 491, 495, 497, 499, 500, 504, 528, 539, 554 });//TRTTrue
            supplementalScales.Add(new int[] { 493, 494, 501 });//TRTFalse
            #endregion
        }

        public List<List<int[]>> getRawScales()
        {
            return allRawScales;
        }
    }
}
