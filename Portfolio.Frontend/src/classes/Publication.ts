import { PublicationType } from "@/enums/PublicationType";
import { UserFile } from "./UserFile";

export class TeacherShortNameInfo {
  id: string;
  lastName: string;
  firstName: string;
  middleName: string;

  constructor(data: Partial<TeacherShortNameInfo> = {}) {
    this.id = data.id || '';
    this.lastName = data.lastName || '';
    this.firstName = data.firstName || '';
    this.middleName = data.middleName || '';
  }
}

export class Publication {
  id: string;
  name: string;
  publicationType: PublicationType;
  yearPublication: number;
  coAuthors: TeacherShortNameInfo[];
  files: UserFile[];

  constructor(data: Partial<Publication> = {}) {
    this.id = data.id || '';
    this.name = data.name || '';
    this.publicationType = data.publicationType || PublicationType.Article;
    this.yearPublication = data.yearPublication || new Date().getFullYear();
    this.coAuthors = data.coAuthors?.map(a => new TeacherShortNameInfo(a)) || [];
    this.files = data.files || [];
  }
}

export class Monography extends Publication {
  publisher?: string | null;
  circulation: number;
  countPages: number;

  constructor(data: Partial<Monography> = {}) {
    super(data);
    this.publisher = data.publisher ?? null;
    this.circulation = data.circulation || 0;
    this.countPages = data.countPages || 0;
  }
}

export class Article extends Publication {
  journal?: string | null;
  issueNumber: number;
  printedSheets: number;
  beginPage: number;
  endPage: number;
  url?: string | null;

  constructor(data: Partial<Article> = {}) {
    super(data);
    this.journal = data.journal ?? null;
    this.issueNumber = data.issueNumber || 0;
    this.printedSheets = data.printedSheets || 0;
    this.beginPage = data.beginPage || 0;
    this.endPage = data.endPage || 0;
    this.url = data.url ?? null;
  }
}

export class Thesis extends Publication {
  type: string;
  collection: string;
  beginPage: number;
  endPage: number;
  place: string;
  dateEvent: string;
  countPages: number;

  constructor(data: Partial<Thesis> = {}) {
    super(data);
    this.type = data.type || '';
    this.collection = data.collection || '';
    this.beginPage = data.beginPage || 0;
    this.endPage = data.endPage || 0;
    this.place = data.place || '';
    this.dateEvent = data.dateEvent || '';
    this.countPages = data.countPages || 0;
  }
}
