

export class ImageConverter {

  private file: File;

   constructor(file: File) {
       this.file = file;
   }

   getBin64ImageStringReader() {

    let fileReader = new FileReader();

     fileReader.readAsDataURL(this.file);

    return fileReader;

   }

}