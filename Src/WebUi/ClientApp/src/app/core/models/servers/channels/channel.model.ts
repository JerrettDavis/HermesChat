export interface Channel {
  id: string;
  name: string;
  topic?: string | null;
  nsfw: boolean;
}
