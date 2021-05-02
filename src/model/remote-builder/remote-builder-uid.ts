import { customAlphabet } from 'nanoid';
class RemoteBuilderUID {
  static alphabet = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';
  static GetUniqueId(length): string {
    return customAlphabet(RemoteBuilderUID.alphabet, length)();
  }
}
export default RemoteBuilderUID;
