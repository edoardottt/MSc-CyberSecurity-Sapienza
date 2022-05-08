#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>

void remove_new_line(char *s)
{
    while (*s)
    {
        if (*s == '\n')
        {
            *s = '\0';
        }
        s++;
    }
}

// check if a line is already in
int isPresent(char *input)
{
    char *line4 = NULL;
    size_t len4 = 0;
    ssize_t read4;
    FILE *temp = fopen("temporary-file.txt", "w");
    while ((read4 = getline(&line4, &len4, temp)) != -1)
    {
        printf("%s", input);
        remove_new_line(input);
        remove_new_line(line4);
        if (strcmp(input, line4) == 0)
        {
            return 1;
        }
    }
    return 0;
}

void main(int args, char *argv[])
{

    FILE *from, *to, *temp;
    int c;
    char *line = NULL;
    size_t len = 0;
    ssize_t read;

    /*
     * Check input arguments
     */
    if (args != 3)
    {
        fprintf(stderr, "[ERROR] - You should insert as input two filenames (where read, the first; and where write, the second)\n");
        exit(1);
    }

    /*
     * Check first input
     */
    if ((from = fopen(argv[1], "r")) == NULL)
    {
        perror("[ERROR]");
        exit(1);
    }

    /*
     * Check second input
     */
    if ((to = fopen(argv[2], "w")) == NULL)
    {
        perror("[ERROR]");
        exit(1);
    }

    int i = 0;
    temp = fopen("temporary-file.txt", "w");

    while ((read = getline(&line, &len, from)) != -1)
    {

        remove_new_line(line);

        FILE *file;
        if ((file = fopen(line, "r")) == NULL)
        {
            perror("[ERROR]");
            exit(1);
        }

        char *line2 = NULL;
        size_t len2 = 0;
        ssize_t read2;

        while ((read2 = getline(&line2, &len2, file)) != -1)
        {
            char *elemm = NULL;
            remove_new_line(line2);
            elemm = strdup(line2);
            temp = fopen("temporary-file.txt", "w");
            if (isPresent(line2) == 0)
            {
                char *elem2 = strcat(line2, " ");
                elem2 = strcat(elem2, line);

                fputs(elem2, to);
                fputs("\n", to);

                fputs(elemm, temp);
                fputs("\n", temp);
            }
            char *line2 = NULL;
        }
    }

    fclose(temp);
    fclose(from);
    fclose(to);
    exit(0);
}