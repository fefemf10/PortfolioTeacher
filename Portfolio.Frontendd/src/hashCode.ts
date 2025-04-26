export function hashCode(str: string): number {
  let hash = 0;
  for (let i = 0; i < str.length; i++) {
      hash = (hash << 5) - hash + str.charCodeAt(i); // Hash calculation
      hash |= 0; // Convert to 32-bit integer
  }
  return hash + 1 & 0x0FFFFFFF;
}
