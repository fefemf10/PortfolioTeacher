import { PublicationType } from "@/enums/PublicationType";
import { UserFile } from "./UserFile";
export class TeacherShortNameInfo {
  id: string;
  lastName: string;
  firstName: string;
  middleName: string;
}
export class Publication {
  id: string;
  name: string;
  publicationType: PublicationType;
  yearPublication: number;
  coAuthors: TeacherShortNameInfo[];
  files: UserFile[];
}
export class Monography extends Publication {
  publisher?: string | null;
  circulation: number;
  countPages: number;
}
export class Article extends Publication {
  journal?: string | null;
  issueNumber: number;
  printedSheets: number;
  beginPage: number;
  endPage: number;
  url?: string | null;
}
export class Thesis extends Publication {
  type: string;
  collection: string;
  beginPage: number;
  endPage: number;
  place: string;
  dateEvent: string;
  countPages: number;
}
