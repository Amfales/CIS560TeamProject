import pyodbc
import csv
from random import random

conn_str = (
    r'DRIVER={SQL Server};'
    r'SERVER=NATHAN-DESKTOP\LIBRARYKIOSK;'
    r'DATABASE=librarykiosk;'
    r'Trusted_Connection=yes;'
    )

# publishers and genres to be randomly inserted into the database,
# as they are not included in the books csv being used
publishers = ['Pearson',
              'ThomsonReuters',
              'RELIX Group',
              'Wolters Kluwer',
              'Penguin Random House',
              'Phoenix Publishing,',
              'China South Publishing',
              'Hachette Livre',
              'McGraw-Hill Education',
              'Holtzbrinck',
              'Grupo Planeta',
              'Scholastic',
              'Wiley',
              'Cengage Learning Holdings',
              'II LP',
              'Harper Collins',
              'Houghton Mifflin Harcourt',
              'De Agostini Editore']

genres = ['Drama',
            'Action and Adventure',
            'Romance',
            'Mystery',
            'Horror',
            'Self help',
            'Health',
            'Guide',
            'Travel',
            'Childrens',
            'Religion, Spirituality & New Age',
            'Science',
            'History',
            'Math',
            'Anthology',
            'Poetry',
            'Encyclopedias',
            'Dictionaries',
            'Comics',
            'Art',
            'Cookbooks',
            'Diaries',
            'Journals',
            'Prayer books',
            'Series',
            'Trilogy',
            'Biographies',
            'Autobiographies',
            'Fantasy']


def main():
    NUM_ENTRIES = 50 # choose how many rows to enter into the database
    NUM_SKIP_LINES = 0 # set to skip the first n lines of the CSV
    
    # set up DB connection
    cnxn = pyodbc.connect(conn_str)
    cursor = cnxn.cursor()

    # initialize counter to stop after NUM_ENTERIES books
    counter = 0
    
    with open("books.csv", encoding="utf8") as file:
        for z in range(NUM_SKIP_LINES):
            next(file)
            
        next(file) #skip the header information

        reader = csv.reader(file)
        for line in reader:
            counter += 1
            if counter > NUM_ENTRIES:
                break
            
            # read data from the csv
            # escape ' characters to python string insertion doesn't break
            title = line[10].replace("'", "\'")
            author = line[7].replace("'", "\'").split(',')[0]
            author_fn = author.split(' ')[0].replace("'", "\'")
            author_ln = ' '.join(author.split(' ')[1:]).replace("'", "\'")
            #randomly generate publishers and genres
            pub = publishers[int(random()*len(publishers))]
            genre = genres[int(random()*len(genres))]
            isbn = line[5].replace("'", "\'")
            # conversions get rid of a .0 on the end of a year, i.e. 2018.0
            year = str(round(float(line[8].replace("'", "\'"))))

            #execute query through pyodbc connection
            query = ("DECLARE @BookID INT; EXEC Book.AddBookWithoutInfoID "
                +"N'%s', N'%s', N'%s', N'%s', N'%s', N'%s', %s, @BookID OUTPUT;"
                % (title, author_fn, author_ln, pub, genre, isbn, year))
            print(query) #print for debugging
            cursor.execute(query)

    #release the DB connection
    cursor.commit()


if __name__ == "__main__":
    main()
