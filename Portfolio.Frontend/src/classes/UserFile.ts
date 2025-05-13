import { FileType } from "@/enums/FileType";

export class UserFile {
  id: string;
  name: string;
  fileType: FileType;
  size: number;
}
