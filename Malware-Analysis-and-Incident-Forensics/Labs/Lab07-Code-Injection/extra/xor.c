#include <stdio.h>
#include <stdlib.h>

int main(int argc, char* argv[]) {
  if (argc != 4) {
	  printf("Syntax: %s <input_file> <output_file> <hex_XOR_byte>\r\n", argv[0]);
	  return 1;
  }
  unsigned char key = (unsigned char)strtol(argv[3], NULL, 16);
  printf("Byte chosen as XOR key: 0x%x\r\n", key);
  FILE *fp = fopen(argv[1], "rb");
  FILE *gp = fopen(argv[2], "wb");
  if (fp==NULL || gp==NULL) {
	printf("ERROR OPENING FILE(s)\r\n");
	return 1;
  }
  int rc;
  while((rc = fgetc(fp))!=EOF)
    fputc(rc ^ key, gp);
  fclose(fp);
  fclose(gp);
  return 0;
}