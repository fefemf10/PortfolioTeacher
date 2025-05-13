import { DissertationType } from "@/enums/DissertationType";

export class Dissertation {
  id: string;
  yearProtection: number;
  type: DissertationType;
  specialization: string;
  topic: string;

  constructor(data: Partial<Dissertation> = {}) {
    this.id = data.id || '';
    this.yearProtection = data.yearProtection || new Date().getFullYear();
    this.type = data.type || DissertationType.Master;
    this.specialization = data.specialization || '';
    this.topic = data.topic || '';
  }
}
